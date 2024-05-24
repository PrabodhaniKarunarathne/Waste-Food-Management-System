using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Waste_Food_Management___Donation
{
    public partial class UC_Dashboard : UserControl
    {
       
        Timer timer = new Timer();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A7IP4IG\\SQLEXPRESS;Initial Catalog=Wast Fodd Managemant System And Donation;Integrated Security=true");
        public static string userName;
        public UC_Dashboard()
        {
            InitializeComponent();

            timer.Interval = 1000; // Set the interval to 1000 milliseconds (1 second)
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateTime(); // Initial update

            string q = "SELECT COUNT(*) FROM Restaurants";
            conn.Open();
            SqlCommand cmd = new SqlCommand(q, conn);
            Object Count = cmd.ExecuteScalar();
            int rowCount = int.Parse(Count.ToString());
            conn.Close();
            guna2CircleProgressBar2.Value= rowCount;

            string p = "SELECT COUNT(*) FROM Ngo";
            conn.Open();
            SqlCommand cmds = new SqlCommand(p, conn);
            Object C = cmds.ExecuteScalar();
            int rowCoun = int.Parse(C.ToString());
            conn.Close();
            guna2CircleProgressBar1.Value = rowCoun;

            userName = Form2.nameOfPerson;
            label1.Text = Form2.nameOfPerson;

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            label26.Text = $"Year: {currentYear}, Month: {currentMonth}";

            guna2ProgressBar1.Value = OverallSummaryToday();
            guna2ProgressBar2.Value = OverallSummaryYesterday();
            guna2ProgressBar3.Value = AverageSummary();
            label28.Text=pendingDonation().ToString();
            label21.Text=successDonation().ToString();
            label19.Text=overallDonation().ToString();
            dayDonation();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            label22.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleProgressBar2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private string dayIdentifier(string day)
        {
            
            DateTime date = DateTime.ParseExact(day, "M/d/yyyy", null);
            DayOfWeek dayOfWeek = date.DayOfWeek;
            return dayOfWeek.ToString();
        }

        private string actor()
        {
            char character = Form2.userName[0];
            if(character == 'N')
            {
                return "ngoId";
            }
            else if(character == 'S')
            {
                return "shopId";
            }
            else
            {
                return null;
            }
            
        }
        private int OverallSummaryToday()
        {
            string person = actor();
            DateTime currentDate = DateTime.Now;
            string q = "SELECT COUNT(*) FROM ItemHistory WHERE " + person + " = @" + person + " AND date = @date";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@" + person, Form2.userName); 
                cmd.Parameters.AddWithValue("@date", currentDate.Date);

                int rowCount = (int)cmd.ExecuteScalar();
                conn.Close();
                
                return rowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somting Wrong Plese Call Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private int OverallSummaryYesterday()
        {
            string person = actor();
            DateTime currentDate = DateTime.Now;
            string q = "SELECT COUNT(*) FROM ItemHistory WHERE " + person + " = @" + person + " AND date = @date";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@" + person, Form2.userName);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.Date.AddDays(-1)); // Get yesterday's date

                int rowCount = (int)cmd.ExecuteScalar();
                conn.Close();
               
                return rowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private int AverageSummary()
        {
            string person = actor();
            try
            {
                conn.Open();

                // Count records for the logged-in user
                string q = "SELECT COUNT(*) FROM ItemHistory WHERE " + person + " = @" + person;
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@" + person, Form2.userName);
                int rowCount = (int)cmd.ExecuteScalar();

                // Count all records
                string p = "SELECT COUNT(*) FROM ItemHistory";
                SqlCommand cm = new SqlCommand(p, conn);
                int totalRowCount = (int)cm.ExecuteScalar();

                conn.Close();

                // Calculate and display the average
                int average = (int)((rowCount / (double)totalRowCount) * 100);
               

                return average;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int successDonation()
        {
            string q = "SELECT COUNT(*) FROM ItemHistory WHERE verify=@verify";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@verify", "YES");

                int rowCount = (int)cmd.ExecuteScalar();
                conn.Close();
                
                return rowCount;
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Something went wrong. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            
        }

        private int pendingDonation()
        {
            string q = "SELECT COUNT(*) FROM ItemHistory WHERE verify=@verify";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@verify", "NO");

                int rowCount = (int)cmd.ExecuteScalar();
                conn.Close();

                return rowCount;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int overallDonation()
        {
            string q = "SELECT COUNT(*) FROM ItemHistory";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(q, conn);
                

                int rowCount = (int)cmd.ExecuteScalar();
                conn.Close();

                return rowCount;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //day edition
        public void dayDonation()
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Label[] labels = { label11, label12, label13, label14, label15, label16, label17 };

            try
            {
                conn.Open();
                for (int i = 0; i < days.Length; i++)
                {
                    string query = "SELECT ISNULL(SUM(noOfItem), 0) FROM ItemHistory WHERE verify = 'YES' AND DATEPART(WEEKDAY, date) = @day";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@day", i + 1); // 1 for Sunday, 2 for Monday, and so on.

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    labels[i].Text =  count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2CustomGradientPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

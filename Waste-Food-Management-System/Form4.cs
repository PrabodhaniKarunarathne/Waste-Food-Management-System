using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Waste_Food_Management___Donation
{
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A7IP4IG\\SQLEXPRESS;Initial Catalog=Wast Fodd Managemant System And Donation;Integrated Security=true");
        public static int idGenerator = 0;

        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Code for label click event (if needed)
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string s = Form2.userName;
                conn.Open();
                string query = "SELECT itemName,noOfItem,date,time FROM ItemHistory where shopId=@shopId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@shopId", s);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int newId()
        {
            string q = "SELECT ISNULL(MAX(foodId), 0) FROM ItemHistory";
            conn.Open();
            SqlCommand cmd = new SqlCommand(q, conn);
            int rowCount = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return ++rowCount;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;
                string date = currentDateTime.ToShortDateString();
                string time = currentDateTime.ToShortTimeString();
                string userName = Form2.userName;
                idGenerator = newId();
                conn.Open();
                string query = "INSERT into ItemHistory (foodId,shopId,ngoId,itemName, noOfItem, date, time, verify) " +
                               "VALUES (@foodId,@shopId,@ngoId, @itemName, @noOfItem, @data, @time, @verify)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@foodId", idGenerator);
                cmd.Parameters.AddWithValue("@shopId", userName);
                cmd.Parameters.AddWithValue("@ngoId","");
                cmd.Parameters.AddWithValue("@ItemName", gunaTextBox1.Text);
                cmd.Parameters.AddWithValue("@noOfItem", int.Parse(gunaTextBox2.Text));
                cmd.Parameters.AddWithValue("@data", date);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@verify", "NO");
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thanks For Give Your Donation", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh DataGridView
                }
                else
                {
                    MessageBox.Show("No rows were affected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

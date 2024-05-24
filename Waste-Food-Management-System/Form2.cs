using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Waste_Food_Management___Donation
{
   
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A7IP4IG\\SQLEXPRESS;Initial Catalog=Wast Fodd Managemant System And Donation;Integrated Security=true");

        
        

        public Form2()
        {
            InitializeComponent();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        public static string nameOfPerson;
        public static string userName;
        public static string password;
        
        private void iconButton1_Click(object sender, EventArgs e)
        {
            string qName = "";
            userName = textBox2.Text;
            password = textBox1.Text;
            string temp;
            string query="";
            char firstCharacter = userName[0];
            string parameter = "@userName";

            if (firstCharacter == 'N')
            {
                query = "SELECT ngoPassword from Ngo where ngoUserName=" + parameter;
                qName = "SELECT ngoName from Ngo where ngoUserName=" + parameter;
            }
            else if(firstCharacter =='S')
            {
                query = "SELECT password from Restaurants where userName=" + parameter;
                qName = "SELECT shopName from Restaurants where userName=" + parameter;
            }
           
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue(parameter, userName);
            Object passwordBase = cmd.ExecuteScalar();
            temp = passwordBase != null ? passwordBase.ToString() : "";
            conn.Close();


            conn.Open();
            cmd = new SqlCommand(qName, conn); // Reassign cmd
            cmd.Parameters.AddWithValue(parameter, userName);
            Object p = cmd.ExecuteScalar();
            nameOfPerson = p != null ? p.ToString() : "";
            conn.Close();

            if (temp == password)
            {

                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 form6=new Form6();
            form6.Show();
            this.Hide();
        }
    }
}

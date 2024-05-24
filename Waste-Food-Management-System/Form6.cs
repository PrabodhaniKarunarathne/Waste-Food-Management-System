using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Waste_Food_Management___Donation
{

    public partial class Form6 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A7IP4IG\\SQLEXPRESS;Initial Catalog=Wast Fodd Managemant System And Donation;Integrated Security=true");
        public Form6()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string userName = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;
            string reEnterPassword = guna2TextBox3.Text;

            if (password == reEnterPassword)
            {
                char firstCharacter = userName[0];

                conn.Open();

                if (firstCharacter == 'N')
                {
                    string p = "UPDATE Ngo SET password=@password WHERE userName=@userName";
                    SqlCommand cm = new SqlCommand(p, conn);
                    cm.Parameters.AddWithValue("@password", password);
                    cm.Parameters.AddWithValue("@userName", userName);

                    int rowsAffected = cm.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password. Please check your inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (firstCharacter == 'S')
                {
                    string p = "UPDATE Restaurants SET password=@password WHERE userName=@userName";
                    SqlCommand cm = new SqlCommand(p, conn);
                    cm.Parameters.AddWithValue("@password", password);
                    cm.Parameters.AddWithValue("@userName", userName);

                    int rowsAffected = cm.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password. Please check your inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}

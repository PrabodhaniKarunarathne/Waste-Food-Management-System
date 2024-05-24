using System;
using System.Collections;
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

namespace Waste_Food_Management___Donation
{
    public partial class Form1 : Form
    {
        private static int ngoId=0;
        private static int restaurantId=0;
        private string idGenerate;
        private string name;
        private string contactNo;
        private string userName;
        private string password;
        private string role;
        private string reEnterPassword;
        private string venue;

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A7IP4IG\\SQLEXPRESS;Initial Catalog=Wast Fodd Managemant System And Donation;Integrated Security=true");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            
        }
        //role check
        private bool roleCheck(string role)
        {
            bool result;
            if(role == "Ngo" ||role=="Restaurants")
            {
                result = true;
            }
            else
            {
                result= false;
            }
            return result;
        }
        //name check
        private bool nameCheck(string name)
        {
            bool result;
            if(name == "")
            {
                
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
        //contack No
        private bool contactNoCheck(string contactNo)
        {
         
            bool result;
           if(contactNo == "")
            {
                MessageBox.Show("Your contact No is not real", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result =false;
            }

             if (IsInteger(contactNo)==true)
            {
                result=true;    
            }
             if(contactNo.Length != 10)
            {
                result=false;
                MessageBox.Show("Your contact No is not 10 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                result=true;
                
            }
           return result;
        }

        private bool IsInteger(string contactNo)
        {
            int result;
            return int.TryParse(contactNo, out result);
        }


        //password
        private bool passwordCheck(string password,string reEnterPassword)
        {
            bool result;
            if(password=="" )
            {
                result = false;
               
            }
            else if (password==reEnterPassword)
            {
                result=true;
            }
            else
            {
                result=false;
              
            }
            return result;
        }
        //venue check
        private bool venueCheck(string venue)
        {
            bool result;

            if (venue=="")
            {
               
                result =false;
            }
            else
            {
                result=true;
            }

            return result;
        }
  
        private string idGenerator(string role)
        {
            string tableName = "";
            if (role=="Ngo")
            {
                tableName += "Ngo";
            }
            else
            {
                tableName += "Restaurants";
            }
             

            string q = "SELECT COUNT(*) FROM " + tableName;
            conn.Open();
            SqlCommand cmd = new SqlCommand(q, conn);
            Object Count = cmd.ExecuteScalar();
            int rowCount=int.Parse(Count.ToString());
            conn.Close();
            string newId = "";
            if (role == "Ngo")
            {
                ngoId = rowCount + 1; // Assuming ngoId is a global variable
                newId = "N" + ngoId;
            }
            else if (role == "Restaurants")
            {
                restaurantId = rowCount + 1; // Assuming restaurantId is a global variable
                newId = "S" + restaurantId;
            }
            else
            {
                MessageBox.Show("Role Is Not Properly Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return newId;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            role = comboBox1.SelectedItem.ToString(); // Check if an item is selected
            if (role != null)
            {
                idGenerate = idGenerator(role);
                name = textBox1.Text;
                venue = textBox2.Text;
                contactNo = textBox3.Text;
                userName = idGenerate;
                password = textBox5.Text;
                reEnterPassword = textBox6.Text;
                
                if (roleCheck(role) && nameCheck(name) && venueCheck(venue) && contactNoCheck(contactNo) && passwordCheck(password, reEnterPassword) )
                {
                   
                    if (role == "Ngo")
                        {
                            string query = "INSERT into Ngo values(@id,@name,@contactNo,@userName,@password)";
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idGenerate);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@contactNo", contactNo);
                            cmd.Parameters.AddWithValue("@userName", userName);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Submit Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (role == "Restaurants")
                        {
                        


                            string query = "INSERT into Restaurants values(@id,@name,@venue,@contactNo,@userName,@password)";
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idGenerate);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@venue", venue);
                            cmd.Parameters.AddWithValue("@contactNo", contactNo);
                            cmd.Parameters.AddWithValue("@userName", userName);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Submit Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                        MessageBox.Show("Some thing wrong", "incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         } 
                    }
                    
                }
               
            }
        

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            a.Text = idGenerator(comboBox1.SelectedItem.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }
}

            


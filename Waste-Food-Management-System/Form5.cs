using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Waste_Food_Management___Donation
{
    public partial class Form5 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A7IP4IG\\SQLEXPRESS;Initial Catalog=Wast Fodd Managemant System And Donation;Integrated Security=true");

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string query = "SELECT Restaurants.shopName, Restaurants.shopContactNo, Restaurants.shopVenue, " +
                           "ItemHistory.foodId, ItemHistory.itemName, ItemHistory.noOfItem, ItemHistory.date, ItemHistory.time " +
                           "FROM Restaurants " +
                           "INNER JOIN ItemHistory ON Restaurants.shopId = ItemHistory.shopId " +
                           "WHERE ItemHistory.verify = 'NO'";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somting Wrong Plese Call Admin","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int foodId = (int)dataGridView1.Rows[selectedRowIndex].Cells["foodId"].Value;

                try
                {
                    conn.Open();

                    string query = "UPDATE ItemHistory SET verify = @verify, ngoId = @ngoId WHERE foodId = @foodId";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@verify", "YES");
                    command.Parameters.AddWithValue("@ngoId", Form2.userName);
                    command.Parameters.AddWithValue("@foodId", foodId);

                    int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thanks For get That Donation", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGridView(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No rows were selected");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Somting Wrong Plese Call Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please select what you need", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshDataGridView()
        {
            /*
              string query = "SELECT Restaurants.shopName, Restaurants.shopContactNo, Restaurants.shopVenue, " +
                           "ItemHistory.foodId, ItemHistory.itemName, ItemHistory.noOfItem, ItemHistory.date, ItemHistory.time " +
                           "FROM Restaurants " +
                           "INNER JOIN ItemHistory ON Restaurants.shopId = ItemHistory.shopId " +
                           "WHERE ItemHistory.verify = 'NO' AND ItemHistory.timestamp >= DATEADD(HOUR, -4, GETDATE())";
             */
            string query = "SELECT Restaurants.shopName, Restaurants.shopContactNo, Restaurants.shopVenue, " +
                           "ItemHistory.foodId, ItemHistory.itemName, ItemHistory.noOfItem, ItemHistory.date, ItemHistory.time " +
                           "FROM Restaurants " +
                           "INNER JOIN ItemHistory ON Restaurants.shopId = ItemHistory.shopId " +
                           "WHERE ItemHistory.verify = 'NO'";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somting Wrong Plese Call Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }
    }
}

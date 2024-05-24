using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Waste_Food_Management___Donation
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wast_Fodd_Managemant_System_And_DonationDataSet1.ItemHistory' table. You can move, or remove it, as needed.
            this.itemHistoryTableAdapter.Fill(this.wast_Fodd_Managemant_System_And_DonationDataSet1.ItemHistory);
            // TODO: This line of code loads data into the 'wast_Fodd_Managemant_System_And_DonationDataSet1.ItemHistory' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'wast_Fodd_Managemant_System_And_DonationDataSet.ItemHistory' table. You can move, or remove it, as needed.
            

            this.reportViewer1.RefreshReport();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

using Guna.UI2.WinForms;
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
    public partial class Form3 : Form
    {
       
        public Form3()
        {
            InitializeComponent();
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);

            string user = Form2.userName;
            char firstCharacter = user[0];
            if(firstCharacter == 'N')
            {
                guna2Button2.Hide();
            }
            else if(firstCharacter == 'S')
            {
                guna2Button3.Hide();
            }
           
           
        }
        
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 24, b.Location.Y - 25);
            imgSlide.SendToBack();
        }


        private void addUserControl(UserControl uc)
        {
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            panelContainer.Controls.Add(uc);
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {

            moveImageBox(sender);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();  
            form5.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();

        }
    }
}

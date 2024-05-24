namespace Waste_Food_Management___Donation
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.wast_Fodd_Managemant_System_And_DonationDataSet1 = new Waste_Food_Management___Donation.Wast_Fodd_Managemant_System_And_DonationDataSet1();
            this.wastFoddManagemantSystemAndDonationDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemHistoryTableAdapter = new Waste_Food_Management___Donation.Wast_Fodd_Managemant_System_And_DonationDataSet1TableAdapters.ItemHistoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.wast_Fodd_Managemant_System_And_DonationDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wastFoddManagemantSystemAndDonationDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemHistoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.itemHistoryBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Waste_Food_Management___Donation.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1103, 591);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // gunaButton1
            // 
            this.gunaButton1.Animated = true;
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.White;
            this.gunaButton1.BorderColor = System.Drawing.Color.White;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton1.ForeColor = System.Drawing.Color.Black;
            this.gunaButton1.Image = global::Waste_Food_Management___Donation.Properties.Resources.home3;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(890, 537);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gunaButton1.Radius = 20;
            this.gunaButton1.Size = new System.Drawing.Size(201, 42);
            this.gunaButton1.TabIndex = 7;
            this.gunaButton1.Text = "Back To Home";
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // wast_Fodd_Managemant_System_And_DonationDataSet1
            // 
            this.wast_Fodd_Managemant_System_And_DonationDataSet1.DataSetName = "Wast_Fodd_Managemant_System_And_DonationDataSet1";
            this.wast_Fodd_Managemant_System_And_DonationDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wastFoddManagemantSystemAndDonationDataSet1BindingSource
            // 
            this.wastFoddManagemantSystemAndDonationDataSet1BindingSource.DataSource = this.wast_Fodd_Managemant_System_And_DonationDataSet1;
            this.wastFoddManagemantSystemAndDonationDataSet1BindingSource.Position = 0;
            // 
            // itemHistoryBindingSource
            // 
            this.itemHistoryBindingSource.DataMember = "ItemHistory";
            this.itemHistoryBindingSource.DataSource = this.wastFoddManagemantSystemAndDonationDataSet1BindingSource;
            // 
            // itemHistoryTableAdapter
            // 
            this.itemHistoryTableAdapter.ClearBeforeFill = true;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1103, 591);
            this.Controls.Add(this.gunaButton1);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wast_Fodd_Managemant_System_And_DonationDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wastFoddManagemantSystemAndDonationDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemHistoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Wast_Fodd_Managemant_System_And_DonationDataSet1 wast_Fodd_Managemant_System_And_DonationDataSet1;
        private System.Windows.Forms.BindingSource wastFoddManagemantSystemAndDonationDataSet1BindingSource;
        private System.Windows.Forms.BindingSource itemHistoryBindingSource;
        private Wast_Fodd_Managemant_System_And_DonationDataSet1TableAdapters.ItemHistoryTableAdapter itemHistoryTableAdapter;
    }
}
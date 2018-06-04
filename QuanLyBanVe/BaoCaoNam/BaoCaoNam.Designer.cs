namespace BaoCaoNam
{
    partial class BaoCaoNam
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
            this.BaoCaoNamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLVeMayBayDataSet_2 = new QLVeMayBayDataSet_2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.cbbNam = new System.Windows.Forms.ComboBox();
            this.lbNam = new System.Windows.Forms.Label();
            this.BaoCaoNamTableAdapter = new QLVeMayBayDataSet_2TableAdapters.BaoCaoNamTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoNamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVeMayBayDataSet_2)).BeginInit();
            this.SuspendLayout();
            // 
            // BaoCaoNamBindingSource
            // 
            this.BaoCaoNamBindingSource.DataMember = "BaoCaoNam";
            this.BaoCaoNamBindingSource.DataSource = this.QLVeMayBayDataSet_2;
            // 
            // QLVeMayBayDataSet_2
            // 
            this.QLVeMayBayDataSet_2.DataSetName = "QLVeMayBayDataSet_2";
            this.QLVeMayBayDataSet_2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "BaoCaoNam";
            reportDataSource1.Value = this.BaoCaoNamBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BaoCaoNam.BaoCaoNam.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 66);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(790, 372);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(58, 37);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cbbNam
            // 
            this.cbbNam.FormattingEnabled = true;
            this.cbbNam.Items.AddRange(new object[] {
            "2018",
            "2017",
            "2016"});
            this.cbbNam.Location = new System.Drawing.Point(58, 10);
            this.cbbNam.Name = "cbbNam";
            this.cbbNam.Size = new System.Drawing.Size(87, 21);
            this.cbbNam.TabIndex = 2;
            this.cbbNam.SelectedIndexChanged += new System.EventHandler(this.cbbNam_SelectedIndexChanged);
            // 
            // lbNam
            // 
            this.lbNam.AutoSize = true;
            this.lbNam.Location = new System.Drawing.Point(23, 13);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(29, 13);
            this.lbNam.TabIndex = 3;
            this.lbNam.Text = "Năm";
            // 
            // BaoCaoNamTableAdapter
            // 
            this.BaoCaoNamTableAdapter.ClearBeforeFill = true;
            // 
            // BaoCaoNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbNam);
            this.Controls.Add(this.cbbNam);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BaoCaoNam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BaoCaoNam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoNamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVeMayBayDataSet_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BaoCaoNamBindingSource;
        private QLVeMayBayDataSet_2 QLVeMayBayDataSet_2;
        private QLVeMayBayDataSet_2TableAdapters.BaoCaoNamTableAdapter BaoCaoNamTableAdapter;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ComboBox cbbNam;
        private System.Windows.Forms.Label lbNam;
    }
}


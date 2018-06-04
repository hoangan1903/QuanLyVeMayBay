namespace BaoCaoNgay
{
    partial class BaoCaoNgay
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
            this.BaoCaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLVeMayBayDataSet = new QLVeMayBayDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BaoCaoTableAdapter = new QLVeMayBayDataSetTableAdapters.BaoCaoTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDi = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVeMayBayDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaoCaoBindingSource
            // 
            this.BaoCaoBindingSource.DataMember = "BaoCao";
            this.BaoCaoBindingSource.DataSource = this.QLVeMayBayDataSet;
            // 
            // QLVeMayBayDataSet
            // 
            this.QLVeMayBayDataSet.DataSetName = "QLVeMayBayDataSet";
            this.QLVeMayBayDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "BaoCaoNgay";
            reportDataSource1.Value = this.BaoCaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BaoCaoNgay.BaoCaoNgay.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 92);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(789, 454);
            this.reportViewer1.TabIndex = 0;
            // 
            // BaoCaoTableAdapter
            // 
            this.BaoCaoTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateDi);
            this.panel2.Controls.Add(this.dateDen);
            this.panel2.Controls.Add(this.btnThongKe);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(642, 74);
            this.panel2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // dateDi
            // 
            this.dateDi.CustomFormat = "dd/MM/yyyy";
            this.dateDi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDi.Location = new System.Drawing.Point(7, 30);
            this.dateDi.Margin = new System.Windows.Forms.Padding(4);
            this.dateDi.Name = "dateDi";
            this.dateDi.Size = new System.Drawing.Size(177, 20);
            this.dateDi.TabIndex = 1;
            this.dateDi.Value = new System.DateTime(2018, 5, 28, 0, 0, 0, 0);
            this.dateDi.ValueChanged += new System.EventHandler(this.dateDi_ValueChanged);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(290, 30);
            this.dateDen.Margin = new System.Windows.Forms.Padding(4);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(189, 20);
            this.dateDen.TabIndex = 2;
            this.dateDen.Value = new System.DateTime(2018, 5, 28, 10, 58, 1, 0);
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(531, 30);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(99, 29);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "đến ngày";
            // 
            // BaoCaoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 558);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BaoCaoNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVeMayBayDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BaoCaoBindingSource;
        private QLVeMayBayDataSetTableAdapters.BaoCaoTableAdapter BaoCaoTableAdapter;
        private QLVeMayBayDataSet QLVeMayBayDataSet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDi;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label2;
    }
}


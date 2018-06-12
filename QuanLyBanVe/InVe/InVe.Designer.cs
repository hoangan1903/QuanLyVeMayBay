namespace InVe
{
    partial class frmInVe
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
            this.InVeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLVeMayBayDataSet_3 = new InVe.QLVeMayBayDataSet_3();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InVeTableAdapter = new InVe.QLVeMayBayDataSet_3TableAdapters.InVeTableAdapter();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cbbMaVe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InVeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVeMayBayDataSet_3)).BeginInit();
            this.SuspendLayout();
            // 
            // InVeBindingSource
            // 
            this.InVeBindingSource.DataMember = "InVe";
            this.InVeBindingSource.DataSource = this.QLVeMayBayDataSet_3;
            // 
            // QLVeMayBayDataSet_3
            // 
            this.QLVeMayBayDataSet_3.DataSetName = "QLVeMayBayDataSet_3";
            this.QLVeMayBayDataSet_3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "InVe";
            reportDataSource1.Value = this.InVeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InVe.InVe.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(5, 42);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(756, 380);
            this.reportViewer1.TabIndex = 0;
            // 
            // InVeTableAdapter
            // 
            this.InVeTableAdapter.ClearBeforeFill = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTimKiem.Location = new System.Drawing.Point(157, 13);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbbMaVe
            // 
            this.cbbMaVe.FormattingEnabled = true;
            this.cbbMaVe.Location = new System.Drawing.Point(79, 15);
            this.cbbMaVe.Name = "cbbMaVe";
            this.cbbMaVe.Size = new System.Drawing.Size(72, 21);
            this.cbbMaVe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã vé";
            // 
            // frmInVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(779, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbMaVe);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInVe";
            this.Text = "In vé";
            this.Load += new System.EventHandler(this.InVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InVeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVeMayBayDataSet_3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InVeBindingSource;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cbbMaVe;
        private QLVeMayBayDataSet_3 QLVeMayBayDataSet_3;
        private QLVeMayBayDataSet_3TableAdapters.InVeTableAdapter InVeTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}


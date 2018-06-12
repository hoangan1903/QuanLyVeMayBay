namespace QuanLyBanVe
{
    partial class frmDanhSachKhachHang
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
            this.lblDanhSachKhachHang = new System.Windows.Forms.Label();
            this.dgvDanhSachKhachHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDanhSachKhachHang
            // 
            this.lblDanhSachKhachHang.AutoSize = true;
            this.lblDanhSachKhachHang.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDanhSachKhachHang.Location = new System.Drawing.Point(6, 12);
            this.lblDanhSachKhachHang.Name = "lblDanhSachKhachHang";
            this.lblDanhSachKhachHang.Size = new System.Drawing.Size(243, 30);
            this.lblDanhSachKhachHang.TabIndex = 3;
            this.lblDanhSachKhachHang.Text = "Danh Sách Khách Hàng";
            // 
            // dgvDanhSachKhachHang
            // 
            this.dgvDanhSachKhachHang.AllowUserToAddRows = false;
            this.dgvDanhSachKhachHang.AllowUserToDeleteRows = false;
            this.dgvDanhSachKhachHang.AllowUserToResizeColumns = false;
            this.dgvDanhSachKhachHang.AllowUserToResizeRows = false;
            this.dgvDanhSachKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachKhachHang.Location = new System.Drawing.Point(6, 59);
            this.dgvDanhSachKhachHang.Name = "dgvDanhSachKhachHang";
            this.dgvDanhSachKhachHang.ReadOnly = true;
            this.dgvDanhSachKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachKhachHang.Size = new System.Drawing.Size(789, 379);
            this.dgvDanhSachKhachHang.TabIndex = 2;
            // 
            // frmDanhSachKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDanhSachKhachHang);
            this.Controls.Add(this.dgvDanhSachKhachHang);
            this.Name = "frmDanhSachKhachHang";
            this.Text = "Danh sách khách hàng";
            this.Load += new System.EventHandler(this.frmDanhSachKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDanhSachKhachHang;
        private System.Windows.Forms.DataGridView dgvDanhSachKhachHang;
    }
}
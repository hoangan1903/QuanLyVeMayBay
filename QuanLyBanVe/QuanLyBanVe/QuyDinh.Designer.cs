namespace QuanLyBanVe
{
    partial class QuyDinh
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
            this.gridViewQuyDinh = new System.Windows.Forms.DataGridView();
            this.btnLuuQuyDinh = new System.Windows.Forms.Button();
            this.cbbMaQuyDinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyDinh)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewQuyDinh
            // 
            this.gridViewQuyDinh.AllowUserToAddRows = false;
            this.gridViewQuyDinh.AllowUserToDeleteRows = false;
            this.gridViewQuyDinh.AllowUserToResizeColumns = false;
            this.gridViewQuyDinh.AllowUserToResizeRows = false;
            this.gridViewQuyDinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewQuyDinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridViewQuyDinh.BackgroundColor = System.Drawing.Color.White;
            this.gridViewQuyDinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridViewQuyDinh.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridViewQuyDinh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridViewQuyDinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewQuyDinh.Location = new System.Drawing.Point(13, 64);
            this.gridViewQuyDinh.Name = "gridViewQuyDinh";
            this.gridViewQuyDinh.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridViewQuyDinh.RowHeadersVisible = false;
            this.gridViewQuyDinh.Size = new System.Drawing.Size(604, 99);
            this.gridViewQuyDinh.TabIndex = 0;
            this.gridViewQuyDinh.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewQuyDinh_CellEndEdit);
            // 
            // btnLuuQuyDinh
            // 
            this.btnLuuQuyDinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuQuyDinh.Enabled = false;
            this.btnLuuQuyDinh.Location = new System.Drawing.Point(538, 174);
            this.btnLuuQuyDinh.Name = "btnLuuQuyDinh";
            this.btnLuuQuyDinh.Size = new System.Drawing.Size(80, 27);
            this.btnLuuQuyDinh.TabIndex = 1;
            this.btnLuuQuyDinh.Text = "Lưu";
            this.btnLuuQuyDinh.UseVisualStyleBackColor = true;
            this.btnLuuQuyDinh.Click += new System.EventHandler(this.btnLuuQuyDinh_Click);
            // 
            // cbbMaQuyDinh
            // 
            this.cbbMaQuyDinh.BackColor = System.Drawing.Color.White;
            this.cbbMaQuyDinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaQuyDinh.FormattingEnabled = true;
            this.cbbMaQuyDinh.Location = new System.Drawing.Point(13, 30);
            this.cbbMaQuyDinh.Name = "cbbMaQuyDinh";
            this.cbbMaQuyDinh.Size = new System.Drawing.Size(236, 23);
            this.cbbMaQuyDinh.TabIndex = 3;
            this.cbbMaQuyDinh.TextChanged += new System.EventHandler(this.cbbMaQuyDinh_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn một quy định:";
            // 
            // QuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbMaQuyDinh);
            this.Controls.Add(this.btnLuuQuyDinh);
            this.Controls.Add(this.gridViewQuyDinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuyDinh";
            this.Text = "Quy định";
            this.Load += new System.EventHandler(this.QuyDinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyDinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewQuyDinh;
        private System.Windows.Forms.Button btnLuuQuyDinh;
        private System.Windows.Forms.ComboBox cbbMaQuyDinh;
        private System.Windows.Forms.Label label1;
    }
}
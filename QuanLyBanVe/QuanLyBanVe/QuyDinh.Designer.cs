﻿namespace QuanLyBanVe
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
            this.cbbTenQuyDinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSuaQuyDinh = new System.Windows.Forms.Button();
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
            this.gridViewQuyDinh.MultiSelect = false;
            this.gridViewQuyDinh.Name = "gridViewQuyDinh";
            this.gridViewQuyDinh.ReadOnly = true;
            this.gridViewQuyDinh.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridViewQuyDinh.RowHeadersVisible = false;
            this.gridViewQuyDinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewQuyDinh.Size = new System.Drawing.Size(604, 245);
            this.gridViewQuyDinh.TabIndex = 0;
            this.gridViewQuyDinh.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewQuyDinh_CellDoubleClick);
            this.gridViewQuyDinh.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridViewQuyDinh_RowStateChanged);
            // 
            // btnLuuQuyDinh
            // 
            this.btnLuuQuyDinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuQuyDinh.Enabled = false;
            this.btnLuuQuyDinh.Location = new System.Drawing.Point(538, 320);
            this.btnLuuQuyDinh.Name = "btnLuuQuyDinh";
            this.btnLuuQuyDinh.Size = new System.Drawing.Size(80, 27);
            this.btnLuuQuyDinh.TabIndex = 1;
            this.btnLuuQuyDinh.Text = "Lưu";
            this.btnLuuQuyDinh.UseVisualStyleBackColor = true;
            this.btnLuuQuyDinh.Click += new System.EventHandler(this.btnLuuQuyDinh_Click);
            // 
            // cbbTenQuyDinh
            // 
            this.cbbTenQuyDinh.BackColor = System.Drawing.Color.White;
            this.cbbTenQuyDinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenQuyDinh.FormattingEnabled = true;
            this.cbbTenQuyDinh.Location = new System.Drawing.Point(13, 30);
            this.cbbTenQuyDinh.Name = "cbbTenQuyDinh";
            this.cbbTenQuyDinh.Size = new System.Drawing.Size(305, 23);
            this.cbbTenQuyDinh.TabIndex = 3;
            this.cbbTenQuyDinh.TextChanged += new System.EventHandler(this.cbbMaQuyDinh_TextChanged);
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
            // btnSuaQuyDinh
            // 
            this.btnSuaQuyDinh.Location = new System.Drawing.Point(12, 320);
            this.btnSuaQuyDinh.Name = "btnSuaQuyDinh";
            this.btnSuaQuyDinh.Size = new System.Drawing.Size(75, 27);
            this.btnSuaQuyDinh.TabIndex = 6;
            this.btnSuaQuyDinh.Text = "Sửa";
            this.btnSuaQuyDinh.UseVisualStyleBackColor = true;
            this.btnSuaQuyDinh.Click += new System.EventHandler(this.btnSuaQuyDinh_Click);
            // 
            // QuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 357);
            this.Controls.Add(this.btnSuaQuyDinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbTenQuyDinh);
            this.Controls.Add(this.btnLuuQuyDinh);
            this.Controls.Add(this.gridViewQuyDinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuyDinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quy định";
            this.Load += new System.EventHandler(this.QuyDinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuyDinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewQuyDinh;
        private System.Windows.Forms.Button btnLuuQuyDinh;
        private System.Windows.Forms.ComboBox cbbTenQuyDinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuaQuyDinh;
    }
}
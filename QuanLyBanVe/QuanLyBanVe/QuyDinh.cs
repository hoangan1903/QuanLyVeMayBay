using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanVe
{
    public partial class QuyDinh : Form
    {
        BUS_QuyDinh busQuyDinh = new BUS_QuyDinh();
        public QuyDinh()
        {
            InitializeComponent();
        }

        private void QuyDinh_Load(object sender, EventArgs e)
        {
            cbbMaQuyDinh.DataSource = busQuyDinh.LoadMaQuyDinh();
            cbbMaQuyDinh.DisplayMember = "MaQuyDinh";
            cbbMaQuyDinh.ValueMember = "MaQuyDinh";
        }

        private void cbbMaQuyDinh_TextChanged(object sender, EventArgs e)
        {
            btnLuuQuyDinh.Enabled = false;

            string maQuyDinh = cbbMaQuyDinh.Text;
            gridViewQuyDinh.DataSource = busQuyDinh.LoadQuyDinh(maQuyDinh);
            gridViewQuyDinh.Columns[0].ReadOnly = true;
            gridViewQuyDinh.Columns[1].ReadOnly = true;
            gridViewQuyDinh.ClearSelection();
        }

        private void btnLuuQuyDinh_Click(object sender, EventArgs e)
        {
            string maQuyDinh = gridViewQuyDinh.Rows[0].Cells[0].Value.ToString();
            int giaTri = int.Parse(gridViewQuyDinh.Rows[0].Cells[2].Value.ToString());
            DateTime ngayApDung = Convert.ToDateTime(gridViewQuyDinh.Rows[0].Cells[3].Value.ToString());

            if (busQuyDinh.CapNhatQuyDinh(maQuyDinh, giaTri, ngayApDung))
                MessageBox.Show("Cập nhật quy định thành công.");
            else
                MessageBox.Show("Cập nhật quy định không thành công.");
        }

        private void gridViewQuyDinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnLuuQuyDinh.Enabled = true;
        }
    }
}
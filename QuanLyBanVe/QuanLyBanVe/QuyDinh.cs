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
            cbbTenQuyDinh.DataSource = busQuyDinh.LoadMaQuyDinh();
            cbbTenQuyDinh.DisplayMember = "TenQuyDinh";
            cbbTenQuyDinh.ValueMember = "TenQuyDinh";
            gridViewQuyDinh.Columns["NGAYAPDUNG"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void FormatDgv(DataGridView dgv)
        {
            for (int i = 0; i < 4; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i == 0)
                {
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Columns[i].HeaderCell.Value = String.Format("{0}", "Mã quy định");
                }
                else if (i == 1)
                {
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Columns[i].HeaderCell.Value = String.Format("{0}", "Tên quy định");
                }
                else if (i == 2)
                {
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns[i].HeaderCell.Value = String.Format("{0}", "Giá trị");
                }
                else
                {
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns[i].HeaderCell.Value = String.Format("{0}", "Ngày áp dụng");
                }
            }
            dgv.ClearSelection();
            dgv.Enabled = true;
        }

        private void cbbMaQuyDinh_TextChanged(object sender, EventArgs e)
        {
            btnLuuQuyDinh.Enabled = false;
            gridViewQuyDinh.DataSource = busQuyDinh.LoadQuyDinh(cbbTenQuyDinh.Text);
            FormatDgv(gridViewQuyDinh);
        }

        private void gridViewQuyDinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSuaQuyDinh_Click(sender, e);
        }

        private void btnLuuQuyDinh_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = gridViewQuyDinh.SelectedRows[0];
            string maQuyDinh = selectedRow.Cells[0].Value.ToString();
            int giaTri = int.Parse(selectedRow.Cells[2].Value.ToString());
            DateTime ngayApDung = Convert.ToDateTime(selectedRow.Cells[3].Value.ToString());

            if (busQuyDinh.CapNhatQuyDinh(maQuyDinh, giaTri, ngayApDung))
            {
                btnLuuQuyDinh.Enabled = false;
                gridViewQuyDinh.DataSource = busQuyDinh.LoadQuyDinh(cbbTenQuyDinh.Text);
                FormatDgv(gridViewQuyDinh);
                MessageBox.Show("Cập nhật quy định thành công.", "Cập nhật quy định");
            }
            else
                MessageBox.Show("Cập nhật quy định không thành công.", "Cập nhật quy định");

            gridViewQuyDinh.Enabled = true;
        }

        private void btnSuaQuyDinh_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = gridViewQuyDinh.SelectedRows[0];
            SuaQuyDinh formSuaQuyDinh = new SuaQuyDinh();
            formSuaQuyDinh.TenQuyDinh = selectedRow.Cells[1].Value.ToString();
            formSuaQuyDinh.ShowDialog();
            if (formSuaQuyDinh.InputIsValid)
            {
                gridViewQuyDinh.Enabled = false;
                selectedRow.Cells[2].Value = formSuaQuyDinh.GiaTri;
                selectedRow.Cells[3].Value = formSuaQuyDinh.NgayApDung.ToShortDateString();
                btnLuuQuyDinh.Enabled = true;
            }
        }

        private void gridViewQuyDinh_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (gridViewQuyDinh.SelectedRows.Count == 1)
            {
                btnSuaQuyDinh.Enabled = true;
            }
            else
            {
                btnSuaQuyDinh.Enabled = false;
            }
        }
    }
}
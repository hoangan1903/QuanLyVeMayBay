using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace QuanLyBanVe
{
    public partial class frmDanhSachKhachHang : Form
    {
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        public frmDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void frmDanhSachKhachHang_Load(object sender, EventArgs e)
        {
            dgvDanhSachKhachHang.RowHeadersVisible = false;
            dgvDanhSachKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDanhSachKhachHang.DataSource = busKhachHang.LoadKhachHang();
            dgvDanhSachKhachHang.ClearSelection();

            dgvDanhSachKhachHang_RenameColumn();
        }
        private void dgvDanhSachKhachHang_RenameColumn()
        {
            foreach (DataGridViewColumn col in dgvDanhSachKhachHang.Columns)
            {
                if (col == dgvDanhSachKhachHang.Columns["MAKH"])
                {
                    dgvDanhSachKhachHang.Columns["MAKH"].HeaderText = "Mã khách hàng";
                }
                else if (col == dgvDanhSachKhachHang.Columns["HOTEN"])
                {
                    dgvDanhSachKhachHang.Columns["HOTEN"].HeaderText = "Họ và tên";
                }
                else if (col == dgvDanhSachKhachHang.Columns["TUOI"])
                {
                    dgvDanhSachKhachHang.Columns["TUOI"].HeaderText = "Tuổi";
                }
                else if (col == dgvDanhSachKhachHang.Columns["GIOITINH"])
                {
                    dgvDanhSachKhachHang.Columns["GIOITINH"].HeaderText = "Nam";
                }
                else if (col == dgvDanhSachKhachHang.Columns["DIACHI"])
                {
                    dgvDanhSachKhachHang.Columns["DIACHI"].HeaderText = "Địa chỉ";
                }
                else if (col == dgvDanhSachKhachHang.Columns["SDT"])
                {
                    dgvDanhSachKhachHang.Columns["SDT"].HeaderText = "Số điện thoại";
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace QuanLyBanVe
{
    public partial class TaoThanhVien : Form
    {
        BUS_KhachHang busKhachHang = new BUS_KhachHang();

        public TaoThanhVien()
        {
            InitializeComponent();

        }

        private void btnTaoThanhVien_Click(object sender, EventArgs e)
        {
            bool gioiTinh = false;
            if (rbtnNam.Checked)
                gioiTinh = true;
            if (txtMaKH.Text == string.Empty)
                MessageBox.Show("Vui lòng nhập MAKH");
            else if (txtHoTen.Text == string.Empty)
                MessageBox.Show("Vui lòng nhập họ tên");
            else if (txtTuoi.Text == string.Empty)
                MessageBox.Show("Vui lòng nhập tuổi");
            else if (txtDiaChi.Text == string.Empty)
                MessageBox.Show("Vui lòng nhập địa chỉ");
            else if (!rbtnNam.Checked && !rbtnNu.Checked)
                MessageBox.Show("Vui lòng chọn giới tính");
            else if (busKhachHang.TaoThanhVien(txtMaKH.Text, txtHoTen.Text, txtTuoi.Text, gioiTinh, txtCMND.Text, txtDiaChi.Text, txtSDT.Text))
            {
                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                MessageBox.Show("Lưu thông tin không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}

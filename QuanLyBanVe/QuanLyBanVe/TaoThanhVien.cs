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

            if (txtSDT.Text != string.Empty)
                if (!KiemTraSDT(txtSDT.Text.Trim()))
                    MessageBox.Show("SĐT không hợp lệ");


            if (rbtnNam.Checked)
            {
                gioiTinh = true;
            }
            else if (txtHoTen.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập họ tên");
            }
            else if (txtNamSinh.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập năm sinh");
            }
            else if (!KiemTraNamSinh(txtNamSinh.Text.Trim()))
            {
                MessageBox.Show("Năm sinh không hợp lệ");
            }
            else if (txtCMND.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập CMND/Căn cước");
            }
            else if (!KiemTraCMND(txtCMND.Text.Trim()))
            {
                MessageBox.Show("CMND không hợp lệ");
            }
            else if (txtDiaChi.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ");
            }
            else if (!rbtnNam.Checked && !rbtnNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
            }
            else if (busKhachHang.TaoThanhVien(string.Empty, txtHoTen.Text, txtNamSinh.Text, gioiTinh, txtCMND.Text, txtDiaChi.Text, txtSDT.Text))
            {
                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                MessageBox.Show("Lưu thông tin không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private bool KiemTraNamSinh(string year)
        {
            int count = 0;

            foreach (char num in year)
            {
                if ((int)num < 48 || (int)num > 57)
                    return false;
                else
                    count++;
            }

            if (count > 4)
                return false;
            return true;
        }

        private bool KiemTraSDT(string phoneNumber)
        {
            int count = 0;

            foreach (char num in phoneNumber)
            {
                if ((int)num < 48 || (int)num > 57)
                    return false;
                else
                    count++;
            }

            if (count != 11 && count != 10)
                return false;
            return true;
        }

        private bool KiemTraCMND(string ID)
        {
            int count = 0;

            foreach (char num in ID)
            {
                if ((int)num < 48 || (int)num > 57)
                    return false;
                else
                    count++;
            }

            if (count != 9 && count != 12)
                return false;
            return true;
        }
    }

}

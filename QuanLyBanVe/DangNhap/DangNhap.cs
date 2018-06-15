using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class DangNhap : Form
    {

        public static DialogResult loginResult;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "admin" && txtMatKhau.Text == "admin")
            {
                loginResult = DialogResult.Yes;
                DAO.Connect.connection = new SqlConnection("Data Source=" + txtServerName.Text + ";Initial Catalog=QLVeMayBay;Integrated Security=True");
            }
            else
            {
                loginResult = DialogResult.Retry;
                MessageBox.Show("Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.", "Đăng nhập không thành công");
                txtTenDangNhap.Focus();
            }
            Close();
        }
    }
}

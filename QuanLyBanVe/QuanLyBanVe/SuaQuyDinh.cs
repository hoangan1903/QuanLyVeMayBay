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
    public partial class SuaQuyDinh : Form
    {
        public bool InputIsValid { get; private set; }
        public string TenQuyDinh { get; set; }
        public int GiaTri { get; private set; }
        public DateTime NgayApDung { get; private set; }

        public SuaQuyDinh()
        {
            InitializeComponent();
            InputIsValid = false;
        }

        private void SuaQuyDinh_Load(object sender, EventArgs e)
        {
            tbTenQuyDinh.Text = TenQuyDinh;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GiaTri = int.Parse(tbGiaTri.Text);
                NgayApDung = dtpNgayApDung.Value;
                InputIsValid = true;
                this.Close();
            }
            catch
            {
                InputIsValid = false;
                MessageBox.Show("Giá trị không hợp lệ.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InputIsValid = false;
            this.Close();
        }
    }
}
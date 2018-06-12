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

namespace InVe
{
    public partial class frmInVe : Form
    {
        BUS_Ve busVe = new BUS_Ve();
        public frmInVe()
        {
            InitializeComponent();
        }

        private void InVe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLVeMayBayDataSet_3.InVe' table. You can move, or remove it, as needed.
            //this.InVeTableAdapter.Fill(this.QLVeMayBayDataSet_3.InVe);
            cbbMaVe.DataSource = busVe.LoadMaVe();
            cbbMaVe.ValueMember = "MAVE";
            cbbMaVe.DisplayMember = "MAVE";
            cbbMaVe.Text = null;
            //this.reportViewer1.RefreshReport();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbbMaVe.Text != string.Empty)
            {
                this.reportViewer1.Clear();

                busVe.InVe(cbbMaVe.Text).Fill(this.QLVeMayBayDataSet_3.InVe);

                this.reportViewer1.RefreshReport();
            }
            else
                MessageBox.Show("Vui lòng nhập mã vé!", "Thông báo", MessageBoxButtons.OK);
        }
    }
}

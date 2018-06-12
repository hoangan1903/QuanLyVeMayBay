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
        string maVe;
        public frmInVe(string maVe)
        {
            InitializeComponent();
            this.maVe = maVe;
        }

        private void InVe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLVeMayBayDataSet_3.InVe' table. You can move, or remove it, as needed.
            //this.InVeTableAdapter.Fill(this.QLVeMayBayDataSet_3.InVe);
            //this.reportViewer1.RefreshReport();
            busVe.InVe(maVe).Fill(this.QLVeMayBayDataSet_3.InVe);
            this.reportViewer1.RefreshReport();
        }
    }
}

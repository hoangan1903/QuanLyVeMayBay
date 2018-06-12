using Microsoft.Reporting.WinForms;
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
using BUS;

namespace BaoCaoNam
{
    public partial class BaoCaoNam : Form
    {
        public BaoCaoNam()
        {
            InitializeComponent();
        }

        private void BaoCaoNam_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLVeMayBayDataSet_2.BaoCaoNam' table. You can move, or remove it, as needed.
           // this.BaoCaoNamTableAdapter.Fill(this.QLVeMayBayDataSet_2.BaoCaoNam);

           // this.reportViewer1.RefreshReport();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BUS_BaoCao busBaoCao = new BUS_BaoCao();
            this.reportViewer1.Clear();
            this.QLVeMayBayDataSet_2.BaoCaoNam.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-260M5KJ; Initial Catalog=QLVeMayBay; Integrated Security=True"))
                {
                    busBaoCao.BaoCaoNam(cbbNam.Text).Fill(this.QLVeMayBayDataSet_2.BaoCaoNam);

                    object sum;
                    DataTable datb = this.QLVeMayBayDataSet_2.Tables[0];
                    sum = datb.Compute("Sum(DOANHTHU)", string.Empty);

                    ReportParameter ParameterNam = new ReportParameter("ParameterNam", Text = cbbNam.Text);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ParameterNam });

                    ReportParameter ParameterSum = new ReportParameter("ParameterSum", Text = sum.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ParameterSum });
                }
            }
            catch { }
            this.reportViewer1.RefreshReport();
            btnThongKe.Enabled = false;
        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThongKe.Enabled = true;
        }
    }
}

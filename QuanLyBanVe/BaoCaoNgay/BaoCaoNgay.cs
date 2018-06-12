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
using Microsoft.Reporting.WinForms;
using BUS;
namespace BaoCaoNgay
{
    public partial class BaoCaoNgay : Form
    {
        
        public BaoCaoNgay()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLVeMayBayDataSet.BaoCao' table. You can move, or remove it, as needed.
            //this.BaoCaoTableAdapter.Fill(this.QLVeMayBayDataSet.BaoCao);
            //this.reportViewer1.RefreshReport();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BUS_BaoCao busBaoCao = new BUS_BaoCao();
            this.reportViewer1.Clear();
            this.QLVeMayBayDataSet.BaoCao.Clear();
            try
            {
                busBaoCao.BaoCaoNgay(dateDi.Value, dateDen.Value).Fill(this.QLVeMayBayDataSet.BaoCao); // Gốc: Convert.ToDateTime(...)

                object sum;
                DataTable datb = this.QLVeMayBayDataSet.Tables[0];
                sum = datb.Compute("Sum(DOANHTHU)", string.Empty);

                ReportParameter ParameterDateDi = new ReportParameter("ParameterDateDi", Text = dateDi.Text);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ParameterDateDi });

                ReportParameter ParameterDateDen = new ReportParameter("ParameterDateDen", Text = dateDen.Text);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ParameterDateDen });

                ReportParameter ParameterSum = new ReportParameter("ParameterSum", Text = sum.ToString());
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ParameterSum });
            }
            catch (Exception)
            {

            }
            this.reportViewer1.RefreshReport();
            btnThongKe.Enabled = false;
        }

        private void dateDi_ValueChanged(object sender, EventArgs e)
        {
            btnThongKe.Enabled = true;
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            btnThongKe.Enabled = true;
        }
    }
}

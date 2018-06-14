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
using InVe;

namespace QuanLyBanVe
{
    public partial class BanVe : Form
    {
        BUS_Ve busVe = new BUS_Ve();
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        BUS_PhieuDatMua busPhieuDatMua = new BUS_PhieuDatMua();

        private string maCB;
        private string maVe;

        public BanVe(string MaCB)
        {
            InitializeComponent();
            this.maCB = MaCB;
        }

        private void BanVe_Load(object sender, EventArgs e)
        {
            gridViewVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridViewVe.DataSource = busVe.LietKeVe(this.maCB);
        }

        private void cboHangVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboHangVe.SelectedItem.ToString() == "Hạng 1")
                {
                    gridViewVe.DataSource = busVe.ChonHangVe("HV001", this.maCB);

                    int demVeDaBan = 0;

                    for (int i = 0; i < gridViewVe.Rows.Count; i++)
                    {
                        if (gridViewVe["TÌNH TRẠNG", i].Value.ToString() == "Còn trống")
                            break;
                        else
                            demVeDaBan++;
                    }

                    if (demVeDaBan == gridViewVe.Rows.Count)
                    {
                        MessageBox.Show("Tất cả các vé hạng 1 đã được đặt/mua.", "Thông báo", MessageBoxButtons.OK);
                        gridViewVe.DataSource = busVe.LietKeVe(this.maCB);
                    }
                }
                else if (cboHangVe.SelectedItem.ToString() == "Hạng 2")
                {
                    gridViewVe.DataSource = busVe.ChonHangVe("HV002", this.maCB);

                    int demVeDaBan = 0;

                    for (int i = 0; i < gridViewVe.Rows.Count; i++)
                    {
                        if (gridViewVe["TÌNH TRẠNG", i].Value.ToString() == "Còn trống")
                            break;
                        else
                            demVeDaBan++;
                    }

                    if (demVeDaBan == gridViewVe.Rows.Count)
                    {
                        MessageBox.Show("Tất cả các vé hạng 2 đã được đặt/mua.", "Thông báo", MessageBoxButtons.OK);
                        gridViewVe.DataSource = busVe.LietKeVe(this.maCB);
                    }
                }
                else if (cboHangVe.SelectedItem.ToString() == "Tất cả")
                {
                    gridViewVe.DataSource = busVe.LietKeVe(this.maCB);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhanMua_Click(object sender, EventArgs e)
        {
            BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
            TimeSpan timeSpan = DateTime.Parse(busChuyenBay.ChiTietCB(maCB).Rows[0][4].ToString()) - DateTime.Now;
            if(timeSpan.Days <= 1)
            {
                MessageBox.Show("Đã quá thời gian mua vé cho chuyến bay này", "Thông báo", MessageBoxButtons.OK);
            }
            else if (txtCMND.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin của khách hàng !", "Nhắc nhở", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Vui lòng kiểm tra thông tin của khách đã đúng hay chưa.", "Nhắc nhở", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dt = busKhachHang.LoadKhachHang(txtCMND.Text.Trim());
                    int demVe = 0;

                    for (int i = 0; i < gridViewVe.Rows.Count; ++i)
                    {
                        if (gridViewVe[0, i].Selected)
                        {
                            // Kiểm tra vé đã bán hay chưa
                            if (gridViewVe["TÌNH TRẠNG", i].Value.ToString().Trim() != "Còn trống")
                            {
                                MessageBox.Show("Vé này đã được đặt/mua. Hãy chọn lại một vé khác.", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if (busVe.CapNhatVe(gridViewVe["MAVE", i].Value.ToString(), "TT001"))
                                {
                                    DataRow KH = dt.Rows[dt.Rows.Count - 1];

                                    if (busPhieuDatMua.TaoPhieuDatMua(gridViewVe[0, i].Value.ToString(), KH["MAKH"].ToString(), DateTime.Now, true))
                                    {
                                        this.maVe = gridViewVe["MAVE", i].Value.ToString();
                                        MessageBox.Show("Bán vé thành công !", "Thông báo", MessageBoxButtons.OK);
                                        gridViewVe.DataSource = busVe.LietKeVe(this.maCB);
                                        demVe++;
                                    }
                                }
                            }

                        }
                    }
                    if (demVe == 0)
                        MessageBox.Show("Không có vé nào được chọn. Vui lòng chọn 01 vé.", "Cảnh báo", MessageBoxButtons.OK);
                }
            }
            btnInVe.Enabled = true;
        }


        private void btnXacNhanDat_Click(object sender, EventArgs e)
        {
            BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
            TimeSpan timeSpan = DateTime.Parse(busChuyenBay.ChiTietCB(maCB).Rows[0][4].ToString()) - DateTime.Now;
            if (timeSpan.Days <= 1)
            {
                MessageBox.Show("Đã quá thời gian đặt vé cho chuyến bay này", "Thông báo", MessageBoxButtons.OK);
            }
            else if (txtCMND.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin của khách hàng !", "Nhắc nhở", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Vui lòng kiểm tra thông tin của khách đã đúng hay chưa.", "Nhắc nhở", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dt = busKhachHang.LoadKhachHang(txtCMND.Text.Trim());
                    int demVe = 0;

                    for (int i = 0; i < gridViewVe.Rows.Count; ++i)
                    {
                        if (gridViewVe[0, i].Selected)
                        {
                            // Kiểm tra vé đã đặt hay chưa
                            if (gridViewVe["TÌNH TRẠNG", i].Value.ToString().Trim() != "Còn trống")
                            {
                                MessageBox.Show("Vé này đã được đặt/mua. Hãy chọn lại một vé khác.", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if (busVe.CapNhatVe(gridViewVe["MAVE", i].Value.ToString(), "TT002"))
                                {
                                    DataRow KH = dt.Rows[dt.Rows.Count - 1];

                                    if (busPhieuDatMua.TaoPhieuDatMua(gridViewVe[0, i].Value.ToString(), KH["MAKH"].ToString(), DateTime.Now, false))
                                    {
                                        MessageBox.Show("Đặt vé thành công !", "Thông báo", MessageBoxButtons.OK);
                                        gridViewVe.DataSource = busVe.LietKeVe(this.maCB);

                                        demVe++;
                                    }
                                }
                            }
                        }
                    }
                    if (demVe == 0)
                        MessageBox.Show("Không có vé nào được chọn. Vui lòng chọn 01 vé.", "Cảnh báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (KiemTraCMND(txtCMND.Text.Trim()))
            {
                DataTable dt = busKhachHang.LoadKhachHang(txtCMND.Text.Trim(), txtHoTen.Text.Trim());

                // Kiểm tra khách hàng đã là thành viên hay chưa
                if (dt.Rows.Count != 0)
                    MessageBox.Show("Đã là thành viên", "Kết quả kiểm tra", MessageBoxButtons.OK);
                else
                {
                    MessageBox.Show("Chưa là thành viên! Vui lòng nhập thông tin!", "Kết quả kiểm tra", MessageBoxButtons.OK);
                    TaoThanhVien ttv = new TaoThanhVien();
                    ttv.ShowDialog();
                }
            }
            else
                MessageBox.Show("CMND không hợp lệ");
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
        private void btnInVe_Click(object sender, EventArgs e)
        {
            frmInVe frmInVe = new frmInVe(this.maVe);
            frmInVe.ShowDialog();
        }
    }
}

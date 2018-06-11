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
using BaoCaoNam;
using BUS;

namespace QuanLyBanVe
{
    public partial class QuanLyBanVe : Form
    {
        BUS_Ve busVe = new BUS_Ve();
        BUS_SanBay busSanBay = new BUS_SanBay();
        BUS_HHK busHHK = new BUS_HHK();
        BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();

        private List<DataGridViewRow> addedRows = new List<DataGridViewRow>();
        private List<DataGridViewRow> modifiedRows = new List<DataGridViewRow>();
        private List<DataGridViewRow> removedRows = new List<DataGridViewRow>();
        private List<string> errors = new List<string>();
        private DataGridViewRow duplicate;
        private Point panel1_MouseDownLocation;

        // Màu sắc
        private Color AddedRowColor
        {
            get { return Color.LawnGreen; }
        }
        private Color ModifiedRowColor
        {
            get { return Color.Gold; }
        }
        private Color RemovedRowColor
        {
            get { return Color.LightSalmon; }
        }
        private Color ChangeLogColor
        {
            get { return Color.Black; }
        }

        // Text
        private string ErrorText { get; set; } = "";
        private string ChangeLog { get; set; } = "";


        #region Chuyen tu QuanLy sang

        private DataGridViewRow FindRowInDataGridView(DataGridView dgv, string keyword, DataGridViewRow exceptionRow)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow && row != exceptionRow && row.Cells[0].Value.ToString() == keyword)
                {
                    return row;
                }
            }
            return null;
        }

        private bool CheckAffectedRows(DataGridView dgv)
        {
            bool saveSuccess = true;
            foreach (DataGridViewRow row in addedRows)
            {
                string rowNumber = "Hàng " + (row.Index + 1).ToString() + "\n";
                string MACB = row.Cells[0].Value.ToString();
                if (MACB == "")
                {
                    saveSuccess = false;
                    string error = rowNumber + "Không thể thêm bản ghi mới: MACB (khóa chính) bị bỏ trống.";
                    errors.Add(error);
                }
                else
                {
                    DataGridViewRow existingRow = FindRowInDataGridView(dgv, MACB, row);
                    if (existingRow != null)
                    {
                        saveSuccess = false;
                        string error = rowNumber + "Không thể thêm bản ghi mới: Đã tồn tại bản ghi có MACB = '" + row.Cells[0].Value.ToString() + "' trong CSDL (hàng " + (existingRow.Index + 1).ToString() + ").";
                        errors.Add(error);
                    }
                }
                for (int i = 1; i < 9; i++)
                {
                    if (row.Cells[i].Value.ToString() == "")
                    {
                        saveSuccess = false;
                        string error = rowNumber + "Không thể thêm bản ghi mới: Có ít nhất một trường bị bỏ trống.";
                        errors.Add(error);
                        break;
                    }
                }
            }
            foreach (DataGridViewRow row in modifiedRows)
            {
                string rowNumber = "Hàng " + (row.Index + 1).ToString() + "\n";
                for (int i = 1; i < 9; i++)
                {
                    if (row.Cells[i].Value.ToString() == "")
                    {
                        saveSuccess = false;
                        string error = rowNumber + "Không thể sửa bản ghi: Có ít nhất một trường bị bỏ trống.";
                        errors.Add(error);
                        break;
                    }
                }
            }
            if (saveSuccess)
            {
                // The following code block (inside 'if') is previously from the function WriteChangeLog(), which was deleted.
                ChangeLog = "Cập nhật bảng [CHUYENBAY] thành công - ";
                ChangeLog += (addedRows.Count + modifiedRows.Count + removedRows.Count).ToString() + " thay đổi đã được lưu (";
                ChangeLog += "thêm " + addedRows.Count.ToString() + " hàng, sửa " + modifiedRows.Count.ToString() + " hàng và xóa " + removedRows.Count.ToString() + " hàng).";
                if (addedRows.Count != 0 || modifiedRows.Count != 0 || removedRows.Count != 0)
                {
                    ChangeLog += "\nCác thay đổi:\n";
                    foreach (DataGridViewRow row in addedRows)
                    {
                        ChangeLog += "* Đã thêm bản ghi có MACB = '" + row.Cells[0].Value.ToString() + "'.\n";
                    }
                    foreach (DataGridViewRow row in modifiedRows)
                    {
                        ChangeLog += "* Đã sửa bản ghi có MACB = '" + row.Cells[0].Value.ToString() + "'.\n";
                    }
                    foreach (DataGridViewRow row in removedRows)
                    {
                        ChangeLog += "* Đã xóa bản ghi có MACB = '" + row.Cells[0].Value.ToString() + "'.\n";
                    }
                }
            }
            else
            {
                // The following code block (inside 'else') is previously from the function WriteErrorText(), which was deleted.
                ErrorText = "Cập nhật bảng [CHUYENBAY] không thành công - Không có thay đổi nào được lưu.\n";
                ErrorText += errors.Count.ToString() + " lỗi đã xảy ra:\n";
                foreach (string error in errors)
                {
                    ErrorText += "* " + error + "\n";
                }
            }
            return saveSuccess;
        }

        private bool OkToCopy(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ColumnIndex == 0)
                    continue;
                if (string.Empty == cell.Value.ToString())
                    return false;
            }
            return true;
        }

        #endregion

        public QuanLyBanVe()
        {
            InitializeComponent();
        }
        private void LoadDataToDataGridView(DataGridView gridViewLichCB)
        {
            gridViewLichCB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            gridViewLichCB.DataSource = busChuyenBay.GetChuyenBay();

            foreach (DataGridViewColumn column in gridViewLichCB.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in gridViewLichCB.Rows)
            {
                row.Cells[0].Style.ForeColor = Color.DarkRed;
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
            gridViewLichCB.Columns["THỜI GIAN KHỞI HÀNH"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            gridViewLichCB.Columns["THỜI GIAN ĐẾN"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            gridViewLichCB.ClearSelection();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView(gridViewLichCB);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbTaoThanhVien_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TaoThanhVien taoThanhVien = new TaoThanhVien();
            taoThanhVien.ShowDialog();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (gridViewLichCB.SelectedRows.Count != 0)
                btnXoa.Enabled = true;
            else btnXoa.Enabled = false;

            if (gridViewLichCB.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = gridViewLichCB.SelectedRows[0];
                if (selectedRow.DefaultCellStyle.BackColor == AddedRowColor || selectedRow.DefaultCellStyle.BackColor == ModifiedRowColor)
                    btnSua.Enabled = true;
                else if (selectedRow.DefaultCellStyle.BackColor == RemovedRowColor)
                    btnSua.Enabled = false;
                else btnSua.Enabled = true;
            }
            else btnSua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)gridViewLichCB.DataSource;
            table.Rows.Add(table.NewRow());
            gridViewLichCB.DataSource = table;

            DataGridViewRow newRow = gridViewLichCB.Rows[gridViewLichCB.Rows.Count - 1];
            newRow.HeaderCell.Value = String.Format("{0}", newRow.Index + 1);

            addedRows.Add(newRow);
            newRow.DefaultCellStyle.BackColor = AddedRowColor;
            gridViewLichCB.ClearSelection();
            newRow.Selected = true;

            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow rowToModify = gridViewLichCB.SelectedRows[0];
            splitContainer1.Panel1.Enabled = false;

            if (string.Empty != rowToModify.Cells[0].Value.ToString())
                tbMaCB.Text = rowToModify.Cells[0].Value.ToString();
            else
                tbMaCB.Text = string.Empty;
            if (rowToModify.DefaultCellStyle.BackColor == AddedRowColor)
            {
                tbMaCB.Enabled = true;
            }
            else
                tbMaCB.Enabled = false;

            cbbMaSBDi.DataSource = busSanBay.LoadSanBay();
            cbbMaSBDi.DisplayMember = "TENSANBAY";
            cbbMaSBDi.ValueMember = "TENSANBAY";
            cbbMaSBDi.Text = rowToModify.Cells[1].Value.ToString();

            cbbMaSBDen.DataSource = busSanBay.LoadSanBay();
            cbbMaSBDen.DisplayMember = "TENSANBAY";
            cbbMaSBDen.ValueMember = "TENSANBAY";
            cbbMaSBDen.Text = rowToModify.Cells[2].Value.ToString();

            cbbHHK.DataSource = busHHK.LoadHangHangKhong();
            cbbHHK.DisplayMember = "TENHHK";
            cbbHHK.ValueMember = "TENHHK";
            cbbHHK.Text = rowToModify.Cells[3].Value.ToString();

            departureTime.Text = rowToModify.Cells[4].Value.ToString();
            arrivalTime.Text = rowToModify.Cells[5].Value.ToString();
            tbSoGheHang1.Text = rowToModify.Cells[6].Value.ToString();
            tbSoGheHang2.Text = rowToModify.Cells[7].Value.ToString();
            tbGiaVe.Text = rowToModify.Cells[8].Value.ToString();

            panel1.Location = new Point(splitContainer1.Panel2.Size.Width - panel1.Size.Width - 18, 0);
            panel1.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridViewLichCB.SelectedRows)
            {
                if (row.DefaultCellStyle.BackColor != RemovedRowColor)
                {
                    row.ReadOnly = true;
                    if (row.DefaultCellStyle.BackColor == AddedRowColor)
                    {
                        row.DefaultCellStyle.BackColor = RemovedRowColor;
                        addedRows.Remove(row);
                        continue;
                    }
                    if (row.DefaultCellStyle.BackColor == ModifiedRowColor)
                    {
                        removedRows.Add(row);
                        row.DefaultCellStyle.BackColor = RemovedRowColor;
                        modifiedRows.Remove(row);
                        continue;
                    }
                    removedRows.Add(row);
                    row.DefaultCellStyle.BackColor = RemovedRowColor;
                }
            }
            gridViewLichCB.ClearSelection();
            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.Enabled = false;
            if (!CheckAffectedRows(gridViewLichCB))
            {
                /* Show error(s) to the user */
                MessageBox.Show("Có lỗi khi cập nhật dữ liệu vào CDSL. Vui lòng kiểm tra lại các thay đổi của bạn.", "Cập nhật không thành công");
                lblUpdateStatus.ForeColor = Color.Red;
                lblUpdateStatus.Text = ErrorText;
                errors.Clear();
            }
            else
            {
                /* Save the changes */
                btnCancelChanges.Enabled = false;

                foreach (DataGridViewRow row in addedRows)
                {
                    if (!busChuyenBay.ThemChuyenBay(row))
                        MessageBox.Show("Có lỗi không xác định xảy ra khi thêm chuyến bay '" + row.Cells[0].Value.ToString() + "'.");
                }

                foreach (DataGridViewRow row in modifiedRows)
                {
                    if (!busChuyenBay.SuaChuyenBay(row))
                        MessageBox.Show("Có lỗi không xác định xảy ra khi cập nhật dữ liệu của chuyến bay '" + row.Cells[0].Value.ToString() + "'.");
                }

                foreach (DataGridViewRow row in removedRows)
                {
                    if (!busChuyenBay.XoaChuyenBay(row))
                        MessageBox.Show("Có lỗi không xác định xảy ra khi cập nhật dữ liệu của chuyến bay '" + row.Cells[0].Value.ToString() + "'.");
                }
                lblUpdateStatus.ForeColor = ChangeLogColor;
                lblUpdateStatus.Text = ChangeLog;
                addedRows.Clear();
                modifiedRows.Clear();
                removedRows.Clear();
                LoadDataToDataGridView(gridViewLichCB);
            }
        }
        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnCancelChanges.Enabled = false;
            addedRows.Clear();
            modifiedRows.Clear();
            removedRows.Clear();
            LoadDataToDataGridView(gridViewLichCB);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DataGridViewRow modifiedRow = gridViewLichCB.SelectedRows[0];
            if (modifiedRow.DefaultCellStyle.BackColor != AddedRowColor &&
                modifiedRow.DefaultCellStyle.BackColor != ModifiedRowColor)
            {
                modifiedRows.Add(modifiedRow);
                modifiedRow.DefaultCellStyle.BackColor = ModifiedRowColor;
            }

            if (modifiedRow.DefaultCellStyle.BackColor == AddedRowColor)
                modifiedRow.Cells[0].Value = tbMaCB.Text;
            modifiedRow.Cells[1].Value = cbbMaSBDi.Text;
            modifiedRow.Cells[2].Value = cbbMaSBDen.Text;
            modifiedRow.Cells[3].Value = cbbHHK.Text;
            modifiedRow.Cells[4].Value = DateTime.ParseExact(departureTime.Text, "dd/MM/yyyy HH:mm", null);
            modifiedRow.Cells[5].Value = DateTime.ParseExact(arrivalTime.Text, "dd/MM/yyyy HH:mm", null);

            if (tbSoGheHang1.Text != string.Empty)
                modifiedRow.Cells[6].Value = tbSoGheHang1.Text;
            else modifiedRow.Cells[6].Value = 0;

            if (tbSoGheHang2.Text != string.Empty)
                modifiedRow.Cells[7].Value = tbSoGheHang2.Text;
            else modifiedRow.Cells[7].Value = 0;

            if (tbGiaVe.Text != string.Empty)
                modifiedRow.Cells[8].Value = tbGiaVe.Text;
            else modifiedRow.Cells[8].Value = 0;

            panel1.Visible = false;
            splitContainer1.Panel1.Enabled = true;
            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            splitContainer1.Panel1.Enabled = true;
        }

        /* cellContextMenuStrip1 */
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridViewLichCB.ClearSelection();
                DataGridViewRow clickedRow = gridViewLichCB.Rows[e.RowIndex];
                clickedRow.Selected = true;
                /* Determine whether modifyCellToolStripMenuItem can be enabled */
                if (clickedRow.DefaultCellStyle.BackColor == AddedRowColor || clickedRow.DefaultCellStyle.BackColor == ModifiedRowColor)
                {
                    modifyToolStripMenuItem.Enabled = true;
                }
                else if (clickedRow.DefaultCellStyle.BackColor == RemovedRowColor)
                {
                    modifyToolStripMenuItem.Enabled = false;
                }
                else modifyToolStripMenuItem.Enabled = true;
                /* Determine whether copyRowToolStripMenuItem can be enabled */
                if (OkToCopy(clickedRow))
                {
                    copyToolStripMenuItem.Enabled = true;
                }
                else
                {
                    copyToolStripMenuItem.Enabled = false;
                }
                /* Determine whether pasteRowToolStripMenuItem can be enabled */
                if (duplicate != null && clickedRow.DefaultCellStyle.BackColor != RemovedRowColor)
                {
                    pasteToolStripMenuItem.Enabled = true;
                }
                else
                {
                    pasteToolStripMenuItem.Enabled = false;
                }
                rowContextMenuStrip1.Show(MousePosition);
            }
        }
        private void gridViewLichCB_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewLichCB.SelectedRows.Count != 0)
                btnSua_Click(sender, e);
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow rowToCopy = gridViewLichCB.SelectedRows[0];
            duplicate = (DataGridViewRow)rowToCopy.Clone();
            for (int i = 0; i < 9; i++)
            {
                duplicate.Cells[i].Value = rowToCopy.Cells[i].Value;
            }
            lblUpdateStatus.ForeColor = ChangeLogColor;
            lblUpdateStatus.Text = "Đã sao chép hàng " + (rowToCopy.Index + 1).ToString() + " (MACB = '" + rowToCopy.Cells[0].Value.ToString() + "').";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow modifiedRow = gridViewLichCB.SelectedRows[0];
            if (modifiedRow.DefaultCellStyle.BackColor != AddedRowColor &&
                modifiedRow.DefaultCellStyle.BackColor != ModifiedRowColor)
            {
                modifiedRows.Add(modifiedRow);
                modifiedRow.DefaultCellStyle.BackColor = ModifiedRowColor;
            }
            for (int i = 0; i < 9; i++)
            {
                if (i == 0 && modifiedRow.DefaultCellStyle.BackColor != AddedRowColor)
                    continue;
                modifiedRow.Cells[i].Value = duplicate.Cells[i].Value;
            }
            gridViewLichCB.ClearSelection();
            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        /* contextMenuStrip1 */
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                saveToolStripMenuItem.Enabled = btnSave.Enabled;
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCancelChanges_Click(sender, e);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridViewLichCB.SelectAll();
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridViewLichCB.ClearSelection();
        }

        private void QuanLyBanVe_KeyDown(object sender, KeyEventArgs e)
        {
            if (panel1.Visible && e.KeyCode == Keys.Escape)
            {
                panel1.Visible = false;
                splitContainer1.Panel1.Enabled = true;
                e.SuppressKeyPress = true;
            }
            else if (gridViewLichCB.SelectedRows.Count != 0 && e.KeyCode == Keys.Delete)
            {
                btnXoa_Click(sender, e);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel1_MouseDownLocation = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int left = e.X + panel1.Left - panel1_MouseDownLocation.X;
                if (left >= 0 && left <= splitContainer1.Panel2.Size.Width - panel1.Size.Width - 18)
                    panel1.Left = left;
                else if (left < 0)
                    panel1.Left = 0;
                else
                    panel1.Left = splitContainer1.Panel2.Size.Width - panel1.Size.Width - 18;

                int top = e.Y + panel1.Top - panel1_MouseDownLocation.Y;
                if (top >= 0 && top <= splitContainer1.Panel2.Size.Height - panel1.Size.Height)
                    panel1.Top = top;
                else if (top < 0)
                    panel1.Top = 0;
                else
                    panel1.Top = splitContainer1.Panel2.Size.Height - panel1.Size.Height;
            }
        }

        /// <summary>
        /// 
        /// Tất cả phần dưới đã chuyển qua 3 lớp
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /* dataGridView2 */
        //private void cbbNoiDi_DropDown(object sender, EventArgs e)
        //{
        //    QuanLy.LoadSanBay(cbbNoiDi);
        //}
        //private void cbbNoiDen_DropDown(object sender, EventArgs e)
        //{
        //    QuanLy.LoadSanBay(cbbNoiDen);
        //}
        private void gridViewCapNhatVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThanhToan.Enabled = true;
            btnHoanVe.Enabled = true;
        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            //if (cbbNoiDen.Text == cbbNoiDi.Text)
            //{
            //    MessageBox.Show("Không thể tra cứu");
            //}
            //else
            //{
            //    QuanLy.TraCuu(gridViewTraCuu, cbbNoiDi, cbbNoiDen, dateTraCuu);
            //}

            if (cbbNoiDen.Text == cbbNoiDi.Text || cbbNoiDi.Text == null || cbbNoiDen.Text == null)
            {
                MessageBox.Show("Không thể tra cứu");
            }
            else
            {
                gridViewTraCuu.DataSource = busChuyenBay.TraCuu(cbbNoiDi.Text, cbbNoiDen.Text, dateTraCuu.Value);
                gridViewTraCuu.RowHeadersVisible = false;
                gridViewTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridViewTraCuu.Columns["THỜI GIAN KHỞI HÀNH"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                gridViewTraCuu.Columns["THỜI GIAN ĐẾN"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                gridViewTraCuu.ClearSelection();
            }
        }

        private void gridViewTraCuu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnBanVe2.Enabled = true;
            //QuanLy.ChiTietChuyenBay(gridViewChiTiet, getMaCB(gridViewTraCuu));

            btnBanVe2.Enabled = true;
            gridViewChiTiet.DataSource = busChuyenBay.ChiTietCB(getMaCB(gridViewTraCuu));

            gridViewChiTiet.RowHeadersVisible = false;
            gridViewChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (busVe.DemVeHang1(getMaCB(gridViewTraCuu)).Rows.Count != 0)
                gridViewChiTiet.Rows[0].Cells[8].Value = busVe.DemVeHang1(getMaCB(gridViewTraCuu)).Rows[0][0].ToString();
            if(busVe.DemVeHang2(getMaCB(gridViewTraCuu)).Rows.Count !=0)
                gridViewChiTiet.Rows[0].Cells[9].Value = busVe.DemVeHang2(getMaCB(gridViewTraCuu)).Rows[0][0].ToString();

            gridViewChiTiet.Columns["THỜI GIAN KHỞI HÀNH"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            gridViewChiTiet.Columns["THỜI GIAN ĐẾN"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

        }

        private void btnBanVe2_Click(object sender, EventArgs e)
        {          
            BanVe formBanVe = new BanVe(getMaCB(gridViewTraCuu));
            formBanVe.ShowDialog();
        }

        private string getMaCB(DataGridView dataGridView1)
        {
            return dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hti = ((DataGridView)sender).HitTest(e.X, e.Y);
                if (hti.Type == DataGridViewHitTestType.Cell)
                {
                    contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
                    gridViewTraCuu.ClearSelection();
                    gridViewTraCuu.Rows[hti.RowIndex].Selected = true;
                }
            }
        }
        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bánVéToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnBanVe2_Click(sender, e);
        }

        private void làmMớiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnTraCuu_Click(sender, e);
        }

        private void báoCáoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BaoCaoNgay.BaoCaoNgay baoCaoNgay = new BaoCaoNgay.BaoCaoNgay();
            baoCaoNgay.Show();
        }

        private void báoCáoNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoNam.BaoCaoNam baoCaoNam = new BaoCaoNam.BaoCaoNam();
            baoCaoNam.Show();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //QuanLy.CapNhatVe(gridViewCapNhatVe, cbbMaCB, cbbMaVe);
            gridViewCapNhatVe.RowHeadersVisible = false;
            gridViewCapNhatVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridViewCapNhatVe.DataSource = busVe.LoadVeCapNhat(cbbMaCB.Text, cbbMaVe.Text);
            gridViewCapNhatVe.ClearSelection();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //QuanLy.LoadDuLieu(cbbMaCB, cbbMaVe);
            cbbMaVe.DataSource = busVe.LoadMaVe();
            cbbMaVe.ValueMember = "MAVE";
            cbbMaVe.DisplayMember = "MAVE";
            cbbMaVe.Text = null;

            cbbNoiDi.DataSource = busSanBay.LoadSanBay();
            cbbNoiDi.DisplayMember = "TENSANBAY";
            cbbNoiDi.ValueMember = "TENSANBAY";
            cbbNoiDi.Text = null;

            cbbNoiDen.DataSource = busSanBay.LoadSanBay();
            cbbNoiDen.DisplayMember = "TENSANBAY";
            cbbNoiDen.ValueMember = "TENSANBAY";
            cbbNoiDen.Text = null;

            cbbMaCB.DataSource = busChuyenBay.LoadMaCB();
            cbbMaCB.DisplayMember = "MACB";
            cbbMaCB.ValueMember = "MACB";
            cbbMaCB.Text = null;
            // cbbMaCB.DataSource = busCB.LoadCB();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            gridViewCapNhatVe.RowHeadersVisible = false;
            gridViewCapNhatVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string maVe = "";

            if (cbbMaVe.Text != "")
            {
                maVe = cbbMaVe.Text;
            }
            else
            {
                maVe = gridViewCapNhatVe.CurrentRow.Cells["MAVE"].Value.ToString();
            }

            if (busVe.ThanhToanVe(maVe))
            {
                MessageBox.Show("Thanh toán vé thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Vé đã được thanh toán trước đó!", "Thông báo", MessageBoxButtons.OK);
            }

            gridViewCapNhatVe.DataSource = busVe.LoadVeCapNhat(cbbMaCB.Text, cbbMaVe.Text);
            gridViewCapNhatVe.ClearSelection();
        }

        private void btnHoanVe_Click(object sender, EventArgs e)
        {

            gridViewCapNhatVe.RowHeadersVisible = false;
            gridViewCapNhatVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string maVe = "";
            if (cbbMaVe.Text != "")
            {
                maVe = cbbMaVe.Text;
            }
            else
            {
                maVe = gridViewCapNhatVe.CurrentRow.Cells["MAVE"].Value.ToString();
            }

            if (busVe.HoanVe(maVe))
            {
                MessageBox.Show("Cập nhật vé thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Cập nhật vé thất bại!", "Thông báo", MessageBoxButtons.OK);
            }

            gridViewCapNhatVe.DataSource = busVe.LoadVeCapNhat(cbbMaCB.Text, cbbMaVe.Text);
            gridViewCapNhatVe.ClearSelection();
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            BanVe formBanVe = new BanVe(getMaCB(gridViewLichCB));
            formBanVe.ShowDialog();
        }
    }
}
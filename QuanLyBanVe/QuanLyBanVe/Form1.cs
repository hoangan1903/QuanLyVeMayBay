﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAO;
using DTO;
using BUS;

namespace QuanLyBanVe
{
    public partial class Form1 : Form
    {
        BUS_Ve busVe = new BUS_Ve();
        BUS_SanBay busSanBay = new BUS_SanBay();
        BUS_HHK busHHK = new BUS_HHK();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QuanLy.LoadDataToDataGridView(gridViewLichCB);
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
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (gridViewLichCB.SelectedCells.Count == 1)
            {
                DataGridViewCell selectedCell = gridViewLichCB.SelectedCells[0];
                if (selectedCell.OwningRow.DefaultCellStyle.BackColor == QuanLy.AddedRowColor)
                {
                    btnSua.Enabled = true;
                    return;
                }
                if (selectedCell.OwningColumn.Index != 0 && selectedCell.OwningRow.DefaultCellStyle.BackColor != QuanLy.RemovedRowColor)
                {
                    btnSua.Enabled = true;
                    return;
                }
            }
            btnSua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QuanLy.AddRowToDataGridView(gridViewLichCB);
            DataGridViewRow newRow = gridViewLichCB.Rows[gridViewLichCB.Rows.Count - 1];
            newRow.HeaderCell.Value = String.Format("{0}", newRow.Index + 1);

            QuanLy.addedRows.Add(newRow);
            newRow.DefaultCellStyle.BackColor = QuanLy.AddedRowColor;
            gridViewLichCB.CurrentCell = newRow.Cells[0];

            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gridViewLichCB.CurrentCell = gridViewLichCB.SelectedCells[0];
            if (gridViewLichCB.CurrentCell.OwningColumn == gridViewLichCB.Columns[1] ||
                gridViewLichCB.CurrentCell.OwningColumn == gridViewLichCB.Columns[2] ||
                gridViewLichCB.CurrentCell.OwningColumn == gridViewLichCB.Columns[3] ||
                gridViewLichCB.CurrentCell.OwningColumn == gridViewLichCB.Columns[4] ||
                gridViewLichCB.CurrentCell.OwningColumn == gridViewLichCB.Columns[5])
            {
                splitContainer1.Panel1.Enabled = false;

                cbbNoiDi.DataSource = busSanBay.LoadSanBay();
                cbbNoiDi.DisplayMember = "TENSANBAY";
                cbbNoiDi.ValueMember = "TENSANBAY";

                cbbNoiDen.DataSource = busSanBay.LoadSanBay();
                cbbNoiDen.DisplayMember = "TENSANBAY";
                cbbNoiDen.ValueMember = "TENSANBAY";

                cbbHHK.DataSource = busHHK.LoadHangHangKhong();
                cbbHHK.DisplayMember = "TENHHK";
                cbbHHK.ValueMember = "TENHHK";

                panel1.Location = new Point(splitContainer1.Panel2.Size.Width - panel1.Size.Width - 18, 0);
                panel1.Visible = true;
            }
            else
            {
                gridViewLichCB.BeginEdit(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridViewLichCB.SelectedRows)
            {
                if (row.DefaultCellStyle.BackColor != QuanLy.RemovedRowColor)
                {
                    row.ReadOnly = true;
                    if (row.DefaultCellStyle.BackColor == QuanLy.AddedRowColor)
                    {
                        row.DefaultCellStyle.BackColor = QuanLy.RemovedRowColor;
                        QuanLy.addedRows.Remove(row);
                        continue;
                    }
                    if (row.DefaultCellStyle.BackColor == QuanLy.ModifiedRowColor)
                    {
                        QuanLy.removedRows.Add(row);
                        row.DefaultCellStyle.BackColor = QuanLy.RemovedRowColor;
                        QuanLy.modifiedRows.Remove(row);
                        continue;
                    }
                    QuanLy.removedRows.Add(row);
                    row.DefaultCellStyle.BackColor = QuanLy.RemovedRowColor;
                }
            }
            gridViewLichCB.ClearSelection();
            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnSua.Enabled = false;
            btnSave.Enabled = false;
            btnCancelChanges.Enabled = false;

            DataGridViewCell modifiedCell = gridViewLichCB.SelectedCells[0];
            DataGridViewRow modifiedRow = modifiedCell.OwningRow;
            if (modifiedRow.DefaultCellStyle.BackColor != QuanLy.AddedRowColor &&
                modifiedRow.DefaultCellStyle.BackColor != QuanLy.ModifiedRowColor)
            {
                QuanLy.modifiedRows.Add(modifiedRow);
                modifiedRow.DefaultCellStyle.BackColor = QuanLy.ModifiedRowColor;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (!QuanLy.CheckAffectedRows(gridViewLichCB))
            {
                /* Show error(s) to the user */
                MessageBox.Show("Có lỗi khi cập nhật dữ liệu vào CDSL. Vui lòng kiểm tra lại các thay đổi của bạn.", "Cập nhật không thành công");
                QuanLy.ShowErrorText(lblUpdateStatus);
                QuanLy.errors.Clear();
            }
            else
            {
                /* Save the changes */
                btnCancelChanges.Enabled = false;
                foreach (DataGridViewRow row in QuanLy.addedRows)
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Resources.localConnectionString_CamTu))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("ThemCB", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        QuanLy.AddParametersToCommand(command, row);
                        command.ExecuteNonQuery();
                    }
                }

                foreach (DataGridViewRow row in QuanLy.modifiedRows)
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Resources.localConnectionString_CamTu))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SuaCB", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        QuanLy.AddParametersToCommand(command, row);
                        command.ExecuteNonQuery();
                    }
                }

                foreach (DataGridViewRow row in QuanLy.removedRows)
                {  
                    using (SqlConnection connection = new SqlConnection(Properties.Resources.localConnectionString_CamTu))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("XoaCB", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        QuanLy.AddParametersToCommand(command, row);
                        command.ExecuteNonQuery();
                    }
                }
                QuanLy.ShowChangeLog(lblUpdateStatus);
                QuanLy.addedRows.Clear();
                QuanLy.modifiedRows.Clear();
                QuanLy.removedRows.Clear();
                QuanLy.LoadDataToDataGridView(gridViewLichCB);
            }
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnCancelChanges.Enabled = false;
            QuanLy.addedRows.Clear();
            QuanLy.modifiedRows.Clear();
            QuanLy.removedRows.Clear();
            QuanLy.LoadDataToDataGridView(gridViewLichCB);
        }

        private void buttonOK1_Click(object sender, EventArgs e)
        {
            DataGridViewRow modifiedRow = gridViewLichCB.CurrentCell.OwningRow;
            if (modifiedRow.DefaultCellStyle.BackColor != QuanLy.AddedRowColor &&
                modifiedRow.DefaultCellStyle.BackColor != QuanLy.ModifiedRowColor)
            {
                QuanLy.modifiedRows.Add(modifiedRow);
                modifiedRow.DefaultCellStyle.BackColor = QuanLy.ModifiedRowColor;
            }
            modifiedRow.Cells[1].Value = cbbMaSBDi.Text;
            modifiedRow.Cells[2].Value = cbbMaSBDen.Text;
            modifiedRow.Cells[3].Value = cbbHHK.Text;
            modifiedRow.Cells[4].Value = departureTime.Text;
            modifiedRow.Cells[5].Value = arrivalTime.Text;

            panel1.Visible = false;
            splitContainer1.Panel1.Enabled = true;
            btnSua.Enabled = true;

            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            splitContainer1.Panel1.Enabled = true;
            btnSua.Enabled = true;
        }

        /* cellContextMenuStrip1 */
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridViewLichCB.ClearSelection();
                DataGridViewCell clickedCell = gridViewLichCB.Rows[e.RowIndex].Cells[e.ColumnIndex];
                gridViewLichCB.CurrentCell = clickedCell;
                clickedCell.Selected = true;
                /* Determine whether modifyCellToolStripMenuItem can be enabled */
                if (clickedCell.OwningRow.DefaultCellStyle.BackColor == QuanLy.AddedRowColor)
                {
                    modifyCellToolStripMenuItem.Enabled = true;
                }
                else if (clickedCell.OwningColumn.Index != 0 && clickedCell.OwningRow.DefaultCellStyle.BackColor != QuanLy.RemovedRowColor)
                {
                    modifyCellToolStripMenuItem.Enabled = true;
                }
                else modifyCellToolStripMenuItem.Enabled = false;
                /* Determine whether copyRowToolStripMenuItem can be enabled */
                if (clickedCell.OwningRow.DefaultCellStyle.BackColor != QuanLy.AddedRowColor)
                {
                    copyRowToolStripMenuItem.Enabled = true;
                }
                else
                {
                    copyRowToolStripMenuItem.Enabled = false;
                }
                /* Determine whether pasteRowToolStripMenuItem can be enabled */
                if (QuanLy.duplicate != null && clickedCell.OwningRow.DefaultCellStyle.BackColor != QuanLy.RemovedRowColor)
                {
                    pasteRowToolStripMenuItem.Enabled = true;
                }
                else
                {
                    pasteRowToolStripMenuItem.Enabled = false;
                }
                cellContextMenuStrip1.Show(MousePosition);
            }
        }

        private void modifyCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void selectRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridViewLichCB.CurrentCell.OwningRow.Selected = true;
        }

        private void copyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow rowToCopy = gridViewLichCB.CurrentCell.OwningRow;
            rowToCopy.Selected = true;
            QuanLy.duplicate = (DataGridViewRow)rowToCopy.Clone();
            for (int i = 0; i < 9; i++)
            {
                QuanLy.duplicate.Cells[i].Value = rowToCopy.Cells[i].Value;
            }
            lblUpdateStatus.ForeColor = QuanLy.ChangeLogColor;
            lblUpdateStatus.Text = "Đã sao chép hàng " + (rowToCopy.Index + 1).ToString() + " (MACB = '" + rowToCopy.Cells[0].Value.ToString() + "').";
        }

        private void pasteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow modifiedRow = gridViewLichCB.CurrentCell.OwningRow;
            if (modifiedRow.DefaultCellStyle.BackColor != QuanLy.AddedRowColor &&
                modifiedRow.DefaultCellStyle.BackColor != QuanLy.ModifiedRowColor)
            {
                QuanLy.modifiedRows.Add(modifiedRow);
                modifiedRow.DefaultCellStyle.BackColor = QuanLy.ModifiedRowColor;
            }
            for (int i = 1; i < 9; i++)
            {
                modifiedRow.Cells[i].Value = QuanLy.duplicate.Cells[i].Value;
            }
            gridViewLichCB.ClearSelection();
            btnSave.Enabled = true;
            btnCancelChanges.Enabled = true;
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridViewLichCB.CurrentCell.OwningRow.Selected = true;
            btnXoa_Click(sender, e);
        }

        /* contextMenuStrip1 */
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gridViewLichCB.EndEdit();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panel1.Visible = false;
                splitContainer1.Panel1.Enabled = true;
                btnSua.Enabled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                QuanLy.panel1_MouseDownLocation = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int left = e.X + panel1.Left - QuanLy.panel1_MouseDownLocation.X;
                if (left >= 0 && left <= splitContainer1.Panel2.Size.Width - panel1.Size.Width - 18)
                    panel1.Left = left;
                else if (left < 0)
                    panel1.Left = 0;
                else
                    panel1.Left = splitContainer1.Panel2.Size.Width - panel1.Size.Width - 18;

                int top = e.Y + panel1.Top - QuanLy.panel1_MouseDownLocation.Y;
                if (top >= 0 && top <= splitContainer1.Panel2.Size.Height - panel1.Size.Height)
                    panel1.Top = top;
                else if (top < 0)
                    panel1.Top = 0;
                else
                    panel1.Top = splitContainer1.Panel2.Size.Height - panel1.Size.Height;
            }
        }

        /* dataGridView2 */
        private void cbbNoiDi_DropDown(object sender, EventArgs e)
        {
            cbbNoiDi.DataSource = busSanBay.LoadSanBay();
            cbbNoiDi.DisplayMember = "TENSANBAY";
            cbbNoiDi.ValueMember = "TENSANBAY";
        }
        private void cbbNoiDen_DropDown(object sender, EventArgs e)
        {
            cbbNoiDen.DataSource = busSanBay.LoadSanBay();
            cbbNoiDen.DisplayMember = "TENSANBAY";
            cbbNoiDen.ValueMember = "TENSANBAY";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            if (cbbNoiDen.Text == cbbNoiDi.Text)
            {
                MessageBox.Show("Không thể tra cứu");
            }
            else
            {
                QuanLy.TraCuu(gridViewTraCuu, cbbNoiDi, cbbNoiDen, dateTraCuu);
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnBanVe2.Enabled = true;
            QuanLy.ChiTietChuyenBay(gridViewChiTiet, getMaCB(gridViewTraCuu));
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
            BaoCao formBaoCao = new BaoCao();
            formBaoCao.ShowDialog();
        }

        private void báoCáoNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoNam formBaoCaoNam = new BaoCaoNam();
            formBaoCaoNam.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            gridViewCapNhatVe.RowHeadersVisible = false;
            gridViewCapNhatVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridViewCapNhatVe.DataSource = busVe.CapNhatVe(cbbMaCB.Text, cbbMaVe.Text);
            gridViewCapNhatVe.ClearSelection();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            cbbMaVe.DataSource = busVe.LoadVe();
            cbbMaVe.ValueMember = "MAVE";
            cbbMaVe.DisplayMember = "MAVE";
            cbbMaVe.Text = null;

            cbbNoiDi.DataSource = busSanBay.LoadSanBay();
            cbbNoiDi.DisplayMember = "TENSANBAY";
            cbbNoiDi.ValueMember = "TENSANBAY";

            cbbNoiDen.DataSource = busSanBay.LoadSanBay();
            cbbNoiDen.DisplayMember = "TENSANBAY";
            cbbNoiDen.ValueMember = "TENSANBAY";
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

            gridViewCapNhatVe.DataSource = busVe.CapNhatVe(cbbMaCB.Text, cbbMaVe.Text);
            gridViewCapNhatVe.ClearSelection();
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThanhToan.Enabled = true;
            btnHoanVe.Enabled = true;            
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

            gridViewCapNhatVe.DataSource = busVe.CapNhatVe(cbbMaCB.Text, cbbMaVe.Text);
            gridViewCapNhatVe.ClearSelection();
        }

       
       

        

    }
}
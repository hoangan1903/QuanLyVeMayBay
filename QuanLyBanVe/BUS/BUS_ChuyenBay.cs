using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_ChuyenBay
    {
        DAO_ChuyenBay daoChuyenBay;
        public BUS_ChuyenBay()
        {
            daoChuyenBay = new DAO_ChuyenBay();
        }

        public DataTable GetChuyenBay()
        {
            return daoChuyenBay.GetChuyenBay();
        }

        public bool ThemChuyenBay(DataGridViewRow row)
        {
            DTO_ChuyenBay dtoChuyenBay = new DTO_ChuyenBay();
            dtoChuyenBay.MaCB = row.Cells[0].Value.ToString();
            dtoChuyenBay.MaSBDi = row.Cells[1].Value.ToString();
            dtoChuyenBay.MaSBDen = row.Cells[2].Value.ToString();
            dtoChuyenBay.MaHHK = row.Cells[3].Value.ToString();
            dtoChuyenBay.ThoiGianKhoiHanh = Convert.ToDateTime(row.Cells[4].Value.ToString());
            dtoChuyenBay.ThoiGianDen = Convert.ToDateTime(row.Cells[5].Value.ToString());
            dtoChuyenBay.SoGheHang1 = int.Parse(row.Cells[6].Value.ToString());
            dtoChuyenBay.SoGheHang2 = int.Parse(row.Cells[7].Value.ToString());
            dtoChuyenBay.GiaVe = int.Parse(row.Cells[8].Value.ToString());
            return daoChuyenBay.ThemChuyenBay(dtoChuyenBay);
        }

        public bool SuaChuyenBay(DataGridViewRow row)
        {
            DTO_ChuyenBay dtoChuyenBay = new DTO_ChuyenBay();
            dtoChuyenBay.MaCB = row.Cells[0].Value.ToString();
            dtoChuyenBay.MaSBDi = row.Cells[1].Value.ToString();
            dtoChuyenBay.MaSBDen = row.Cells[2].Value.ToString();
            dtoChuyenBay.MaHHK = row.Cells[3].Value.ToString();
            dtoChuyenBay.ThoiGianKhoiHanh = Convert.ToDateTime(row.Cells[4].Value.ToString());
            dtoChuyenBay.ThoiGianDen = Convert.ToDateTime(row.Cells[5].Value.ToString());
            dtoChuyenBay.SoGheHang1 = int.Parse(row.Cells[6].Value.ToString());
            dtoChuyenBay.SoGheHang2 = int.Parse(row.Cells[7].Value.ToString());
            dtoChuyenBay.GiaVe = int.Parse(row.Cells[8].Value.ToString());
            return daoChuyenBay.SuaChuyenBay(dtoChuyenBay);
        }

        public bool XoaChuyenBay(DataGridViewRow row)
        {
            DTO_ChuyenBay dtoChuyenBay = new DTO_ChuyenBay();
            dtoChuyenBay.MaCB = row.Cells[0].Value.ToString();
            dtoChuyenBay.MaSBDi = row.Cells[1].Value.ToString();
            dtoChuyenBay.MaSBDen = row.Cells[2].Value.ToString();
            dtoChuyenBay.MaHHK = row.Cells[3].Value.ToString();
            dtoChuyenBay.ThoiGianKhoiHanh = Convert.ToDateTime(row.Cells[4].Value.ToString());
            dtoChuyenBay.ThoiGianDen = Convert.ToDateTime(row.Cells[5].Value.ToString());
            dtoChuyenBay.SoGheHang1 = int.Parse(row.Cells[6].Value.ToString());
            dtoChuyenBay.SoGheHang2 = int.Parse(row.Cells[7].Value.ToString());
            dtoChuyenBay.GiaVe = int.Parse(row.Cells[8].Value.ToString());
            return daoChuyenBay.XoaChuyenBay(dtoChuyenBay);
        }

        public DataTable GetSanBay()
        {
            return daoChuyenBay.GetSanBay();
        }

        public DataTable GetHHK()
        {
            return daoChuyenBay.GetHHK();
        }

        public DataTable TraCuu(string maSBDi, string maSBDen, DateTime datetime)
        {
            return daoChuyenBay.TraCuu(maSBDi, maSBDen, datetime);
        }

        public DataTable ChiTietCB(string maCB)
        {
            return daoChuyenBay.ChiTietCB(maCB);
        }

        public DataTable LoadMaCB()
        {
            return daoChuyenBay.LoadMaCB();
        }

        ////public DataTable LietKeCB()
        ////{
        ////    return daoChuyenBay.LietKeCB();
        ////}

        ////public bool ThemCB(string maCB, string sanBayDi, string sanBayDen, string HHK, DateTime thoiGianKhoiHanh, DateTime thoiGianDen, int soGheHang1, int soGheHang2, int giaVe)
        ////{
        ////    DTO_ChuyenBay dtoCB = new DTO_ChuyenBay(maCB, sanBayDi, sanBayDen, HHK, thoiGianKhoiHanh, thoiGianDen, soGheHang1, soGheHang2, giaVe);

        ////    return daoChuyenBay.ThemCB(dtoCB);
        ////}

        ////public bool SuaCB(string maCB, string sanBayDi, string sanBayDen, string HHK, DateTime thoiGianKhoiHanh, DateTime thoiGianDen, int soGheHang1, int soGheHang2, int giaVe)
        ////{
        ////    DTO_ChuyenBay dtoCB = new DTO_ChuyenBay(maCB, sanBayDi, sanBayDen, HHK, thoiGianKhoiHanh, thoiGianDen, soGheHang1, soGheHang2, giaVe);

        ////    return daoChuyenBay.SuaCB(dtoCB);
        ////}
    }
}

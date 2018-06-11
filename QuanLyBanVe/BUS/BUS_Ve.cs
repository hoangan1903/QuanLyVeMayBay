using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Ve
    {
        DAO_Ve daoVe = new DAO_Ve();

        public DataTable LoadMaVe()
        {
            return daoVe.LoadMaVe();
        }

        public DataTable LoadVeCapNhat(string maCB, string maVe)
        {
            return daoVe.LoadVeCapNhat(maCB, maVe);
        }

        public DataTable LietKeVe(string maCB)
        {
            return daoVe.LietKeVe(maCB);
        }

        public DataTable ChonHangVe(string maHV, string maCB)
        {
            return daoVe.ChonHangVe(maHV, maCB);
        }

        public bool ThanhToanVe(string maVe)
        {
            return daoVe.ThanhToanVe(maVe);
        }

        public bool HoanVe(string maVe)
        {
            return daoVe.HoanVe(maVe);
        }

        public bool CapNhatVe(string maVe, string maTinhTrang)
        {
            return daoVe.CapNhatVe(maVe, maTinhTrang);
        }

        public DataTable DemVeHang1(string maCB)
        {
            return daoVe.DemVeHang1(maCB);
        }

        public DataTable DemVeHang2(string maCB)
        {
            return daoVe.DemVeHang2(maCB);
        }
    }
}

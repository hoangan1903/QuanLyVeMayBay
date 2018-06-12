using DAO;
using DTO;
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

        public DataTable VeHang1Trong(string maCB)
        {
            return daoVe.VeHang1Trong(maCB);
        }

        public DataTable VeHang2Trong(string maCB)
        {
            return daoVe.VeHang2Trong(maCB);
        }
        
        public DataTable TongVeHang1(string maCB)
        {
            return daoVe.TongVeHang1(maCB);
        }
        public DataTable TongVeHang2(string maCB)
        {
            return daoVe.TongVeHang2(maCB);
        }
        public bool ThemVe(string maVe, string maCB, string maHHK, string maHV, int giaTien, string maTT)
        {
            DTO_Ve dtoVe = new DTO_Ve(maVe, maCB, maHHK, maHV, giaTien, maTT);
            return daoVe.ThemVe(dtoVe);
        }
    }
}

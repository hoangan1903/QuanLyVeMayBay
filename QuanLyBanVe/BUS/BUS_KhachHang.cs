using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAO_KhachHang daoKhachHang = new DAO_KhachHang();

        public DataTable LoadKhachHang(string CMND)
        {
            return daoKhachHang.LoadKhachHang(CMND);
        }

        public DataTable LoadKhachHang(string CMND, string hoTen)
        {
            return daoKhachHang.LoadKhachHang(CMND, hoTen);
        }
    }
}

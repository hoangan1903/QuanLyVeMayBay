using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_KhachHang : DBConnect
    {
        public DataTable LoadKhachHang(string CMND)
        {
            conn.Open();
            string sql = string.Format("Select * From KHACHHANG Where CMND = '{0}'", CMND);

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }

        public DataTable LoadKhachHang(string CMND, string hoTen)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Select * From KHACHHANG Where CMND = '{0}' and HoTen = N'{1}'", CMND, hoTen);

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();

                return dt;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}

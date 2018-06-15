using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DAO_KhachHang
    {
        public DataTable LoadKhachHang()
        {
            Connect.connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("Select * From KHACHHANG", Connect.connection);
            DataTable data = new DataTable();

            adapter.Fill(data);

            Connect.connection.Close();

            return data;
        }

        public DataTable LoadKhachHang(string CMND)
        {
            Connect.connection.Open();
            string sql = string.Format("Select * From KHACHHANG Where CMND = '{0}'", CMND);

            SqlDataAdapter da = new SqlDataAdapter(sql, Connect.connection);

            DataTable dt = new DataTable();

            da.Fill(dt);

            Connect.connection.Close();

            return dt;
        }

        public DataTable LoadKhachHang(string CMND, string hoTen)
        {
            try
            {
                Connect.connection.Open();
                string sql = string.Format("Select * From KHACHHANG Where CMND = '{0}' and HoTen = N'{1}'", CMND, hoTen);

                SqlDataAdapter da = new SqlDataAdapter(sql, Connect.connection);

                DataTable dt = new DataTable();
                da.Fill(dt);

                Connect.connection.Close();

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool TaoThanhVien(DTO_KhachHang dtoKhachHang)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("TaoThanhVien", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@HoTen", dtoKhachHang.HoTen);
                comm.Parameters.Add(para);

                para = new SqlParameter("@Tuoi", dtoKhachHang.Tuoi);
                comm.Parameters.Add(para);

                if (dtoKhachHang.GioiTinh == true)
                {
                    para = new SqlParameter("@GioiTinh", 1);
                }
                else
                {
                    para = new SqlParameter("@GioiTinh", 0);
                }
                comm.Parameters.Add(para);

                para = new SqlParameter("@CMND", dtoKhachHang.CMND);
                comm.Parameters.Add(para);

                para = new SqlParameter("@DiaChi", dtoKhachHang.DiaChi);
                comm.Parameters.Add(para);

                para = new SqlParameter("@SDT", dtoKhachHang.SDT);
                comm.Parameters.Add(para);

                if (comm.ExecuteNonQuery() > 0)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connect.connection.Close();
            }
        }
    }
}

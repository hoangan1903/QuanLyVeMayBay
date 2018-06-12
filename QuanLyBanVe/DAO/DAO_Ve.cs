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
    public class DAO_Ve:DBConnect
    {
        DTO_HangVe dtoHangVe = new DTO_HangVe();
      
        public DataTable LoadMaVe()
        {
            Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT MAVE FROM VE", Connection);
            DataTable datb = new DataTable();
            adapter.Fill(datb);
            Connection.Close();
            return datb;
        }
        public DataTable LoadVeCapNhat(string maCB, string maVe)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("LoadVeCapNhat", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                para = new SqlParameter("@MaVe", maVe);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable datb = new DataTable();
                adapter.Fill(datb);

                Connection.Close();

                return datb;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable LietKeVe(string maCB)
        {
            Connection.Open();

            SqlCommand comm = new SqlCommand("LietKeVe", Connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@MaCB", maCB);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;
            DataTable datb = new DataTable();
            adapter.Fill(datb);

            Connection.Close();
            return datb;
        }
        public DataTable ChonHangVe(string maHV, string maCB)
        {
            Connection.Open();

            SqlCommand comm = new SqlCommand("ChonHangVe", Connection);
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter para = new SqlParameter("@MaHangVe", maHV);
            comm.Parameters.Add(para);

            para = new SqlParameter("@MaCB", maCB);
            comm.Parameters.Add(para);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            DataTable dt = new DataTable();

            adapter.Fill(dt);
            Connection.Close();

            return dt;
        }
        public bool ThanhToanVe(string maVe)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("ThanhToan", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter();
                para = new SqlParameter("@MaVe", maVe);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;

                if (comm.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }
        public bool HoanVe(string maVe)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("HoanVe", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter();
                para = new SqlParameter("@MaVe", maVe);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;

                if (comm.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }
        public bool CapNhatVe(string maVe, string maTinhTrang)
        {
            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand("UpdateTinhTrangVe", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaTT", maTinhTrang);
                cmd.Parameters.AddWithValue("@MaVe", maVe);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }

        public DataTable VeHang1Trong(string maCB)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("VeHang1Trong", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connection.Close();
                return dataTable;
            }
            catch
            {
                return null;
            }
        }
        public DataTable VeHang2Trong(string maCB)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("VeHang2Trong", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connection.Close();
                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public DataTable TongVeHang1(string maCB)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("CountVeHang1", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connection.Close();
                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public DataTable TongVeHang2(string maCB)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("CountVeHang2", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connection.Close();
                return dataTable;
            }
            catch
            {
                return null;
            }
        }
        public bool ThemVe(DTO_Ve dtoVe)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("ThemVe", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", dtoVe.MaCB);
                comm.Parameters.Add(para);

                para = new SqlParameter("@MaVe", dtoVe.MaVe);
                comm.Parameters.Add(para);

                para = new SqlParameter("@TenHHK", dtoVe.MaHHK);
                comm.Parameters.Add(para);

                para = new SqlParameter("@MaHV", dtoVe.MaHV);
                comm.Parameters.Add(para);

                para = new SqlParameter("@GiaTien", dtoVe.GiaTien);
                comm.Parameters.Add(para);

                para = new SqlParameter("@MaTT", dtoVe.MaTT);
                comm.Parameters.Add(para);

                if (comm.ExecuteNonQuery() != 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }
    }
}

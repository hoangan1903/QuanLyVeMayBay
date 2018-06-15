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
    public class DAO_Ve
    {
        DTO_HangVe dtoHangVe = new DTO_HangVe();

        public DataTable LoadMaVe()
        {
            Connect.connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT MAVE FROM VE", Connect.connection);
            DataTable datb = new DataTable();
            adapter.Fill(datb);
            Connect.connection.Close();
            return datb;
        }
        public DataTable LoadVeCapNhat(string maCB, string maVe)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("LoadVeCapNhat", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                para = new SqlParameter("@MaVe", maVe);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable datb = new DataTable();
                adapter.Fill(datb);

                Connect.connection.Close();

                return datb;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable LietKeVe(string maCB)
        {
            Connect.connection.Open();

            SqlCommand comm = new SqlCommand("LietKeVe", Connect.connection);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@MaCB", maCB);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;
            DataTable datb = new DataTable();
            adapter.Fill(datb);

            Connect.connection.Close();
            return datb;
        }
        public DataTable ChonHangVe(string maHV, string maCB)
        {
            Connect.connection.Open();

            SqlCommand comm = new SqlCommand("ChonHangVe", Connect.connection);
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter para = new SqlParameter("@MaHangVe", maHV);
            comm.Parameters.Add(para);

            para = new SqlParameter("@MaCB", maCB);
            comm.Parameters.Add(para);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            DataTable dt = new DataTable();

            adapter.Fill(dt);
            Connect.connection.Close();

            return dt;
        }
        public bool ThanhToanVe(string maVe)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("ThanhToan", Connect.connection);
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
                Connect.connection.Close();
            }
            return false;
        }
        public bool HoanVe(string maVe)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("HoanVe", Connect.connection);
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
                Connect.connection.Close();
            }
            return false;
        }
        public bool CapNhatVe(string maVe, string maTinhTrang)
        {
            try
            {
                Connect.connection.Open();

                SqlCommand cmd = new SqlCommand("UpdateTinhTrangVe", Connect.connection);
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
                Connect.connection.Close();
            }
            return false;
        }

        public DataTable VeHang1Trong(string maCB)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("VeHang1Trong", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connect.connection.Close();
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
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("VeHang2Trong", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connect.connection.Close();
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
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("CountVeHang1", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connect.connection.Close();
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
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("CountVeHang2", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", maCB);
                comm.Parameters.Add(para);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Connect.connection.Close();
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
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("ThemVe", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaCB", dtoVe.MaCB);
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
                Connect.connection.Close();
            }
        }

        public SqlDataAdapter InVe(string maVe)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("InVe", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaVe", maVe);
                comm.Parameters.Add(para);

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;

                Connect.connection.Close();
                return dataAdapter;
            }
            catch
            {
                return null;
            }
        }
    }
}

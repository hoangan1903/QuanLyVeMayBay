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
    public class DAO_ChuyenBay
    {
        public DataTable GetChuyenBay()
        {
            try
            {
                DataTable table = new DataTable();
                Connect.connection.Open();
                SqlCommand cmd = new SqlCommand("LietKeCB", Connect.connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                Connect.connection.Close();
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connect.connection.Close();
            }
        }
        public bool ThemChuyenBay(DTO_ChuyenBay cb, string tenSBTG, int thoiGianDung)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand command = new SqlCommand("ThemCB", Connect.connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parameter;

                parameter = new SqlParameter("@TenSBDi", cb.MaSBDi);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TenSBDen", cb.MaSBDen);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TenHHK", cb.MaHHK);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TenSBTG", tenSBTG);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ThoiGianDung", thoiGianDung);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ThoiGianKhoiHanh", cb.ThoiGianKhoiHanh);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ThoiGianDen", cb.ThoiGianDen);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@SoGheHang1", cb.SoGheHang1);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@SoGheHang2", cb.SoGheHang2);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@GiaVe", cb.GiaVe);
                command.Parameters.Add(parameter);

                if (command.ExecuteNonQuery() > 0)
                    return true;
                else return false;
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
        
        public bool SuaChuyenBay(DTO_ChuyenBay cb, string tenSBTG, int thoiGianDung)
        {
            try
            {
                Connect.connection.Open();

                SqlCommand command = new SqlCommand("SuaCB", Connect.connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter parameter;

                parameter = new SqlParameter("@MaCB", cb.MaCB);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TenSBDi", cb.MaSBDi);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TenSBDen", cb.MaSBDen);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TenHHK", cb.MaHHK);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@TenSBTG", tenSBTG);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ThoiGianDung", thoiGianDung);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ThoiGianKhoiHanh", cb.ThoiGianKhoiHanh.ToString());
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ThoiGianDen", cb.ThoiGianDen.ToString());
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@SoGheHang1", cb.SoGheHang1);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@SoGheHang2", cb.SoGheHang2);
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@GiaVe", cb.GiaVe);
                command.Parameters.Add(parameter);

                return command.ExecuteNonQuery() != 0 ? true : false;
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

        public bool XoaChuyenBay(DTO_ChuyenBay cb)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand command = new SqlCommand("XoaCB", Connect.connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter parameter = new SqlParameter("@MaCB", cb.MaCB);
                command.Parameters.Add(parameter);

                if (command.ExecuteNonQuery() != 0)
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

        public DataTable TraCuu(string maSBDi, string maSBDen, DateTime dateTime)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("TraCuu", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaSBDi", maSBDi);
                comm.Parameters.Add(para);

                para = new SqlParameter("@MaSBDen", maSBDen);
                comm.Parameters.Add(para);

                para = new SqlParameter("@ThoiGianBay", dateTime);
                comm.Parameters.Add(para);

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;
                DataTable datb = new DataTable();
                dataAdapter.Fill(datb);
                return datb;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connect.connection.Close();
            }
        }

        public DataTable ChiTietCB(string maCB)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("ChiTietChuyenBay", Connect.connection);
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

        public DataTable LoadMaCB()
        {
            try
            {
                Connect.connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT MACB FROM CHUYENBAY", Connect.connection);
                DataTable datb = new DataTable();
                adapter.Fill(datb);
                Connect.connection.Close();
                return datb;

            }
            catch
            {
                return null;
            }
        }
    }
}

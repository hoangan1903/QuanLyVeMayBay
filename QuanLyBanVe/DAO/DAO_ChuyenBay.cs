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
    public class DAO_ChuyenBay :DBConnect
    {
        public DataTable GetChuyenBay()
        {
            try
            {
                DataTable table = new DataTable();
                Connection.Open();
                SqlCommand cmd = new SqlCommand("LietKeCB", Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                Connection.Close();
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool ThemChuyenBay(DTO_ChuyenBay cb)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand("ThemCB", Connection)
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

                if (command.ExecuteNonQuery() != 0)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable GetSanBay()
        {
            try
            {
                DataTable table = new DataTable();

                Connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TENSANBAY FROM SANBAY", Connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(table);
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DataTable GetHHK()
        {
            try
            {
                DataTable table = new DataTable();

                Connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TENHHK FROM HANGHK", Connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(table);
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool SuaChuyenBay(DTO_ChuyenBay cb)
        {
            try
            {
                Connection.Open();

                SqlCommand command = new SqlCommand("SuaCB", Connection)
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
                Connection.Close();
            }
        }
        public bool XoaChuyenBay(DTO_ChuyenBay cb)
        {
            Connection.Open();
            SqlCommand command = new SqlCommand("XoaCB", Connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter parameter = new SqlParameter("@MaCB", cb.MaCB);
            command.Parameters.Add(parameter);
            Connection.Close();
            return command.ExecuteNonQuery() != 0 ? true : false;
            
        }
        public DataTable TraCuu(string maSBDi, string maSBDen, DateTime dateTime)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("TraCuu", Connection);
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
                Connection.Close();
            }
        }

        public DataTable ChiTietCB(string maCB)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("ChiTietChuyenBay", Connection);
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

        public DataTable LoadMaCB()
        {
            try
            {
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT MACB FROM CHUYENBAY", Connection);
                DataTable datb = new DataTable();
                adapter.Fill(datb);
                Connection.Close();
                return datb;

            }
            catch
            {
                return null;
            }
        }
    }
}

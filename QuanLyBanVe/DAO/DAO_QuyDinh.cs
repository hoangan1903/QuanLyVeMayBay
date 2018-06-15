using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_QuyDinh
    {
        public int GetQuyDinh(string maQuyDinh, DateTime ngayHienTai)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("GetQuyDinh", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaQuyDinh", maQuyDinh);
                comm.Parameters.Add(para);

                para = new SqlParameter("@NgayHienTai", ngayHienTai);
                comm.Parameters.Add(para);

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);


                Connect.connection.Close();
                if (Int32.Parse(dataTable.Rows[0][0].ToString()) >= 0)
                    return Int32.Parse(dataTable.Rows[0][0].ToString());
                return -1;
            }
            catch
            {
                return -1;
            }
        }
        public bool CapNhatQuyDinh(string maQuyDinh, int giaTri, DateTime ngayApDung)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("CapNhatQuyDinh", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaQuyDinh", maQuyDinh);
                comm.Parameters.Add(para);

                para = new SqlParameter("@GiaTri", giaTri);
                comm.Parameters.Add(para);

                para = new SqlParameter("@NgayApDung", ngayApDung);
                comm.Parameters.Add(para);

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;

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

        public DataTable LoadMaQuyDinh()
        {
            DataTable result = new DataTable();
            try
            {
                Connect.connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT TenQuyDinh FROM QUYDINH", Connect.connection);
                adapter.Fill(result);
                return result;
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

        public DataTable LoadQuyDinh(string tenQuyDinh)
        {
            DataTable result = new DataTable();
            string commandText = "SELECT * FROM QUYDINH WHERE MaQuyDinh = (SELECT DISTINCT MaQuyDinh FROM QUYDINH WHERE TenQuyDinh = N'" + tenQuyDinh + "')";
            try
            {
                Connect.connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(commandText, Connect.connection);
                adapter.Fill(result);
                return result;
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
    }
}
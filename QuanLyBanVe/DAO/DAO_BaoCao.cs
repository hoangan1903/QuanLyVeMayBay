using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_BaoCao
    {
        public SqlDataAdapter BaoCaoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("BaoCao", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@TuNgay", tuNgay);
                comm.Parameters.Add(para);

                para = new SqlParameter("@DenNgay", denNgay);
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

        public SqlDataAdapter BaoCaoNam(string nam)
        {
            try
            {
                Connect.connection.Open();
                SqlCommand comm = new SqlCommand("BaoCaoNam", Connect.connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@NAM", Int32.Parse(nam));
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
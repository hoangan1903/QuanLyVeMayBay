using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_HHK
    {
        public DataTable LoadHangHangKhong()
        {
            try
            {
               Connect.connection.Open();

                SqlCommand comm = new SqlCommand("SELECT TENHHK FROM HANGHK",Connect.connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;

                DataTable datb = new DataTable();
                dataAdapter.Fill(datb);
                Connect.connection.Close();
                return datb;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

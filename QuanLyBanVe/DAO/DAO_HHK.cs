using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_HHK :DBConnect
    {
        public DataTable LoadHangHangKhong()
        {
            try
            {
               Connection.Open();

                SqlCommand comm = new SqlCommand("SELECT TENHHK FROM HANGHK",Connection);
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
    }
}

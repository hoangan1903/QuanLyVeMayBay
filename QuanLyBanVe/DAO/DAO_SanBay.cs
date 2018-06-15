using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_SanBay
    {

        public DataTable LoadSanBay()
        {
            try
            {
                Connect.connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT TENSANBAY FROM SANBAY", Connect.connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                Connect.connection.Close();
                return table;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_SanBay:DBConnect
    {

        public DataTable LoadSanBay()
        {
            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT TENSANBAY FROM SANBAY", Connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                Connection.Close();
                return table;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

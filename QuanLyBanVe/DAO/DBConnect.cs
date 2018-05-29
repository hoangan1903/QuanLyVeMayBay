using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DBConnect
    {
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-76JI7SV; Initial Catalog=QLVeMayBay; Integrated Security=True");
    }
}

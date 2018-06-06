using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DBConnect
    {
        private SqlConnection conn_CamTu = new SqlConnection("Data Source=DESKTOP-76JI7SV; Initial Catalog=QLVeMayBay; Integrated Security=True");
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-260M5KJ;Initial Catalog=QLVeMayBay;Integrated Security=True");
        private SqlConnection conn_VietAnh = new SqlConnection("Data Source=VA-DELLV3560;Initial Catalog=QLVeMayBay;Integrated Security=True");
        
       
    }
}

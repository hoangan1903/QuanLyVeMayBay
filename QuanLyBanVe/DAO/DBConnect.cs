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
        private readonly string connectionString_VietAnh = "Data Source=VA-DELLV3560;Initial Catalog=QLVeMayBay;Integrated Security=True";
        private readonly string connectionString_HoangAn = "Data Source=DESKTOP-260M5KJ;Initial Catalog=QLVeMayBay;Integrated Security=True";
        private readonly string connectionString_CamTu = "Data Source=DESKTOP-76JI7SV;Initial Catalog=QLVeMayBay;Integrated Security=True";

        protected SqlConnection Connection = new SqlConnection("Data Source=DESKTOP-260M5KJ;Initial Catalog=QLVeMayBay;Integrated Security=True");
    }
}
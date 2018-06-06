using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_BaoCao
    {
        DAO_BaoCao daoBaoCao = new DAO_BaoCao();
        public SqlDataAdapter BaoCaoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return daoBaoCao.BaoCaoNgay(tuNgay, denNgay);
        }

        public SqlDataAdapter BaoCaoNam(string nam)
        {
            return daoBaoCao.BaoCaoNam(nam);
        }
    }
}

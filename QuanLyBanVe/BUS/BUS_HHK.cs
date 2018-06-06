using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BUS_HHK
    {
        DAO_HHK daoHHK = new DAO_HHK();

        public DataTable LoadHangHangKhong()
        {
            return daoHHK.LoadHangHangKhong();
        }
    }
}

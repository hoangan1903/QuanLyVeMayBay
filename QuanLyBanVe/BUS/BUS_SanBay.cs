using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_SanBay
    {
        DAO_SanBay daoSanBay = new DAO_SanBay();

        public DataTable LoadSanBay()
        {
            return daoSanBay.LoadSanBay();
        }
    }
}

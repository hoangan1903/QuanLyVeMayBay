using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_PhieuDatMua
    {
        DAO_PhieuDatMua daoPDM = new DAO_PhieuDatMua();

        public bool TaoPhieuDatMua(string maVe, string maKH, DateTime ngayDat, bool daThanhToan)
        {
            DTO_PhieuDatMua dtoPDM = new DTO_PhieuDatMua(maVe, maKH, ngayDat, daThanhToan);

            return daoPDM.TaoPhieuDatMua(dtoPDM);
        }
    }
}

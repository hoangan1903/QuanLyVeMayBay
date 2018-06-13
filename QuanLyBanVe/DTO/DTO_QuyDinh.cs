using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_QuyDinh
    {
        private string maQD;

        public string MaQD
        {
            get { return maQD; }
            set { maQD = value; }
        }
        private string tenQD;

        public string TenQD
        {
            get { return tenQD; }
            set { tenQD = value; }
        }
        private int giaTri;

        public int GiaTri
        {
            get { return giaTri; }
            set { giaTri = value; }
        }
        private DateTime ngayApDung;

        public DateTime NgayApDung
        {
            get { return ngayApDung; }
            set { ngayApDung = value; }
        }
        public DTO_QuyDinh(string maQD, string tenQD, int giaTri, DateTime ngayApDung)
        {
            this.maQD = maQD;
            this.tenQD = tenQD;
            this.giaTri = giaTri;
            this.ngayApDung = ngayApDung;
        }
    }
}

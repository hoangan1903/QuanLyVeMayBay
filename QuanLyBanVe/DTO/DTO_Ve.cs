using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ve
    {
        private string maVe;

        public string MaVe
        {
            get { return maVe; }
            set { maVe = value; }
        }
        private string maCB;

        public string MaCB
        {
            get { return maCB; }
            set { maCB = value; }
        }
        private string maHHK;

        public string MaHHK
        {
            get { return maHHK; }
            set { maHHK = value; }
        }
        private string maHV;

        public string MaHV
        {
            get { return maHV; }
            set { maHV = value; }
        }
        private int giaTien;

        public int GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; }
        }
        private string maTT;

        public string MaTT
        {
            get { return maTT; }
            set { maTT = value; }
        }
        public DTO_Ve(string maVe, string maCB, string maHHK, string maHV, int giaTien, string maTT)
        {
            this.maVe = maVe;
            this.maCB = maCB;
            this.maHHK = maHHK;
            this.maHV = maHV;
            this.giaTien = giaTien;
            this.maTT = maTT;
        }
    }
}

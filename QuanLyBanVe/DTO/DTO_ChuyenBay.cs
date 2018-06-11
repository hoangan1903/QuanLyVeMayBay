using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChuyenBay
    {
        private string maCB;
        public string MaCB
        {
            get { return maCB; }
            set { maCB = value; }
        }

        private string sanBayDi;
        public string MaSBDi
        {
            get { return sanBayDi; }
            set { sanBayDi = value; }
        }
        private string maSBDen;
       
        private string maHHK;

        public string MaHHK
        {
            get { return maHHK; }
            set { maHHK = value; }
        }
        private DateTime thoiGianKhoiHanh;
        private DateTime thoiGianDen;

        private int soGheHang1;

        public int SoGheHang1
        {
            get { return soGheHang1; }
            set { soGheHang1 = value; }
        }
        private int soGheHang2;

        public int SoGheHang2
        {
            get { return soGheHang2; }
            set { soGheHang2 = value; }
        }
        private int giaVe;

        public int GiaVe
        {
            get { return giaVe; }
            set { giaVe = value; }
        }

        public DateTime ThoiGianKhoiHanh { get => thoiGianKhoiHanh; set => thoiGianKhoiHanh = value; }
        public DateTime ThoiGianDen { get => thoiGianDen; set => thoiGianDen = value; }
        public string MaSBDen { get => maSBDen; set => maSBDen = value; }

        public DTO_ChuyenBay() { }
        public DTO_ChuyenBay(string maCB, string sanBayDi, string sanBayDen, string maHHK, DateTime thoiGianKhoiHanh, DateTime thoiGianDen, int gheHang1, int gheHang2, int gia)
        {
            this.maCB = maCB;
            this.sanBayDi = sanBayDi;
            this.MaSBDen = sanBayDen;
            this.maHHK = maHHK;
            this.ThoiGianKhoiHanh = thoiGianKhoiHanh;
            this.thoiGianDen = thoiGianDen;
            this.soGheHang1 = gheHang1;
            this.soGheHang2 = gheHang2;
            this.giaVe = gia;
        }
    }
}

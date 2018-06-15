﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BUS_QuyDinh
    {
        DAO_QuyDinh daoQuyDinh = new DAO_QuyDinh();
        public int GetQuyDinh(string maQuyDinh)
        {
            return daoQuyDinh.GetQuyDinh(maQuyDinh);
        }
        public bool CapNhatQuyDinh(string maQuyDinh, int giaTri, DateTime thoiGianApDung)
        {
            return daoQuyDinh.CapNhatQuyDinh(maQuyDinh, giaTri, thoiGianApDung);
        }

        public DataTable LoadMaQuyDinh()
        {
            return daoQuyDinh.LoadMaQuyDinh();
        }

        public DataTable LoadQuyDinh(string MaQuyDinh)
        {
            return daoQuyDinh.LoadQuyDinh(MaQuyDinh);
        }
    }
}
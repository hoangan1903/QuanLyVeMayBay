﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_QuyDinh : DBConnect
    {
        public int GetQuyDinh(string maQuyDinh)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("GetQuyDinh", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaQuyDinh", maQuyDinh);
                comm.Parameters.Add(para);

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                
                Connection.Close();
                if (Int32.Parse(dataTable.Rows[0][0].ToString()) >= 0)
                    return Int32.Parse(dataTable.Rows[0][0].ToString());
                return -1;
            }
            catch
            {
                return -1;
            }
        }
        public bool CapNhatQuyDinh(string maQuyDinh, int giaTri, DateTime ngayApDung)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("CapNhatQuyDinh", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@MaQuyDinh", maQuyDinh);
                comm.Parameters.Add(para);

                para = new SqlParameter("@GiaTri", giaTri);
                comm.Parameters.Add(para);

                para = new SqlParameter("@NgayApDung", ngayApDung);
                comm.Parameters.Add(para);

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;

                if (comm.ExecuteNonQuery() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}

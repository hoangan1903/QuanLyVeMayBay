﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DAO_KhachHang :DBConnect
    {
        public DataTable LoadKhachHang()
        {
            Connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("Select * From KHACHHANG", Connection);
            DataTable data = new DataTable();

            adapter.Fill(data);

            Connection.Close();

            return data;
        }

        public DataTable LoadKhachHang(string CMND)
        {
            Connection.Open();
            string sql = string.Format("Select * From KHACHHANG Where CMND = '{0}'", CMND);

            SqlDataAdapter da = new SqlDataAdapter(sql, Connection);

            DataTable dt = new DataTable();

            da.Fill(dt);

            Connection.Close();

            return dt;
        }

        public DataTable LoadKhachHang(string CMND, string hoTen)
        {
            try
            {
                Connection.Open();
                string sql = string.Format("Select * From KHACHHANG Where CMND = '{0}' and HoTen = N'{1}'", CMND, hoTen);

                SqlDataAdapter da = new SqlDataAdapter(sql, Connection);

                DataTable dt = new DataTable();
                da.Fill(dt);

                Connection.Close();

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool TaoThanhVien(DTO_KhachHang dtoKhachHang)
        {
            try
            {
                Connection.Open();
                SqlCommand comm = new SqlCommand("TaoThanhVien", Connection);
                comm.CommandType = CommandType.StoredProcedure;

                SqlParameter para = new SqlParameter("@HoTen", dtoKhachHang.HoTen);
                comm.Parameters.Add(para);

                para = new SqlParameter("@Tuoi", dtoKhachHang.Tuoi);
                comm.Parameters.Add(para);

                if (dtoKhachHang.GioiTinh == true)
                {
                    para = new SqlParameter("@GioiTinh", 1);
                }
                else
                {
                    para = new SqlParameter("@GioiTinh", 0);
                }
                comm.Parameters.Add(para);

                para = new SqlParameter("@CMND", dtoKhachHang.CMND);
                comm.Parameters.Add(para);

                para = new SqlParameter("@DiaChi", dtoKhachHang.DiaChi);
                comm.Parameters.Add(para);

                para = new SqlParameter("@SDT", dtoKhachHang.SDT);
                comm.Parameters.Add(para);

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

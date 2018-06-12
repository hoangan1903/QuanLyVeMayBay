using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_PhieuDatMua:DBConnect
    {

        public bool TaoPhieuDatMua(DTO_PhieuDatMua dtoPDM)
        {
            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand("TaoPhieuDatMua", Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaVe", dtoPDM.MaVe);
                cmd.Parameters.AddWithValue("@MaKH", dtoPDM.MaKH);
                cmd.Parameters.AddWithValue("@ThoiGianDat", dtoPDM.ThoiGianDat);
                cmd.Parameters.AddWithValue("@DaThanhToan", dtoPDM.DaThanhToan);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                return false;
            }
            catch (Exception)
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

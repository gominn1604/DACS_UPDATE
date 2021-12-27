using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class StaffDA
    {
        public List<Staff> GetAll()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Ultilities.NhanVien_GetAll;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Staff> list = new List<Staff>();
            while (reader.Read())
            {
                Staff staff = new Staff();
                staff.MaNV = int.Parse(reader["MaNV"].ToString());
                staff.HoTen = reader["HoTen"].ToString();
                staff.DiaChi = reader["DiaChi"].ToString();
                staff.GioiTinh=reader["GioiTinh"].ToString();
                staff.NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                staff.SDT = reader["SoDienThoai"].ToString();
                staff.MaTK = int.Parse(reader["MaTK"].ToString());
                staff.TrangThai = bool.Parse(reader["TrangThai"].ToString());
                list.Add(staff);
            }
            conn.Close();
            return list;
        }
    }
}

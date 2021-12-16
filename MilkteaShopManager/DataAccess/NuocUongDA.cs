using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class NuocUongDA
    {
        public List<NuocUong> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.NuocUong_GetAll;

            SqlDataReader reader = command.ExecuteReader();
            List<NuocUong> list = new List<NuocUong>();
            while (reader.Read())
            {
                NuocUong nuocUong = new NuocUong();
                nuocUong.MaNuocUong = Convert.ToInt32(reader["MaNuocUong"]);
                nuocUong.TenNuocUong = reader["TenNuocUong"].ToString();
                nuocUong.MaLoai = Convert.ToInt32(reader["MaLoai"]);
                nuocUong.DonGia = Convert.ToInt32(reader["DonGia"]);
                nuocUong.DVT = reader["DonViTinh"].ToString();
                list.Add(nuocUong);
            }
            // Đóng kết nối và trả về danh sách
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(NuocUong nuocUong, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.NuocUong_InsertUpdateDelete;

            SqlParameter maNuongUongPara = new SqlParameter("@MaNuocUong", SqlDbType.Int);
            maNuongUongPara.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(maNuongUongPara).Value = nuocUong.MaNuocUong;
            //Các biến còn lại chỉ truyền vào
            cmd.Parameters.Add("@TenNuocUong", SqlDbType.NVarChar, 200).Value = nuocUong.TenNuocUong;
            cmd.Parameters.Add("@MaLoai", SqlDbType.Int).Value = nuocUong.MaLoai;
            cmd.Parameters.Add("@DonGia", SqlDbType.Int).Value = nuocUong.DonGia;
            cmd.Parameters.Add("@DonViTinh", SqlDbType.NVarChar, 100).Value = nuocUong.DVT;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;
            int result = cmd.ExecuteNonQuery();
            // Thực thi lệnh
            if (result > 0) // Nếu thành công thì trả về ID đã thêm
                return (int)cmd.Parameters["@MaNuocUong"].Value;
            return 0;
        }
    }
}

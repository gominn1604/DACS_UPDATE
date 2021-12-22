using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class LoaiNuocDA
    {
        public List<LoaiNuoc> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.LoaiNuoc_GetAll;
            // Đọc dữ liệu, trả về danh sách các đối tượng Category
            SqlDataReader reader = command.ExecuteReader();
            List<LoaiNuoc> list = new List<LoaiNuoc>();
            while (reader.Read())
            {
                LoaiNuoc loaiNuoc = new LoaiNuoc();
                loaiNuoc.MaLoai = Convert.ToInt32(reader["MaLoai"]);
                loaiNuoc.TenLoai = reader["TenLoai"].ToString();
                list.Add(loaiNuoc);
            }
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(LoaiNuoc loaiNuoc, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = Ultilities.LoaiNuoc_InsertUpdateDelete;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter IDPara = new SqlParameter("@MaLoai", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            cmd.Parameters.Add(IDPara).Value = loaiNuoc.MaLoai;
            cmd.Parameters.Add("@TenLoai", SqlDbType.NVarChar, 100).Value = loaiNuoc.TenLoai;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@MaLoai"].Value;
            return 0;
        }
    }
}

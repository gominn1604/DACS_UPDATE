using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace DataAccess
{
    public class TaiKhoanDA
    {
        public List<TaiKhoan> GetAll()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.TaiKhoan_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<TaiKhoan> list = new List<TaiKhoan>();
            while (reader.Read())
            {
                TaiKhoan tk = new TaiKhoan();
                tk.MaTK = int.Parse(reader["MaTK"].ToString());
                tk.TenTaiKhoan = reader["TenTaiKhoan"].ToString();
                tk.MatKhau = reader["MatKhau"].ToString();
                tk.HoTen = reader["HoTen"].ToString();
                tk.Email = reader["Email"].ToString();
                tk.SoDienThoai = reader["SoDienThoai"].ToString();
                tk.NgayTao = Convert.ToDateTime(reader["NgayTao"]);
                list.Add(tk);
            }
            conn.Close();
            return list;
        }

        //ham them, update tai khoan
        public int Insert_Update_Delete(TaiKhoan tk, int action)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.TaiKhoan_InsertUpdateDelete;

            SqlParameter namePara = new SqlParameter("@maTK", SqlDbType.Int);
            namePara.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(namePara).Value = tk.MaTK;
            cmd.Parameters.Add("@tenTaiKhoan", SqlDbType.NVarChar, 100).Value = tk.TenTaiKhoan;
            cmd.Parameters.Add("@matKhau", SqlDbType.NVarChar, 100).Value = tk.MatKhau;
            cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar, 1000).Value = tk.HoTen;
            cmd.Parameters.Add("@ngayTao", SqlDbType.SmallDateTime).Value = tk.NgayTao;
            cmd.Parameters.Add("@soDienThoai", SqlDbType.NVarChar, 100).Value = tk.SoDienThoai;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = tk.Email;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@maTK"].Value;
            return 0;
            conn.Close();
        }

        public SqlDataReader GetChucVu()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.PhanQuyen_GetAll;

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            dr.Close();
        }
        //ham lay id nguoi dung

    }
}

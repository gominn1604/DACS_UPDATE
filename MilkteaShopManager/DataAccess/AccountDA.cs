using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class AccountDA
    {
        public List<Account> GetAll()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.TaiKhoan_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Account> list = new List<Account>();
            while (reader.Read())
            {
                Account acc = new Account();
                acc.MaTK = Convert.ToInt32(reader["MaTK"]);
                acc.TenTaiKhoan = reader["TenTaiKhoan"].ToString();
                acc.MatKhau = reader["MatKhau"].ToString();
                acc.HoTen = reader["HoTen"].ToString();
                acc.Email = reader["Email"].ToString();
                acc.SoDienThoai = reader["SoDienThoai"].ToString();
                acc.NgayTao = Convert.ToDateTime(reader["NgayTao"]);
                list.Add(acc);
            }
            conn.Close();
            return list;
        }

        //ham them, update tai khoan
        public int Insert_Update_Delete(Account acc, int action)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.TaiKhoan_InsertUpdateDelete;

            SqlParameter namePara = new SqlParameter("@maTK", SqlDbType.Int);
            namePara.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(namePara).Value = acc.MaTK;
            cmd.Parameters.Add("@tenTaiKhoan", SqlDbType.NVarChar, 100).Value = acc.TenTaiKhoan;
            cmd.Parameters.Add("@matKhau", SqlDbType.NVarChar, 100).Value = acc.MatKhau;
            cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar, 1000).Value = acc.HoTen;
            cmd.Parameters.Add("@ngayTao", SqlDbType.SmallDateTime).Value = acc.NgayTao;
            cmd.Parameters.Add("@soDienThoai", SqlDbType.NVarChar, 100).Value = acc.SoDienThoai;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = acc.Email;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@maTK"].Value;
            return 0;
            conn.Close();
        }

        //public SqlDataReader GetChucVu()
        //{
        //    SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
        //    conn.Open();

        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = Ultilities.PhanQuyen_GetAll;

        //    SqlDataReader dr = cmd.ExecuteReader();
        //    return dr;
        //    dr.Close();
        //}
        //ham lay id nguoi dung

    }
}

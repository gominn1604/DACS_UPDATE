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
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = Ultilities.TaiKhoan_GetAll;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader=cmd.ExecuteReader();
            List<Account> list = new List<Account>();
            while (reader.Read())
            {
                Account acc = new Account();
                acc.TenTK = reader["TenTaiKhoan"].ToString();
                acc.MatKhau = reader["MatKhau"].ToString();
                acc.HoTen = reader["HoTen"].ToString();
                acc.Email = reader["Email"].ToString();
                acc.SDT = reader["SoDienThoai"].ToString();
                acc.NgayTao = DateTime.Parse(reader["NgayTao"].ToString());
                list.Add(acc);
            }
            sqlConn.Close();
            return list;
        }
    }
}

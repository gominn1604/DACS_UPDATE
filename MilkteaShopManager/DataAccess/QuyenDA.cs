using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class QuyenDA
    {
        public  List<Quyen> GetAll()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.ChucVu_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Quyen> list = new List<Quyen>();
            while (reader.Read())
            {
                Quyen quyen = new Quyen();
                quyen.MaCV = int.Parse(reader["MaCV"].ToString());
                quyen.TenChucVu = reader["TenChucVu"].ToString();
                quyen.GhiChu = reader["GhiChu"].ToString();
                list.Add(quyen);
            }
            conn.Close();
            return list;
        }

    }
}

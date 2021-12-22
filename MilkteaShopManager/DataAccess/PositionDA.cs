using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PositionDA
    {
        public List<Position> GetAll()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Ultilities.ChucVu_GetAll;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Position> list = new List<Position>();
            while (reader.Read())
            {

                Position position = new Position();
                position.MaCV = int.Parse(reader["MaCV"].ToString());
                position.TenChucVu = reader["TenChucVu"].ToString();
                position.GhiChu = reader["ChucVu"].ToString();
                list.Add(position);
            }
            conn.Close();
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillInfoDA
    {
        public void InsertBillInfoForTable(int tableId, int drinkId, int count)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.InsertBillInfoForTable;

            cmd.Parameters.Add("@maHoaDon", SqlDbType.Int).Value = tableId;
            cmd.Parameters.Add("@maNuocUong", SqlDbType.Int).Value = drinkId;
            cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = count;

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

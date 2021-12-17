using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillDA
    {
        public int GetUncheckBillIdByTableId(int tableId)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.GetUncheckBillIdByTableId;

            cmd.Parameters.Add("@maBan", SqlDbType.Int).Value = tableId;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();

            da.Fill(data);
            conn.Close();

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        public void InsertBillForTable(int tableId)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Insert_Bill;

            cmd.Parameters.Add("@maBan", SqlDbType.Int).Value = tableId;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int GetMaxBillId()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.GetMaxBillId;

            int result = (int)cmd.ExecuteScalar();
            conn.Close();

            return result;
        }

        public void CheckOut(int billId)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.CheckOut;

            cmd.Parameters.Add("@maHoaDon", SqlDbType.Int).Value = billId;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

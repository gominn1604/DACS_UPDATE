using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TableDA
    {
        public List<Table> Table_GetAll()
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Table_GetAll;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();

            da.Fill(data);
            conn.Close();

            List<Table> tableList = new List<Table>();

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public void SwitchTable(int idTable1, int idTable2)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.SwitchTable;

            cmd.Parameters.Add("@idTable1", SqlDbType.Int).Value = idTable1;
            cmd.Parameters.Add("@idTable2", SqlDbType.Int).Value = idTable2;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();

            da.Fill(data);
            conn.Close();
        }

        public int Table_InsertUpdateDelete(Table table, int action)
        {
            SqlConnection sqlConn=new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Table_InsertUpdateDelete;

            SqlParameter maBan = new SqlParameter("@MaBan", SqlDbType.Int);
            maBan.Direction = ParameterDirection.InputOutput;

            cmd.Parameters.Add(maBan).Value=table.ID;
            cmd.Parameters.Add("@TenBan", SqlDbType.NVarChar,100).Value = table.Name;
            cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = table.Status;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            // Thực thi lệnh
            if (result > 0) // Nếu thành công thì trả về ID đã thêm
                return (int)cmd.Parameters["@MaBan"].Value;
            return 0;
        }

        public void MergeTable(int idTable1, int idTable2)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.MergeTable;

            cmd.Parameters.Add("@idTable1", SqlDbType.Int).Value = idTable1;
            cmd.Parameters.Add("@idTable2", SqlDbType.Int).Value = idTable2;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();

            da.Fill(data);
            conn.Close();
        }
    }
}

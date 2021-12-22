using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Table
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public Table()
        {

        }

        public Table(int iD, string name, int status)
        {
            this.ID = iD;
            this.Name = name;
            this.Status = status;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["MaBan"];
            this.Name = row["TenBan"].ToString();
            this.Status = (int)row["TrangThaiBan"];
        }
        public int Insert_Update_Delete(Table table, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = Ultilities.Table_InsertUpdateDelete;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter IDPara = new SqlParameter("@MaBan", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            cmd.Parameters.Add(IDPara).Value = table.ID;
            cmd.Parameters.Add("@TenBan", SqlDbType.NVarChar, 100).Value = table.Name;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                return (int)cmd.Parameters["@Maban"].Value;
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DrinkDetailsDA
    {
        public List<DrinkDetails> GetListDrinkDetailsByTableId(int tableId)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.GetListDrinkDetailsByTableId;

            cmd.Parameters.Add("@maBan", SqlDbType.Int).Value = tableId;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();

            da.Fill(data);
            conn.Close();

            List<DrinkDetails> listDrinkDetails = new List<DrinkDetails>();

            foreach (DataRow item in data.Rows)
            {
                DrinkDetails drinkDetails = new DrinkDetails(item);
                listDrinkDetails.Add(drinkDetails);
            }
            return listDrinkDetails;
        }
    }
}

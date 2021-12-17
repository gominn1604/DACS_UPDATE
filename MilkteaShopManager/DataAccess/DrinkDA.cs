using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DrinkDA
    {
        public List<Drink> GetListDrinkByCategoryId(int categoryId)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.GetListDrinkByCategoryId;

            cmd.Parameters.Add("@maLoai", SqlDbType.Int).Value = categoryId;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();

            da.Fill(data);
            conn.Close();

            List<Drink> listDrink = new List<Drink>();
            foreach (DataRow item in data.Rows)
            {
                Drink drink = new Drink(item);
                listDrink.Add(drink);
            }
            return listDrink;
        }
    }
}

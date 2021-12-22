using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DrinkDetails
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int TotalAmount { get; set; }

        public DrinkDetails(DataRow row)
        {
            this.Name = row["TenNuocUong"].ToString();
            this.Price = (int)row["DonGia"];
            this.Count = (int)row["SoLuong"];
            this.TotalAmount = (int)row["ThanhTien"];
        }
    }
}

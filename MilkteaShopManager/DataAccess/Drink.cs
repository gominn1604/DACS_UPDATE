using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Unit { get; set; }

        public Drink(DataRow row)
        {
            this.Id = (int)row["MaNuocUong"];
            this.Name = row["TenNuocUong"].ToString();
            this.CategoryId = (int)row["MaLoai"];
            this.Price = (int)row["DonGia"];
            this.Unit = row["DonViTinh"].ToString();
        }
    }
}

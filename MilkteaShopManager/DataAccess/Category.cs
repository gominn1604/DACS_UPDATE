using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Category(DataRow row)
        {
            this.ID = (int)row["MaLoai"];
            this.Name = row["TenLoai"].ToString();
        }
    }
}

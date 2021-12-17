using System;
using System.Collections.Generic;
using System.Data;
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
    }
}

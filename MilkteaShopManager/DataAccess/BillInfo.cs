using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillInfo
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int DrinkId { get; set; }
        public int Count { get; set; }

        public BillInfo(DataRow row)
        {
            this.Id = (int)row["MaChiTietHoaDon"];
            this.BillId = (int)row["MaHoaDon"];
            this.DrinkId = (int)row["MaNuocUong"];
            this.Count = (int)row["SoLuong"];
        }
    }
}

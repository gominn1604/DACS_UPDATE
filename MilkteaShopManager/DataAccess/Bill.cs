using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Bill
    {
        public int Id { get; set; }

        public int Discount { get; set; }
        public int Tax { get; set; }
        public int Status { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime DateCheckOut { get; set; }
        public int TableId { get; set; }
        public string Account { get; set; }

        public Bill(DataRow row)
        {
            this.Id = (int)row["MaHoaDon"];
            this.Discount = (int)row["GiamGia"];
            this.Tax = (int)row["Thue"];
            this.Status = (int)row["TrangThaiHD"];
            this.DateCheckIn = (DateTime)row["NgayTao"];
            this.DateCheckOut = (DateTime)row["NgayThanhToan"];
            this.TableId = (int)row["MaBan"];
            this.Account = row["TaiKhoanTao"].ToString();
        }
    }
}

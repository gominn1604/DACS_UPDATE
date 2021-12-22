using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NuocUongBL
    {
        NuocUongDA nuocUongDA = new NuocUongDA();

        public List<NuocUong> GetAll()
        {
            return nuocUongDA.GetAll();
        }

        public NuocUong GetByID(int maNuocUong)
        {
            List<NuocUong> list = GetAll();

            foreach (var item in list)
            {
                if (item.MaNuocUong == maNuocUong) // Nếu gặp khoá chính
                    return item; // thì trả về kết quả
            }
            return null;
        }
        //Phương thức tìm kiếm theo khoá
        public List<NuocUong> Find(string key)
        {
            List<NuocUong> list = GetAll(); // Lấy hết
            List<NuocUong> result = new List<NuocUong>();
            // Duyệt theo danh sách
            foreach (var item in list)
            {
                // Nếu từng trường chứa từ khoá
                if (item.MaNuocUong.ToString().Contains(key)
                || item.TenNuocUong.Contains(key)
                || item.MaLoai.ToString().Contains(key)
                || item.DonGia.ToString().Contains(key)
                || item.DVT.Contains(key))
                    result.Add(item); // Thì thêm vào danh sách kết quả
            }
            return result;
        }
        //Phương thức thêm dữ liệu
        public int Insert(NuocUong nuocUong)
        {
            return nuocUongDA.Insert_Update_Delete(nuocUong, 0);
        }
        //Phương thức cập nhật dữ liệu
        public int Update(NuocUong nuocUong)
        {
            return nuocUongDA.Insert_Update_Delete(nuocUong, 1);
        }
        //Phương thức xoá dữ liệu với ID cho trước
        public int Delete(NuocUong nuocUong)
        {
            return nuocUongDA.Insert_Update_Delete(nuocUong, 2);
        }
    }
}

using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountBL
    {

        //Đối tượng CategoryDA từ DataAccess
        AccountDA accDA = new AccountDA();
        //Phương thức lấy hết dữ liệu
        public List<Account> GetAll()
        {
            return accDA.GetAll();
        }
        //public SqlDataReader Get_PhanQuyen()
        //{
        //    return accDA.GetChucVu();
        //}
        // Phương thức lấy về đối tượng Food theo khoá chính
        public Account GetByName(string name)
        {
            List<Account> list = GetAll();
            foreach (var item in list)
            {
                if (item.TenTaiKhoan == name)
                {
                    return item;
                }
            }
            return null;
        }
        //public List<TaiKhoan> Find(string key)
        //{
        //    List<TaiKhoan> list = GetAll();
        //    List<TaiKhoan> result = new List<TaiKhoan>();

        //    foreach (var item in list){
        //        if (item.TenTaiKhoan.Contains(key)
        //        || item.MatKhau.Contains(key)
        //        || item.HoTen.Contains(key)
        //        || item.NgayTao.Contains(key)
        //        || item.Email.Contain(key)
        //        || item.SoDienThoai.Contain(key)
        //        result.Add(item);
        //        )
        //    }
        //    return result;
        //}

        // phương thức thêm dữ liệu
        public int Insert(Account acc)
        {
            return accDA.Insert_Update_Delete(acc, 0);
        }
        // phương thức xóa dữ liệu
        public int Delete(Account acc)
        {
            return accDA.Insert_Update_Delete(acc, 2);
        }
        // phương thức sửa dữ liệu
        public int Update(Account acc)
        {
            return accDA.Insert_Update_Delete(acc, 1);
        }

        //kiểm tra đăng nhập

        //phân quyền

        //public int GetRoleID(string username)
        //{
        //    List<TaiKhoan> list = GetAll();
        //    foreach (var tk in list)
        //        if (tk.TenTaiKhoan == username)
        //            return tk.;
        //    return -1;
        //}

        //public bool KiemTraDangNhap(string tenTaiKhoan, string matKhau)
        //{
        //    List<TaiKhoan> list = GetAll();
        //    foreach (var tk in list)
        //        if (tk.TenTaiKhoan== tenTaiKhoan && tk.MatKhau == matKhau   )
        //            return true;
        //    return false;
        //}

    }
}

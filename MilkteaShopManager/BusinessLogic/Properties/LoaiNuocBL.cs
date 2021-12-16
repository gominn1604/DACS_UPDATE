using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic.Properties
{
    public class LoaiNuocBL
    {
        LoaiNuocDA loaiNuocDA = new LoaiNuocDA();
        public List<LoaiNuoc> GetAll()
        {
            return loaiNuocDA.GetAll();
        }

        public int Insert(LoaiNuoc loaiNuoc)
        {
            return loaiNuocDA.Insert_Update_Delete(loaiNuoc, 0);
        }

        public int Update(LoaiNuoc loaiNuoc)
        {
            return loaiNuocDA.Insert_Update_Delete(loaiNuoc, 1);
        }

        public int Delete(LoaiNuoc loaiNuoc)
        {
            return loaiNuocDA.Insert_Update_Delete(loaiNuoc, 2);
        }
    }
}

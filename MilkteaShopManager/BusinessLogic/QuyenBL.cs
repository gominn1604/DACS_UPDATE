using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class QuyenBL
    {
        QuyenDA quyenDA = new QuyenDA();
        public List<Quyen> GetAll()
        {
            return quyenDA.GetAll();
        }
    }
}

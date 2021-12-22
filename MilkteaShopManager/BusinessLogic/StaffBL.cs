using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class StaffBL
    {
        StaffDA staff = new StaffDA();
        public List<Staff> GetAll()
        {
            return staff.GetAll();
        }
    }
}

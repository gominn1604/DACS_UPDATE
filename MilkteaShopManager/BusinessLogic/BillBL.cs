using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillBL
    {
        BillDA billDA = new BillDA();

        public int GetUncheckBillIdByTableId(int tableId)
        {
            return billDA.GetUncheckBillIdByTableId(tableId);
        }

        public int GetMaxBillId()
        {
            return billDA.GetMaxBillId();
        }    
    }
}

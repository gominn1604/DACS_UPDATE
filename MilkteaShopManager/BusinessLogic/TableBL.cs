using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TableBL
    {
        TableDA tableDA = new TableDA();

        public List<Table> GetAll()
        {
            return tableDA.Table_GetAll();
        }
    }
}

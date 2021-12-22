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
        public int Insert (Table table)
        {
            return tableDA.Table_InsertUpdateDelete(table, 0);
        }
        public int Update(Table table)
        {
            return tableDA.Table_InsertUpdateDelete(table, 1);
        }
        public int Delete(Table table)
        {
            return tableDA.Table_InsertUpdateDelete(table, 2);
        }
    }
}

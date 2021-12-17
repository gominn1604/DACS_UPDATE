using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DrinkDetailsBL
    {
        DrinkDetailsDA drinkDetailsDA = new DrinkDetailsDA();

        public List<DrinkDetails> GetListDrinkDetailsByTableId(int tableId)
        {
            return drinkDetailsDA.GetListDrinkDetailsByTableId(tableId);
        }
    }
}

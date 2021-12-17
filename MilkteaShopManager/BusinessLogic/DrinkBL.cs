using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DrinkBL
    {
        DrinkDA drinkDA = new DrinkDA();

        public List<Drink> GetListDrinkByCategoryId(int categoryId)
        {
            return drinkDA.GetListDrinkByCategoryId(categoryId);
        }
    }
}

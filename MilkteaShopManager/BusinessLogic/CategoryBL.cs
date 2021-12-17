using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CategoryBL
    {
        CategoryDA categoryDA = new CategoryDA();

        public List<Category> GetListCategory()
        {
            return categoryDA.GetListCategory();
        }
    }
}

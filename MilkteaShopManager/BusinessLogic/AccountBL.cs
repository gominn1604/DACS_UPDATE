using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountBL
    {
        AccountDA accDA=new AccountDA();
        public List<Account> GetAll()
        {
            return accDA.GetAll();
        }
    }
}

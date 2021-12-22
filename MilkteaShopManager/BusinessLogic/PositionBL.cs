using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PositionBL
    {
        PositionDA positionDA = new PositionDA();
        public List<Position> GetAll()
        {
            return positionDA.GetAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfCrestoria;

namespace TaleOfCrestoria.Database.Read
{
    class Unit_Unit_Read
    {
        DatabaseAccess db = new DatabaseAccess();

        public List<Unit_Unit> GetDataBySQLString(string sqlstring)
        {
            DataContext context = db.connect();
            List<Unit_Unit> unit_unit = (context.ExecuteQuery<Unit_Unit>(sqlstring).ToList());
            return unit_unit;
        }
    }
}

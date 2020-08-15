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
        Tools tools = new Tools();

        public List<Unit_Unit> GetID(string name)
        {
            int id = 0;
            DataContext context = db.connect();

            //First letter to Upper
            name = tools.UppercaseFirst(name);
            List<Unit_Unit> unit_unit = (context.ExecuteQuery<Unit_Unit>($"select * from unit_unit where name = \"{name}\"").ToList());
            return unit_unit;
        }       


        //public string GetUnit()
        //{
        //    string tmp = "";
        //    DataContext context = db.connect();
        //    List<Unit_Unit> unit_unit = (context.ExecuteQuery<Unit_Unit>("select * from unit_unit")).ToList();
        //    foreach (var unit in unit_unit)
        //    {
        //        tmp += $"```ID {unit.id} Name: {unit.name}\n```";
        //    }
        //    return tmp;
        //}
    }
}

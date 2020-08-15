using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfCrestoria.Database;
using TaleOfCrestoria.Database.Read;
using Discord.Commands;

namespace TaleOfCrestoria.Modules
{
    public class Commands_Unit_Unit : ModuleBase<SocketCommandContext>
    {
        //member
        Unit_Unit_Read unit = new Unit_Unit_Read();

        //commands
        [Command("unit")]
        public async Task Unit(string name)
        {
            List<Unit_Unit> id = unit.GetID(name);
            string tmp = "";
            foreach (var unit in id)
            {
                tmp += $"ID: {unit.id} | Unit: {unit.name} [{unit.secondname}] | Grade: {unit.grade}\n";
            }
            await ReplyAsync(
                $"```Use \"$unit <id> unit/stone\" for selecting the right unit.\n" +
                $"You can chose between Unit Stats ot Stone Stats\n\n" + 
                $"Available Units with the name {name}\n" +
                "-----------------------------------\n" +
                $"{tmp}```");
        }

        [Command("unit")]
        public async Task UnitIdUnit(int id, string type)
        {
            if (type == "unit")
            {

            }
            else if (type == "stone")
            {
                await ReplyAsync("Not implementet yet");
            }
        }
    }
}

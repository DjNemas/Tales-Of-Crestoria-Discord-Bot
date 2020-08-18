using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaleOfCrestoria.Database;

namespace TaleOfCrestoria.Modules
{
    public class Commands_Add_And_Update : ModuleBase<SocketCommandContext>
    {
        private Unit_Unit unitData = new Unit_Unit();
        private List<Unit_Unit> unitDB = new List<Unit_Unit>();
        private Tools tools = new Tools();
        private string queryString;
        private int check;

        // add new units into database
        [Command("dbadd")]
        public async Task dbAdd(string name, string secondname)
        {
            // Check if Unit already exist
            this.queryString = $"SELECT COUNT(*) FROM \"unit_unit\" WHERE \"secondname\" = \"{secondname}\"";
            check = unitData.CheckIfAlreadyExist(queryString);
            // Creat new unit when not in database
            if (check == 0)
            {
                name = this.tools.StringUppercaseFirst(name);
                this.queryString = $"INSERT INTO \"unit_unit\" (\"name\", \"secondname\") VALUES (\"{name}\", \"{secondname}\") ";
                this.unitData.SendDataDB(this.queryString);
                this.queryString = $"SELECT * FROM \"unit_unit\" WHERE \"secondname\" = \"{secondname}\"";
                this.unitDB = unitData.GetDataDB(queryString);
                await ReplyAsync($"DONE```ID: {this.unitDB[0].id} | Name: {this.unitDB[0].name} [{this.unitDB[0].secondname}]```Unit is in Database now!");
            }
            // Throw Exeption if already exist
            else
            {
                await ReplyAsync("Unit already in Database!");
            }
        }

        [Command("dbupdate")]
        public async Task dbUpdate(string id, string type, string stat, string value)
        {
            type = this.tools.StringToLower(type);
            stat = this.tools.StringToLower(stat);
            if (stat == "name")
            {
                value = tools.StringUppercaseFirst(value);
            }
            if (type == "unit")
            {
                if (stat == "id")
                {
                    await ReplyAsync("Its not allowed to Update the ID!");
                }
                this.queryString = $"UPDATE or IGNORE unit_unit SET \"{stat}\" = \"{value}\" WHERE  \"id\" = \"{id}\"";
                check = this.unitData.SendDataDB(this.queryString);
                if (check == 0 && stat == "secondname")
                {
                    await ReplyAsync($"> secondname must be unique for each unit!");
                }
                else if (check == 0)
                {
                    await ReplyAsync($"> Something went wrong. :c\n> Maybe u forgot to use \"\" for a value with spaces?\n> Maybe you misspelled the type? It need to be exact.");
                }
                else
                {
                    await ReplyAsync($"DONE! {stat} was set to {value} for unit ID {id}");
                }
                
            }
            else if (type == "stone")
            {
                await ReplyAsync($"Not implementet yet!");
            }

            

        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaleOfCrestoria.Database;
using Discord.Commands;

namespace TaleOfCrestoria.Modules
{
    public class Commands_Unit_Unit : ModuleBase<SocketCommandContext>
    {
        //member
        private Tools tools = new Tools();
        private InitBot prf = new InitBot();
        private List<Unit_Unit> id = new List<Unit_Unit>();
        private DatabaseAccess db = new DatabaseAccess();
        private Unit_Unit allUnitsData = new Unit_Unit();
        private string queryString;

        [Command("unit")]
        public async Task Unit()
        {
            await ReplyAsync($"Write \"{this.prf.Prefix}unit <name>\" to get a list of available units with the name.");
        }

        //commands
        // Get All or specific unit from database and Replay it to Chat Async
        [Command("unit")]
        public async Task UnitName(string name)
        {
            name = this.tools.StringUppercaseFirst(name);
            this.queryString = "";
            if (name == "All")
            {
                // Query for all Units with GroupBy name than secondname
                this.queryString = $"SELECT * FROM \"unit_unit\" ORDER BY \"name\", \"secondname\"";
                this.id = this.allUnitsData.GetDataDB(this.queryString);
                this.db.CloseConnection();
            }
            else
            {
                // Query to get id for specific unitname
                this.queryString = $"SELECT * FROM \"unit_unit\" WHERE \"name\" = \"{name}\"";
                this.id = this.allUnitsData.GetDataDB(this.queryString);
                this.db.CloseConnection();
            }
            if (this.queryString != "")
            {
                string text = $"> **Use \"{this.prf.Prefix}unit <id> unit/stone\"** for selecting the right unit.\n" +
                    $"> You can chose between **Unit Stats** ot **Stone Stats**\n\n" +
                    $"> **__Available Units with the name {name}__**\n";
                if (this.id.Count == 0)
                {
                    text += $"> No unit with the name {name} was found.";
                    await ReplyAsync(text);
                }

                string unitString;
                string unitStringSecond = "";
                bool send = false;
                int count = 0;
                foreach (var unit in this.id)
                {
                    unitString = $"> ID: {unit.id} | Unit: **{unit.name}** [{unit.secondname}] | Grade: {unit.grade}\n";
                    // this will check if message is under 2000 character, otherwise exeption will be throw
                    if (text.Count() + unitString.Count() < 2000)
                    {
                        text += unitString;                      
                        if (count == this.id.Count - 1)
                        {
                            await ReplyAsync(text);
                        }
                    }
                    else if (text.Count() + unitString.Count() >= 2000 && send == false)
                    {
                        await ReplyAsync(text);
                        send = true;
                        unitStringSecond = unitString;
                    }
                    else if (unitStringSecond.Count() + unitString.Count() < 2000 )
                    {
                        unitStringSecond += unitString;
                        if (count == this.id.Count - 1)
                        {
                            await ReplyAsync(unitStringSecond);
                        }
                    }
                    else if (unitStringSecond.Count() + unitString.Count() >= 2000)
                    {
                        await ReplyAsync(unitStringSecond);
                        unitStringSecond = unitString;
                    }
                    count++;
                }
            }
        }

        [Command("unit")]
        public async Task UnitIdType(int unitId, string type)
        {
            type = this.tools.StringToLower(type);
            if (type == "unit")
            {
                this.queryString = $"SELECT * FROM \"unit_unit\" WHERE id = \"{unitId}\"";
                this.id = this.allUnitsData.GetDataDB(this.queryString);
                this.db.CloseConnection();

                string tmp = "";
                foreach (var unit in id)
                {
                    tmp +=
                        $"Unit {unit.name} [{unit.secondname} | Grade {unit.grade} | Element: {unit.element} | {unit.weapontype}]\n\n" +
                        "Base Stats\n" +
                        $"Max LVL: {unit.maxlvl}\n" +
                        $"Max HP: {unit.maxhp}\n" +
                        $"Max ATK: {unit.maxatk}\n" +
                        $"Max DEF: {unit.maxdef}\n" +
                        "\nMax Awake\n" +
                        $"Name {unit.max_awake_name}\n" +
                        $"Skill {unit.max_awake_passive}\n" +
                        "\nMystic Artes\n" +
                        $"Name: {unit.ma_name}\n" +
                        $"Max LVL: {unit.ma_max_lvl}\n" +
                        $"Max ATK: {unit.ma_max_atk}\n" +
                        $"Max HITS: {unit.ma_max_hits}\n" +
                        $"Enemys: {unit.ma_enemy}\n" +
                        $"OL Cost: {unit.ma_ol_cost}\n" +
                        $"Skill: {unit.ma_add_skill}\n" +
                        "\nSkill 1\n" +
                        $"Name: {unit.skill1_name}\n" +
                        $"Max LVL: {unit.skill1_max_lvl}\n" +
                        $"Max ATK: {unit.skill1_max_atk}\n" +
                        $"Max HITS: {unit.skill1_max_hits}\n" +
                        $"Enemys: {unit.skill1_enemy}\n" +
                        $"Cooldown: {unit.skill1_cd}\n" +
                        $"Skill: {unit.skill1_add_skill}\n" +
                        "\nSkill 1\n" +
                        $"Name: {unit.skill2_name}\n" +
                        $"Max LVL: {unit.skill2_max_lvl}\n" +
                        $"Max ATK: {unit.skill2_max_atk}\n" +
                        $"Max HITS: {unit.skill2_max_hits}\n" +
                        $"Enemys: {unit.skill2_enemy}\n" +
                        $"Cooldown: {unit.skill2_cd}\n" +
                        $"Skill: {unit.skill2_add_skill}\n" +
                        "\nNormal Attack\n" +
                        $"Name: {unit.normal_name}\n" +
                        $"Max ATK: {unit.normal_atk}\n" +
                        $"Max HITS: {unit.normal_hits}\n" +
                        $"Enemys: {unit.normal_enemy}\n" +
                        $"Skill: {unit.skill2_add_skill}\n";
                }
                if (tmp.Count() > 2000)
                {
                    await ReplyAsync($"Replay Message to Long, pls contact the Developer for fix! DjNemas#0185");
                }
                await ReplyAsync($"```\n{tmp}```");
            }
            // This need to be moved later
            else if (type == "stone")
            {
                await ReplyAsync("Not implementet yet Stone");
            }
            else
            {
                await ReplyAsync("Use **Unit** or **Stone** as Parameter");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfCrestoria.Database;
using Discord.Commands;
using System.Data.Linq;
using System.Net;

namespace TaleOfCrestoria.Modules
{
    public class Commands_Unit_Unit : ModuleBase<SocketCommandContext>
    {
        //member
        private Tools tools = new Tools();
        private InitBot prf = new InitBot();
        private static DatabaseAccess db = new DatabaseAccess();
        private static DataContext context = db.connect();

        [Command("unit")]
        public async Task Unit()
        {
            await ReplyAsync($"Write \"{prf.Prefix}unit <name>\" to get a list of available units with the name.");
        }

        //commands
        [Command("unit")]
        public async Task UnitName(string name)
        {
            name = tools.StringUppercaseFirst(name);
            string queryString = "";
            if (name == "All")
            {                
                await ReplyAsync("Not implemented yet");                
                //queryString = $"select * from unit_unit";
            }
            else
            {
                queryString = $"select * from unit_unit where name = \"{name}\"";
            }
            if (queryString != "")
            {
                List<Unit_Unit> id = (context.ExecuteQuery<Unit_Unit>(queryString).ToList());
                string tmp = "";
                foreach (var unit in id)
                {
                    tmp += $"ID: {unit.id} | Unit: {unit.name} [{unit.secondname}] | Grade: {unit.grade}\n";
                }
                await ReplyAsync(
                    $"> **Use \"{prf.Prefix}unit <id> unit/stone\"** for selecting the right unit.\n" +
                    $"> You can chose between **Unit Stats** ot **Stone Stats**\n" +
                    $"```Available Units with the name {name}\n" +
                    "-----------------------------------\n" +
                    $"{tmp}```");
            }
        }

        [Command("unit")]
        public async Task UnitIdType(int id, string type)
        {
            type = tools.StringToLower(type);
            if (type == "unit")
            {
                string queryString = $"select * from unit_unit where id = \"{id}\"";
                List<Unit_Unit> unitdb = (context.ExecuteQuery<Unit_Unit>(queryString).ToList());
                string tmp = "";
                foreach (var unit in unitdb)
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
                await ReplyAsync($"```\n{tmp}```");
            }
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

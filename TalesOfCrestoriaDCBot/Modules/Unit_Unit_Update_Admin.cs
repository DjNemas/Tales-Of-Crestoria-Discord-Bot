using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleOfCrestoria.Database;

namespace TaleOfCrestoria.Modules
{
    [RequireUserPermission(GuildPermission.BanMembers, Group = "Admin")]
    [RequireOwner(Group = "Admin")]
    public class Unit_Unit_Update_Admin : ModuleBase<SocketCommandContext>
    {
        private Tools tools = new Tools();
        private static DatabaseAccess db = new DatabaseAccess();
        private DataContext context = db.connect();


        [Command("update")]
        public async Task UpdateUnits(string unit)
        {
            if (unit == "unit")
            {
                await ReplyAsync("Update in progres, wait until bot respons with **Done**");

                System.Net.WebClient client8 = new System.Net.WebClient();
                var html = client8.DownloadString("https://www.tocdb.xyz/api/characters/name/");
                dynamic data = JArray.Parse(html);
                // Trimm every string that contains ' as character. The SQL Querey won't work with ' in variables
                data = tools.TrimmVariablesForUnitsQuery(data);

                foreach (var data2 in data)
                {
                    string titleQuery = $"select secondname from unit_unit where secondname = \"{data2.title}\"";
                    List<Unit_Unit> title = (context.ExecuteQuery<Unit_Unit>(titleQuery).ToList());
                    if (title.Count == 0 || title[0].secondname != data2.title.ToString())
                    {
                        string queryString = "INSERT INTO \"main\".\"unit_unit\"" +
                                         "(\"name\", \"secondname\", \"grade\", \"element\", \"weapontype\", \"maxlvl\", \"maxhp\", \"maxatk\", \"maxdef\", \"max_awake_name\", \"max_awake_passive\", \"ma_name\", \"ma_max_atk\", \"ma_max_hits\", \"ma_enemy\", \"ma_ol_cost\", \"ma_max_lvl\", \"ma_add_skill\", \"skill1_name\", \"skill1_max_atk\", \"skill1_max_hits\", \"skill1_enemy\", \"skill1_cd\", \"skill1_max_lvl\", \"skill1_add_skill\", \"skill2_name\", \"skill2_max_atk\", \"skill2_max_hits\", \"skill2_enemy\", \"skill2_cd\", \"skill2_max_lvl\", \"skill2_add_skill\", \"normal_name\", \"normal_atk\", \"normal_hits\", \"normal_enemy\", \"normal_add_skill\", \"image\")" +
                                         " VALUES " +
                                         $"('{data2.name}', '{data2.title}', '{data2.rarity}', '{data2.element}', '{data2.type}', '0', '{data2.hp}', '{data2.attack}', '{data2.defense}', '', '', '{data2.ma_name}', '{data2.ma_dmg}', '{data2.ma_hit}', '', '{data2.ma_ol}', '0', '{data2.ma_ef}', '{data2.a1_name}', '{data2.a1_dmg}', '{data2.a1_hit}', '', '{data2.a1_cd}', '0', '{data2.a1_ef}', '{data2.a2_name}', '{data2.a2_dmg}', '{data2.a2_hit}', '', '{data2.a2_cd}', '0', '{data2.a2_ef}', 'Normal Attack', '100', '0', '', '', '');";

                        context.ExecuteQuery<Unit_Unit>(queryString);
                    }
                }
                Console.WriteLine("Done");
                await ReplyAsync("**Done**");
            }
            
        }
    }
}

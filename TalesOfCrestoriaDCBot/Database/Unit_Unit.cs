using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace TaleOfCrestoria.Database
{
    public class Unit_Unit
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string secondname { get; set; }
        public string grade { get; set; }
        public string element { get; set; }
        public string weapontype { get; set; }
        public int? maxlvl { get; set; }
        public int? maxhp { get; set; }
        public int? maxatk { get; set; }
        public int? maxdef { get; set; }
        public string max_awake_name { get; set; }
        public string max_awake_passive { get; set; }
        public string ma_name { get; set; }
        public int? ma_max_atk { get; set; }
        public int? ma_max_hits { get; set; }
        public string ma_enemy { get; set; }
        public int? ma_ol_cost { get; set; }
        public int? ma_max_lvl { get; set; }
        public string ma_add_skill { get; set; }
        public string skill1_name { get; set; }
        public int? skill1_max_atk { get; set; }
        public int? skill1_max_hits { get; set; }
        public string skill1_enemy { get; set; }
        public int? skill1_cd { get; set; }
        public int? skill1_max_lvl { get; set; }
        public string skill1_add_skill { get; set; }
        public string skill2_name { get; set; }
        public int? skill2_max_atk { get; set; }
        public int? skill2_max_hits { get; set; }
        public string skill2_enemy { get; set; }
        public int? skill2_cd { get; set; }
        public int? skill2_max_lvl { get; set; }
        public string skill2_add_skill { get; set; }
        public string normal_name { get; set; }
        public int? normal_atk { get; set; }
        public int? normal_hits { get; set; }
        public string normal_enemy { get; set; }
        public string normal_add_skill { get; set; }
        public string image { get; set; }

        public List<Unit_Unit> GetDataDB(string queryString)
        {
            DatabaseAccess db = new DatabaseAccess();
            List<Unit_Unit> data = new List<Unit_Unit>();
            SQLiteCommand fmd = db.OpenConnect(queryString);
            SQLiteDataReader r = fmd.ExecuteReader();
            Tools tool = new Tools();
            int i = 0;
            while (r.Read())
            {
                data.Add(new Unit_Unit());
                data[i].id = tool.IsNullRetun(r["id"]);
                data[i].name = Convert.ToString(r["name"]);
                data[i].secondname = Convert.ToString(r["secondname"]);
                data[i].grade = Convert.ToString(r["grade"]);
                data[i].element = Convert.ToString(r["element"]);
                data[i].weapontype = Convert.ToString(r["weapontype"]);
                data[i].maxlvl = tool.IsNullRetun(r["maxlvl"]);
                data[i].maxhp = tool.IsNullRetun(r["maxhp"]);
                data[i].maxatk = tool.IsNullRetun(r["maxatk"]);
                data[i].maxdef = tool.IsNullRetun(r["maxdef"]);
                data[i].max_awake_name = Convert.ToString(r["max_awake_name"]);
                data[i].max_awake_passive = Convert.ToString(r["max_awake_passive"]);
                data[i].ma_name = Convert.ToString(r["ma_name"]);
                data[i].ma_max_atk = tool.IsNullRetun(r["ma_max_atk"]);
                data[i].ma_max_hits = tool.IsNullRetun(r["ma_max_hits"]);
                data[i].ma_enemy = Convert.ToString(r["ma_enemy"]);
                data[i].ma_ol_cost = tool.IsNullRetun(r["ma_ol_cost"]);
                data[i].ma_max_lvl = tool.IsNullRetun(r["ma_max_lvl"]);
                data[i].ma_add_skill = Convert.ToString(r["ma_add_skill"]);
                data[i].skill1_name = Convert.ToString(r["skill1_name"]);
                data[i].skill1_max_atk = tool.IsNullRetun(r["skill1_max_atk"]);
                data[i].skill1_max_hits = tool.IsNullRetun(r["skill1_max_hits"]);
                data[i].skill1_enemy = Convert.ToString(r["skill1_enemy"]);
                data[i].skill1_cd = tool.IsNullRetun(r["skill1_cd"]);
                data[i].skill1_max_lvl = tool.IsNullRetun(r["skill1_max_lvl"]);
                data[i].skill1_add_skill = Convert.ToString(r["skill1_add_skill"]);
                data[i].skill2_name = Convert.ToString(r["skill2_name"]);
                data[i].skill2_max_atk = tool.IsNullRetun(r["skill2_max_atk"]);
                data[i].skill2_max_hits = tool.IsNullRetun(r["skill2_max_hits"]);
                data[i].skill2_enemy = Convert.ToString(r["skill2_enemy"]);
                data[i].skill2_cd = tool.IsNullRetun(r["skill2_cd"]);
                data[i].skill2_max_lvl = tool.IsNullRetun(r["skill2_max_lvl"]);
                data[i].skill2_add_skill = Convert.ToString(r["skill2_add_skill"]);
                data[i].normal_name = Convert.ToString(r["normal_name"]);
                data[i].normal_atk = tool.IsNullRetun(r["normal_atk"]);
                data[i].normal_hits = tool.IsNullRetun(r["normal_hits"]);
                data[i].normal_enemy = Convert.ToString(r["normal_enemy"]);
                data[i].normal_add_skill = Convert.ToString(r["normal_add_skill"]);
                data[i].image = Convert.ToString(r["image"]);
                i++;
            }
            db.CloseConnection();
            return data;
        }

        private List<Unit_Unit> GetDataTOCDBJson()
        {
            List<Unit_Unit> externalData = new List<Unit_Unit>();
            System.Net.WebClient client8 = new System.Net.WebClient();
            string html = client8.DownloadString("https://www.tocdb.xyz/api/characters/name/");
            dynamic datas = JArray.Parse(html);

            int i = 0;
            foreach (var data in datas)
            {
                externalData.Add(new Unit_Unit());
                externalData[i].name = Convert.ToString(data["name"]);
                externalData[i].secondname = Convert.ToString(data["title"]);
                externalData[i].grade = Convert.ToString(data["rarity"]);
                externalData[i].element = Convert.ToString(data["element"]);
                externalData[i].weapontype = Convert.ToString(data["type"]);
                externalData[i].maxhp = Convert.ToInt32(data["hp"]);
                externalData[i].maxatk = Convert.ToInt32(data["attack"]);
                externalData[i].maxdef = Convert.ToInt32(data["defense"]);
                externalData[i].max_awake_passive = Convert.ToString(data["p1"]) + "\n" + Convert.ToString(data["p2"]);
                externalData[i].ma_name = Convert.ToString(data["ma_name"]);
                externalData[i].ma_max_atk = Convert.ToInt32(data["ma_dmg"]);
                externalData[i].ma_max_hits = Convert.ToInt32(data["ma_hit"]);
                externalData[i].ma_ol_cost = Convert.ToInt32(data["ma_ol"]);
                externalData[i].ma_add_skill = Convert.ToString(data["ma_ef"]);
                externalData[i].skill1_name = Convert.ToString(data["a1_name"]);
                externalData[i].skill1_max_atk = Convert.ToInt32(data["a1_dmg"]);
                externalData[i].skill1_max_hits = Convert.ToInt32(data["a1_hit"]);
                externalData[i].skill1_cd = Convert.ToInt32(data["a1_cd"]);
                externalData[i].skill1_add_skill = Convert.ToString(data["a1_ef"]);
                externalData[i].skill2_name = Convert.ToString(data["a2_name"]);
                externalData[i].skill2_max_atk = Convert.ToInt32(data["a2_dmg"]);
                externalData[i].skill2_max_hits = Convert.ToInt32(data["a2_hit"]);
                externalData[i].skill2_cd = Convert.ToInt32(data["a2_cd"]);
                externalData[i].skill2_add_skill = Convert.ToString(data["a2_ef"]);
                externalData[i].normal_name = "Normal Attack";
                externalData[i].normal_atk = 100;
                i++;
            }
            return externalData;
        }
        public void SendTOCDBDataToBotDB()
        {
            DatabaseAccess db1 = new DatabaseAccess();
            DatabaseAccess db2 = new DatabaseAccess();
            List<Unit_Unit> unitDatas = GetDataTOCDBJson();
            int effectedRowes = 0;
            foreach (var unitData in unitDatas)
            {
                string queryString = $"SELECT * FROM \"unit_unit\" WHERE secondname = \"{unitDatas[0].secondname}\"";
                SQLiteCommand fmd1 = db1.OpenConnect(queryString);
                SQLiteDataReader r = fmd1.ExecuteReader();
                bool check = r.Read();
                if (check == false)
                {
                    queryString = "INSERT INTO \"unit_unit\" " +
                    "(\"name\"," +
                    " \"secondname\"," +
                    " \"grade\"," +
                    " \"element\"," +
                    " \"weapontype\"," +
                    " \"maxhp\"," +
                    " \"maxatk\"," +
                    " \"maxdef\"," +
                    " \"max_awake_passive\"," +
                    " \"ma_name\"," +
                    " \"ma_max_atk\"," +
                    " \"ma_max_hits\"," +
                    " \"ma_ol_cost\"," +
                    " \"ma_add_skill\"," +
                    " \"skill1_name\"," +
                    " \"skill1_max_atk\"," +
                    " \"skill1_max_hits\"," +
                    " \"skill1_cd\"," +
                    " \"skill1_add_skill\"," +
                    " \"skill2_name\"," +
                    " \"skill2_max_atk\"," +
                    " \"skill2_max_hits\"," +
                    " \"skill2_cd\"," +
                    " \"skill2_add_skill\"," +
                    " \"normal_name\"," +
                    " \"normal_atk\") " +
                    "VALUES (" +
                    $"\"{unitData.name}\", " +
                    $"\"{unitData.secondname}\", " +
                    $"\"{unitData.grade}\", " +
                    $"\"{unitData.element}\", " +
                    $"\"{unitData.weapontype}\", " +
                    $"\"{unitData.maxhp}\", " +
                    $"\"{unitData.maxatk}\", " +
                    $"\"{unitData.maxdef}\", " +
                    $"\"{unitData.max_awake_passive}\", " +
                    $"\"{unitData.ma_name}\", " +
                    $"\"{unitData.ma_max_atk}\", " +
                    $"\"{unitData.ma_max_hits}\", " +
                    $"\"{unitData.ma_ol_cost}\", " +
                    $"\"{unitData.ma_add_skill}\", " +
                    $"\"{unitData.skill1_name}\", " +
                    $"\"{unitData.skill1_max_atk}\", " +
                    $"\"{unitData.skill1_max_hits}\", " +
                    $"\"{unitData.skill1_cd}\", " +
                    $"\"{unitData.skill1_add_skill}\", " +
                    $"\"{unitData.skill2_name}\", " +
                    $"\"{unitData.skill2_max_atk}\", " +
                    $"\"{unitData.skill2_max_hits}\", " +
                    $"\"{unitData.skill2_cd}\", " +
                    $"\"{unitData.skill2_add_skill}\", " +
                    $"\"Normal Attack\", " +
                    $"\"100\")";
                    SQLiteCommand fmd = db2.OpenConnect(queryString);
                    effectedRowes += fmd.ExecuteNonQuery();
                    db2.CloseConnection();
                }
                db1.CloseConnection();
            }
            Console.WriteLine("Done! EffectedRowes: " + effectedRowes);
        }
    }
}

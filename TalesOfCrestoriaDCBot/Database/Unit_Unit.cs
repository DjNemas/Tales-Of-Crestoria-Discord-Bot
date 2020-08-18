using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TaleOfCrestoria.Database
{
    public class Unit_Unit
    {
        DatabaseAccess db = new DatabaseAccess();
        List<Unit_Unit> data = new List<Unit_Unit>();
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
            SQLiteCommand fmd = this.db.OpenConnect(queryString);
            SQLiteDataReader r = fmd.ExecuteReader();
            Tools tool = new Tools();
            int i = 0;            
            while (r.Read())
            {
                this.data.Add(new Unit_Unit());
                this.data[i].id = tool.IsNullRetun(r["id"]);
                this.data[i].name = Convert.ToString(r["name"]);
                this.data[i].secondname = Convert.ToString(r["secondname"]);
                this.data[i].grade = Convert.ToString(r["grade"]);
                this.data[i].element = Convert.ToString(r["element"]);
                this.data[i].weapontype = Convert.ToString(r["weapontype"]);
                this.data[i].maxlvl = tool.IsNullRetun(r["maxlvl"]);
                this.data[i].maxhp = tool.IsNullRetun(r["maxhp"]);
                this.data[i].maxatk = tool.IsNullRetun(r["maxatk"]);
                this.data[i].maxdef = tool.IsNullRetun(r["maxdef"]);
                this.data[i].max_awake_name = Convert.ToString(r["max_awake_name"]);
                this.data[i].max_awake_passive = Convert.ToString(r["max_awake_passive"]);
                this.data[i].ma_name = Convert.ToString(r["ma_name"]);
                this.data[i].ma_max_atk = tool.IsNullRetun(r["ma_max_atk"]);
                this.data[i].ma_max_hits = tool.IsNullRetun(r["ma_max_hits"]);
                this.data[i].ma_enemy = Convert.ToString(r["ma_enemy"]);
                this.data[i].ma_ol_cost = tool.IsNullRetun(r["ma_ol_cost"]);
                this.data[i].ma_max_lvl = tool.IsNullRetun(r["ma_max_lvl"]);
                this.data[i].ma_add_skill = Convert.ToString(r["ma_add_skill"]);
                this.data[i].skill1_name = Convert.ToString(r["skill1_name"]);
                this.data[i].skill1_max_atk = tool.IsNullRetun(r["skill1_max_atk"]);
                this.data[i].skill1_max_hits = tool.IsNullRetun(r["skill1_max_hits"]);
                this.data[i].skill1_enemy = Convert.ToString(r["skill1_enemy"]);
                this.data[i].skill1_cd = tool.IsNullRetun(r["skill1_cd"]);
                this.data[i].skill1_max_lvl = tool.IsNullRetun(r["skill1_max_lvl"]);
                this.data[i].skill1_add_skill = Convert.ToString(r["skill1_add_skill"]);
                this.data[i].skill2_name = Convert.ToString(r["skill2_name"]);
                this.data[i].skill2_max_atk = tool.IsNullRetun(r["skill2_max_atk"]);
                this.data[i].skill2_max_hits = tool.IsNullRetun(r["skill2_max_hits"]);
                this.data[i].skill2_enemy = Convert.ToString(r["skill2_enemy"]);
                this.data[i].skill2_cd = tool.IsNullRetun(r["skill2_cd"]);
                this.data[i].skill2_max_lvl = tool.IsNullRetun(r["skill2_max_lvl"]);
                this.data[i].skill2_add_skill = Convert.ToString(r["skill2_add_skill"]);
                this.data[i].normal_name = Convert.ToString(r["normal_name"]);
                this.data[i].normal_atk = tool.IsNullRetun(r["normal_atk"]);
                this.data[i].normal_hits = tool.IsNullRetun(r["normal_hits"]);
                this.data[i].normal_enemy = Convert.ToString(r["normal_enemy"]);
                this.data[i].normal_add_skill = Convert.ToString(r["normal_add_skill"]);
                this.data[i].image = Convert.ToString(r["image"]);
                i++;
            }
            this.db.CloseConnection();
            
            return this.data;
        }

        public int SendDataDB(string queryString)
        {
            SQLiteCommand fmd = this.db.OpenConnect(queryString);
            int check = fmd.ExecuteNonQuery();
            this.db.CloseConnection();
            return check;
        }


        public int CheckIfAlreadyExist(string queryString)
        {
            SQLiteCommand fmd = this.db.OpenConnect(queryString);
            int check = Convert.ToInt32(fmd.ExecuteScalar());            
            this.db.CloseConnection();
            return check;
        }
    }
}

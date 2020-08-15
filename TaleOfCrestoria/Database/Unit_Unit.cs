using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <Erinnerung>
/// Don't forget to fix the byte convert!
/// </Erinnerung>
namespace TaleOfCrestoria.Database
{
    // Get the unit_unit Table from database
    [Table(Name = "unit_unit")]
    public class Unit_Unit
    {
        [Column(Name = "id")]
        public int id { get; set; }

        [Column(Name = "name")]
        public string name { get; set; }

        [Column(Name = "secondname")]
        public string secondname { get; set; }

        [Column(Name = "grade")]
        public string grade { get; set; }

        [Column(Name = "element")]
        public string element { get; set; }

        [Column(Name = "weapontype")]
        public string weapontype { get; set; }

        [Column(Name = "maxlvl")]
        public int maxlvl { get; set; }

        [Column(Name = "maxhp")]
        public int maxhp { get; set; }

        [Column(Name = "maxatk")]
        public int maxatk { get; set; }

        [Column(Name = "maxdef")]
        public int maxdef { get; set; }

        [Column(Name = "max_awake_name")]
        public string max_awake_name { get; set; }

        [Column(Name = "max_awake_passive")]
        public string max_awake_passive { get; set; }

        [Column(Name = "ma_name")]
        public string ma_name { get; set; }

        [Column(Name = "ma_max_atk")]
        public int ma_max_atk { get; set; }

        [Column(Name = "ma_max_hits")]
        public int ma_max_hits { get; set; }

        [Column(Name = "ma_enemy")]
        public string ma_enemy { get; set; }

        [Column(Name = "ma_max_lvl")]
        public int ma_max_lvl { get; set; }

        [Column(Name = "ma_add_skill")]
        public string ma_add_skill { get; set; }

        [Column(Name = "skill1_name")]
        public string skill1_name { get; set; }

        [Column(Name = "skill1_max_atk")]
        public int skill1_max_atk { get; set; }

        [Column(Name = "skill1_max_hits")]
        public int skill1_max_hits { get; set; }

        [Column(Name = "skill1_enemy")]
        public string skill1_enemy { get; set; }

        [Column(Name = "skill1_max_lvl")]
        public int skill1_max_lvl { get; set; }

        [Column(Name = "skill1_add_skill")]
        public string skill1_add_skill { get; set; }

        [Column(Name = "skill2_name")]
        public string skill2_name { get; set; }

        [Column(Name = "skill2_max_atk")]
        public int skill2_max_atk { get; set; }

        [Column(Name = "skill2_max_hits")]
        public int skill2_max_hits { get; set; }

        [Column(Name = "skill2_enemy")]
        public string skill2_enemy { get; set; }

        [Column(Name = "skill2_max_lvl")]
        public int skill2_max_lvl { get; set; }

        [Column(Name = "skill2_add_skill")]
        public string skill2_add_skill { get; set; }

        [Column(Name = "normal_name")]
        public string normal_name { get; set; }

        [Column(Name = "normal_atk")]
        public int normal_atk { get; set; }

        [Column(Name = "normal_hits")]
        public int normal_hits { get; set; }

        [Column(Name = "normal_enemy")]
        public string normal_enemy { get; set; }

        [Column(Name = "normal_add_skill")]
        public string normal_add_skill { get; set; }

        //[Column(Name = "image")]
        //public byte image { get; set; }
    }
}

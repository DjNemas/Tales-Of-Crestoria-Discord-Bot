using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfCrestoria
{
    class Tools
    {
        public string StringUppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = char.ToLower(a[i]);
            }
            a[0] = char.ToUpper(a[0]);            
            return new string(a);
        }

        public string StringToLower(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = char.ToLower(a[i]);
            }
            return new string(a);
        }

        public dynamic TrimmVariablesForUnitsQuery(dynamic data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string tmp;
                tmp = data[i].name;
                data[i].name = tmp.Replace("'", "");
                tmp = data[i].title;
                data[i].title = tmp.Replace("'", "");
                tmp = data[i].rarity;
                data[i].rarity = tmp.Replace("'", "");
                tmp = data[i].element;
                data[i].element = tmp.Replace("'", "");
                tmp = data[i].type;
                data[i].type = tmp.Replace("'", "");
                tmp = data[i].hp;
                data[i].hp = tmp.Replace("'", "");
                tmp = data[i].attack;
                data[i].attack = tmp.Replace("'", "");
                tmp = data[i].defense;
                data[i].defense = tmp.Replace("'", "");
                tmp = data[i].ma_name;
                data[i].ma_name = tmp.Replace("'", "");
                tmp = data[i].ma_dmg;
                data[i].ma_dmg = tmp.Replace("'", "");
                tmp = data[i].ma_hit;
                data[i].ma_hit = tmp.Replace("'", "");
                tmp = data[i].ma_ol;
                data[i].ma_ol = tmp.Replace("'", "");
                tmp = data[i].ma_ef;
                data[i].ma_ef = tmp.Replace("'", "");
                tmp = data[i].a1_name;
                data[i].a1_name = tmp.Replace("'", "");
                tmp = data[i].a1_dmg;
                data[i].a1_dmg = tmp.Replace("'", "");
                tmp = data[i].a1_hit;
                data[i].a1_hit = tmp.Replace("'", "");
                tmp = data[i].a1_cd;
                data[i].a1_cd = tmp.Replace("'", "");
                tmp = data[i].a1_ef;
                data[i].a1_ef = tmp.Replace("'", "");
                tmp = data[i].a2_name;
                data[i].a2_name = tmp.Replace("'", "");
                tmp = data[i].a2_dmg;
                data[i].a2_dmg = tmp.Replace("'", "");
                tmp = data[i].a2_hit;
                data[i].a2_hit = tmp.Replace("'", "");
                tmp = data[i].a2_cd;
                data[i].a2_cd = tmp.Replace("'", "");
                tmp = data[i].a2_ef;
                data[i].a2_ef = tmp.Replace("'", "");
            }
            return data;
        }
    }
}

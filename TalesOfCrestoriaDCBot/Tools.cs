using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public int? IsNullRetun(object check)
        {
            
            if (Convert.IsDBNull(check) == true)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(check);
            }
        }
    }
}

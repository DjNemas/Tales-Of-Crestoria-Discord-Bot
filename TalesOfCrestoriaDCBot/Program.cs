using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfCrestoria
{
    class Program
    {
        static void Main(string[] args)
        {
            new InitBot().RunBotAsync().GetAwaiter().GetResult();
        }        
    }
}

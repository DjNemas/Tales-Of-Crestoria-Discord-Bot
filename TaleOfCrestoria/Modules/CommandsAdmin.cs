using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleOfCrestoria.Modules
{   
    /// <summary>
    /// Only For Admins here ;D
    /// </summary>
    //[RequireUserPermission(GuildPermission.BanMembers)]
    [RequireUserPermission(GuildPermission.BanMembers, Group = "Admin")]
    [RequireOwner(Group = "Admin")]
    public class CommandsAdmin : ModuleBase<SocketCommandContext>
    {

        //Member
        InitBot init = new InitBot();

        [Command("shutdown")]
        public async Task Shutdown()
        {
            await ReplyAsync($"```Bot will be Shutdown now! Bye o/```");
            Environment.Exit(0);
        }

        [Command("prefix")]
        public async Task SetPrefix(char prefix)
        {
            await ReplyAsync($"```Prefix was changed to {prefix}. Bot is restarting now. This may take a while!```");
            init.config.Elements().Elements().ElementAt(0).Value = prefix.ToString();
            init.config.Save(init.GetInitConfigPath());
            string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            System.Diagnostics.Process.Start(myApp);
            Environment.Exit(0);

        }
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Rest;

namespace TaleOfCrestoria.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //Member
        InitBot init = new InitBot();

        [Command("help")]
        public async Task Help()
        {
            await ReplyAsync(
                $"> use {init.Prefix}commands for Commandlist\n\n\n" +
                "__Quick Command Guide__\n" +
                $"Every command starts with this Prefix {init.Prefix} followed by command\n" + 
                $"> Example: {init.Prefix}help\n" +
                "Some commands can get special parameters\n" + 
                $"> For Example {init.Prefix}unit <parameter1> <parameter2>\n" +
                "When a command has a <parameter>, you only write the parameter without the <> \n" +
                $"> Example for {init.Prefix}unit <unit id> unit you write {init.Prefix}unit 1 unit\n\n" +
                "I hope this QuickGuide helps u :blush: \n\n" +
                "Feel free to contact me on Discord DjNemas#0185, when u find bugs or have some suggetions :heart: OwO ");
            
        }

        [Command("commands")]
        public async Task CommandsList()
        {
            await ReplyAsync($"__MAIN COMMANDS__\n" +
                $"> {init.Prefix}help | See a quick Help\n\n" +
                $"__UNIT COMMANDS__\n" +
                    $"> {init.Prefix}unit | Main Command for Units Database\n" +
                    $"> {init.Prefix}unit <Unitname> | Shows a list of available units with the **unitname** u chosen and shows the **IDs**\n" +
                    $"> {init.Prefix}unit <unit id> unit | Shows the **unit** stats of your selected unit by **ID**\n" +
                    $"> {init.Prefix}unit <unit id> stone | Shows the **unitstone** stats of your selected unit by **ID**\n\n" +
                $"__ADMIN COMMANDS__\n" +
                    "This commands only can be used by **Admins**\n" +
                    $"> {init.Prefix}shutdown | Shutdown the Bot\n" +
                    $"> {init.Prefix}prefix <new prefix> | Change the **prefix** for Commands and **restart the bot**. Only one character like % or & allowed!\n" +
                    $"> {init.Prefix}update unit | Update the Database with the API www.tocdb.xyz/api.php" );
        }

        //sample square 20 -> 400
        [Command("square")]
        [Summary("Squares a number.")]
        public async Task SquareAsync(
            [Summary("The number to square.")]
        int num)
        {
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
        }
    }
}

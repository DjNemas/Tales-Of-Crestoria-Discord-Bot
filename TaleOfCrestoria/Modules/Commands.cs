using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Discord.Commands;
using Discord.Rest;

namespace TaleOfCrestoria.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //Member
        public char Prefix { get; private set; }
        private const string InitConfigPath = @"../../initconfig.xml";

        // Load ConfigFile
        private XDocument config = XDocument.Load(InitConfigPath);
        

        public Commands()
        {
            // Get prefix from config file
            var prefix = from pre in config.Descendants("Config")
                         select pre.Element("Prefix").Value;
            this.Prefix = Convert.ToChar(prefix.ElementAt(0));
        }

        [Command("help")]
        public async Task Help()
        {
            await ReplyAsync($"``` use {this.Prefix}commands for Commandlist ```");
            
        }

        [Command("commands")]
        public async Task CommandsList()
        {
            await ReplyAsync($"```{this.Prefix}help\n{this.Prefix}velvet```");
        }

        [Command("velvet")]
        public async Task Velvet()
        {
            await ReplyAsync("Informations about Velvet will be added soon!");
        }

        [Command("prefix")]
        public async Task SetPrefix(char prefix)
        {
            await ReplyAsync($"```Prefix was changed to {prefix}. Bot is restarting now. This may take a while!```");
            config.Elements().Elements().ElementAt(0).Value = prefix.ToString();
            config.Save(InitConfigPath);            
            string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            System.Diagnostics.Process.Start(myApp);
            Environment.Exit(0);

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

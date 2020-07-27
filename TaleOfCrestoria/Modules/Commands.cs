using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace TaleOfCrestoria.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //Member
        public char Prefix { get; private set; }

        public Commands()
        {
            this.Prefix = '&';
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
            this.Prefix = prefix;

            await ReplyAsync($"Prefix was changed to {prefix}");
            new InitBot().RunBotAsync().GetAwaiter().GetResult();
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

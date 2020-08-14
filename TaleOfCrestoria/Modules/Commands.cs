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

        public Commands()
        {
            //
        }

        [Command("help")]
        public async Task Help()
        {
            await ReplyAsync($"``` use {init.Prefix}commands for Commandlist ```");
            
        }

        [Command("commands")]
        public async Task CommandsList()
        {
            await ReplyAsync($"```{init.Prefix}help\n\n" +
                $"Unit Commands\n" +
                    $"{init.Prefix}velvet\n" +
                    $"{init.Prefix}yuri\n\n" +
                $"ADMIN COMMANDS\n" +
                    $"{init.Prefix}shutdown\n" +
                    $"{init.Prefix}prefix <new prefix>```");
        }

        [Command("velvet")]
        public async Task Velvet()
        {
            await ReplyAsync("Informations about Velvet will be added soon!");
        }

        [Command("yuri")]
        public async Task Yuri()
        {
            await ReplyAsync("Informations about Yuri will be added soon!");
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

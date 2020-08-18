using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaleOfCrestoria.Modules;

namespace TaleOfCrestoria
{
    class InitBot
    {
        /// Member
        ///        
        private DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;
        // Config Path
        private const string InitConfigPath = @"config/initconfig.xml";
        // Load ConfigFile
        public XDocument config = XDocument.Load(InitConfigPath);
        public char Prefix { get; private set; }
        public string Token { get; private set; }
        

        // Constructor
        public InitBot()
        {
            // Get prefix from config file
            var prefix = from pre in config.Descendants("Config")
                         select pre.Element("Prefix").Value;
            this.Prefix = Convert.ToChar(prefix.ElementAt(0));

            // Get Token from config file
            var token = from tok in config.Descendants("Config")
                         select tok.Element("Token").Value;
            this.Token = Convert.ToString(token.ElementAt(0));
        }

        // getter
        public string GetInitConfigPath()
        {
            return InitConfigPath;
        }

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient();
            
            commands = new CommandService();

            services = new ServiceCollection().AddSingleton(client).AddSingleton(commands).BuildServiceProvider();

            client.Log += Client_Log;

            await RegisterCommandsAsync();

            await client.LoginAsync(TokenType.Bot, this.Token);

            await client.StartAsync();

            await Task.Delay(-1);

        }

        private Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix(this.Prefix.ToString(), ref argPos))
            {
                
                var result = await commands.ExecuteAsync(context, argPos, services);
                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}

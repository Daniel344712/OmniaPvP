﻿using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using OmniaPvP.commands;
using OmniaPvP.config;
using System.Threading.Tasks;

namespace OmniaPvP
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        static async Task Main(string[] args)

        {
           var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };
            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                CaseSensitive = false,
                EnableDefaultHelp = false,
            };
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<Commands>();
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

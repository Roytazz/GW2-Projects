using Discord;
using Newtonsoft.Json;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using Discord.Commands;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using GuildWars2.Discord.Services;

namespace GuildWars2.Discord
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Debug });

            _services = new ServiceCollection()
                .AddSingleton<ApiService>()
                .BuildServiceProvider();

            _commands = new CommandService();
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.Log += Log;
            _client.MessageReceived += HandleCommand;

            await _client.LoginAsync(TokenType.Bot, Properties.Resources.Token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task HandleCommand(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            int argPos = 0;
            if (message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos)) {
                var context = new CommandContext(_client, message);

                if (message.Content.ToLower().Equals("!exit"))
                    await Exit(context);

                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    await context.Channel.SendMessageAsync(result.ErrorReason);
            }
        }

        private async Task Log(LogMessage msg) {
            Console.WriteLine(msg.ToString());
            await Task.CompletedTask;
        }

        private async Task Exit(CommandContext cmd) {
            await cmd.Channel.SendMessageAsync("Bye");
            Environment.Exit(1);
        }
    }

}
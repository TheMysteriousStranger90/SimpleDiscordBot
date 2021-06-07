using System;
using Discord;
using Discord.Net;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace SimpleDiscordBot
{
    public class Bot
    {
        private readonly DiscordSocketClient client;
        private readonly IConfiguration config;

        public Bot()
        {
            client = new DiscordSocketClient();
            client.Log += LogAsync;
            client.Ready += ReadyAsync;
            client.MessageReceived += MessageReceivedAsync;
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(path: "config.json");            
            config = builder.Build();
        }
        
        public async Task MainAsync()
        {
            await client.LoginAsync(TokenType.Bot, config["Token"]);
            await client.StartAsync();
            await Task.Delay(-1);
        }
        
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
        
        private Task ReadyAsync()
        {
            Console.WriteLine($"Connected as -> [] :)");
            return Task.CompletedTask;
        }
        
        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (!message.Author.IsBot)
            {
                var username = message.Author;
                var msg = message.Content;
                
                var answear = msg switch
                {
                    "!hi" => "Hello friend!",
                    "!time" => DateTime.Now.ToString(),
                    _ => $"Received a message {msg} from {username}"
                };
                
                await message.Channel.SendMessageAsync(answear);
            }
        }
    }
}
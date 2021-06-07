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
    class Program
    {
        static void Main(string[] args)
        {
            new Bot().MainAsync().GetAwaiter().GetResult();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
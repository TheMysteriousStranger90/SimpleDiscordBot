using System;

//ADD YOUR config.json FILE TOGETHER WITH YOUR TOKEN TO SimpleDiscordBot\SimpleDiscordBot\bin\Debug\net5.0 

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
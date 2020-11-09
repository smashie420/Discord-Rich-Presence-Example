using DiscordRPC;
using DiscordRPC.Logging;
using System;

namespace Discord_Rich_Presence_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DiscordRpcClient client = new DiscordRpcClient("clientID");
			// You get a client id by creating an app from https://discord.com/developers/applications/

			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			client.SetPresence(new RichPresence()
			{
				Details = "made by smashguns#6175",
				State = "csharp example",
				Assets = new Assets()
				{
					LargeImageKey = "image_large",
					LargeImageText = "Lachee's Discord IPC Library",
					SmallImageKey = "image_small"
				}
			});
			Console.ReadKey();

		}
		
	}
}

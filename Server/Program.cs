using System;
using System.Threading.Tasks;
using Client;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new MyTcpServer();
            Console.CancelKeyPress += (sender, e) =>
            {
                server.Stop();
                Environment.Exit(0);
            };

            await server.Start(5000); 
        }
    }
}

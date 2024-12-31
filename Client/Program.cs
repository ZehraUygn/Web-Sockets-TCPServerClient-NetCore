using System;
using System.Threading.Tasks;
using Client;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MyTcpClient();

            try
            {
                await client.Connect("127.0.0.1", 5000); 

                while (true)
                {
                    Console.Write("Enter a message (type 'exit' to quit): ");
                    string message = Console.ReadLine();
                    if (message == "exit") break;

                    await client.SendMessage(message);
                }

                client.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

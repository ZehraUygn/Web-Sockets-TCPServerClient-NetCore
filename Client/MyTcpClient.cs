using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class MyTcpClient
    {

            private TcpClient _client;

            public async Task Connect(string ipAddress, int port)
            {
                _client = new TcpClient();
                await _client.ConnectAsync(ipAddress, port);
                Console.WriteLine("Connected to the server.");
            }

           public async Task SendMessage(string message)
            {
                var stream = _client.GetStream();
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(messageBytes, 0, messageBytes.Length);

                var buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Server Response: {response}");
            }

            public void Disconnect()
            {
                _client.Close();
                Console.WriteLine("Disconnected from the server.");
            }
        }
    }

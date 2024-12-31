using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class MyTcpServer
    {


        private TcpListener _server;


        public async Task Start(int port)
            {
                _server = new TcpListener(IPAddress.Any, port);
                _server.Start();
                Console.WriteLine($"Server started on port {port}.");

                while (true)
                {
                    var client = await _server.AcceptTcpClientAsync();
                    Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");

                    _ = HandleClientAsync(client);
                }
            }

        private async Task HandleClientAsync(TcpClient client)
            {
                var stream = client.GetStream();
                var buffer = new byte[1024];

                try
                {
                    while (true)
                    {
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead == 0) break; 

                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received: {receivedMessage}");

                        string response = $"Server: {receivedMessage.ToUpper()}";
                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    client.Close();
                    Console.WriteLine("Client disconnected.");
                }
            }

            public void Stop()
            {
                _server?.Stop();
                Console.WriteLine("Server stopped.");
            }
        }
    }

--- Code explanation

-- Server

- Start Method: It initializes the TCP server by creating a TcpListener to listen for client connections on the specified port. 
The server starts listening for client connections using _server.Start(). 
For each connected client, it calls HandleClientAsync to process the client's messages.

- HandleClientAsync Method: It handles communication with an individual client.
It retrieves the NetworkStream for reading/writing data from/to the client.
It continuously reads messages from the client using ReadAsync.
Converts the received bytes into a string, logs the message, and sends a response.
If the client disconnects (when bytesRead is 0), it exits the loop and closes the connection.

- Stop Method: It stops the server and releases the resources.
It calls _server.Stop() to halt the listener and logs a message indicating the server has stopped.

-- Client

- Connect Method: It establishes a connection to the server by creating a TcpClient instance 
and calling ConnectAsync with the server's IP address and port.
It logs a message if the connection is successful.


- SendMessage Method: It sends a message to the server and receives a response.
It converts the input string message to a byte array using Encoding.UTF8.GetBytes.
Writes the byte array to the server using the NetworkStream.
Reads the server's response, converts it to a string, and displays it in the console.

- Disconnect Method: It closes the client's connection.
It calls _client.Close() to release the network resources and 
logs a message indicating the client has disconnected.


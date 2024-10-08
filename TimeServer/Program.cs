﻿using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

Console.WriteLine("Starting up server...");
var listener = new TcpListener(IPAddress.Any, 63452);
listener.Start();
Console.WriteLine("Listening for incoming connections on " + listener.LocalEndpoint + "...");
while (true)
{
    
// accept a new incoming connection. Wait for it.
    var client = listener.AcceptTcpClient(); // blocking
    Console.WriteLine("Client accepted: " + client.Client.RemoteEndPoint);
// the text we want to send:
    var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
// encode the text using ASCII:
// The Server commands the protocol:
// I send one ASCII-Encoded String and then close the connection.
    byte[] bytes = Encoding.ASCII.GetBytes(currentTime);
// send the bytes over the client stream:
    client.GetStream().Write(bytes);
// after sending the message, properly close the connection
    client.Close();
}
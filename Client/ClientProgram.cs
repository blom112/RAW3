﻿using System;
using System.Net.Sockets;
using System.Text;
using Utillities;
using System.Text.Json;

namespace Client
{
    
    class ClientProgram
    {
        static void Main(string[] args)
        {

            Request request = new Request();
            request.Method = "This is the method";
            request.Date = request.ConvertCurrentDate();
            request.Body = "This is the body";
            request.Path = "This is the path";


            string output = JsonSerializer.Serialize(request);

            var client = new NetworkClient();

            client.Connect("localhost", 5000);

            var message = output;


            client.Write(message);

            var response = client.Read();

            Console.WriteLine($"Server response '{response}'");
        }
    }
}

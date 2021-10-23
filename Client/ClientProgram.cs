using System;
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
            request.Method = "";
            request.Date = "";
            request.Body = "IM THE BODY";
            request.Path = "IM THE PATH";


            
         string serialized =  JsonSerializer.Serialize<Request>(request, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var client = new NetworkClient();

            client.Connect("localhost", 5000);



            client.Write(serialized);
            
            var response = client.Read();

            Console.WriteLine($"Server response '{response}'");
        }
    }
}

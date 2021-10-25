using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Utillities;
using System.Text.Json;

namespace Server
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            ResponseBuilder responseBuilder = new ResponseBuilder();
            var server = new TcpListener(IPAddress.Loopback, 5000);
            server.Start();
            Console.WriteLine("Server started");
            Console.WriteLine(DateTimeOffset.Now.ToString());


            while (true)
            {
                var client = new NetworkClient(server.AcceptTcpClient());
                Console.WriteLine("Client accepted");
                Console.WriteLine(DateTimeOffset.Now.ToString());


                var message = client.Read();

                var messagesent = responseBuilder.CreateResponse(message);
                
              

                //Console.WriteLine(responseBuilder.Status);
                
                //Console.WriteLine($"Client message '{message}'");

                client.Write(messagesent);

               
           
            }
        }
      
    }
}

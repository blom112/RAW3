using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Utillities;

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
            
            while (true)
            {
                var client = new NetworkClient(server.AcceptTcpClient());
                Console.WriteLine("Client accepted");

                var message = client.Read();


                responseBuilder.CreateResponse(message);

                Console.WriteLine($"Client message '{message}'");

                client.Write(message.ToUpper());

               
           
            }
        }
      
    }
}

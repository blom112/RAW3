using System;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Utillities;

namespace Server
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            DualTranslator dualTranslator= new DualTranslator();
            Validator validator = new Validator();
       
            
            var server = new TcpListener(IPAddress.Loopback, 5000);
            server.Start();
            Console.WriteLine("Server started");
            
            while (true)
            {
                var client = new NetworkClient(server.AcceptTcpClient());
                Console.WriteLine("Client accepted");

                var message = client.Read();
                Console.WriteLine($"Client message '{message}'");
               
                var translatedAndValidatedResponse = dualTranslator.StringToJson(validator.CheckIfTranslatedMessageIsAcceptable(message));

               
                
              

              
                
              
                Console.WriteLine($"Server message '{translatedAndValidatedResponse}'");

                client.Write(translatedAndValidatedResponse);
               


            }
            
        }
      
    }
}

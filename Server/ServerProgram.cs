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
                var translatedClientMessage = dualTranslator.JsonToString(message);
                var checkedMessageInString = validator.CheckIfTranslatedMessageIsAcceptable(translatedClientMessage);
                var translatedandCheckedResponse = dualTranslator.StringToJson(checkedMessageInString);

               
                
              

              
                
                Console.WriteLine($"Client message '{message}'");
                Console.WriteLine($"Server message '{translatedandCheckedResponse}'");

                client.Write(translatedandCheckedResponse);
               


            }
            
        }
      
    }
}

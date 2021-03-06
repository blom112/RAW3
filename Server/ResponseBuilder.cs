using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Server
{
    class ResponseBuilder
    {

        public string Status { get; set; } = "";
        


        public string Method { get; set; } = "";

        public string Path { get; set; } = "";

        public string Date { get; set; } = "";

        public string Body { get; set; } = "";



        public string CreateResponse(string m)
        {
            ArrayList responseList = new ArrayList();

            /*int ok = 1;
            int created = 2;
            int updated = 3;
            int badRequest = 4;
            int notFound = 5;
            int error = 6;

           */

            var jsonString = "";

           

            ResponseBuilder responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(m, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            string[] methods = new string[6] { "create", "read", "write", "update", "delete", "echo" };

            // 02
            foreach (string value in methods)
            {
                if (String.IsNullOrEmpty(responseBuilder.Method))
                {
                    if (!responseList.Contains("missing method")) {
                        responseList.Add("missing method ");
                     
                    }
                }
            }


            // 03
            foreach (string value in methods)
            {
                if (!(value.Equals(responseBuilder.Method)))
                {
                    if (!responseList.Contains("illegal method"))
                    {
                        responseList.Add("illegal method ");
                    }
                }
            }
        

            // 04, 05, 06 , 07 Wrong
            foreach (string value in methods)
            {
                if (!(value.Equals(responseBuilder.Method) && (String.IsNullOrEmpty(responseBuilder.Path))))
                {
                    if (!responseList.Contains("missing resource"))
                    {
                    responseList.Add("missing resource ");

                }
}
            }

            //8 
            foreach (string value in methods) {

                if (!value.Equals(responseBuilder.Date))  {

                    if (!responseList.Contains("missing date "))
                    {
                        responseList.Add("missing date ");
                    }
                }
                    }


        //9 


            if (responseBuilder.Date.Contains("/") )
                {

                    if (!responseList.Contains("illegal date "))
                    {
                        responseList.Add("illegal date ");

                    }
                }
           
            
                // 10, 11, 12
            if (String.IsNullOrEmpty(responseBuilder.Body)) 
            {
                if (!responseList.Contains("missing body"))
                {
                    responseList.Add("missing body ");

                }
            }


            // 13, 14 Is auto when 13 is not relevant
            if (responseBuilder.Equals("") && !responseBuilder.Method.Equals("echo") && !responseBuilder.Body.Contains("{"))
            {


                if (!responseList.Contains("illegal body"))
                {
                    responseList.Add("illegal body ");
                }
            }


            // 15 --- Something wrong with this
            if (responseList.Count == 0) 
            {
                if (responseBuilder.Path.Equals("/api/categories"))
                {

                    responseBuilder.Status = "4 Bad Request";
                    jsonString = JsonSerializer.Serialize<ResponseBuilder>(responseBuilder, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    return jsonString;
                }
            }
           

            Console.WriteLine(responseList[1]);
            
                foreach (string value in responseList)
                {

                    responseBuilder.Status += value;
                }
           
            //  Console.WriteLine(responseBuilder.Status + " this is the final output");

            jsonString = JsonSerializer.Serialize<ResponseBuilder>(responseBuilder, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

           // responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(message, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            Console.WriteLine(responseBuilder.Status);
            return jsonString;
        }
    }
}

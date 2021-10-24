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

        private string status;
        public string Status {
            get { return status; }
            set { status = value; }
        }


        private string method;
        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string date;

        public string Date
        {
            get { return date; }

            set { date = value; }
        }


        private string body;
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

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

            ResponseBuilder responseBuilder = new ResponseBuilder();

            responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(m, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

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
                        responseList.Add("illegal method ");
                }
            }
        

            // 04, 05, 06 , 07 Wrong
            foreach (string value in methods)
            {
                if (!(value.Equals(responseBuilder.Path)))
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


                foreach (string value in methods)
            {

                if (!value.Equals(responseBuilder.Date))
                {

                    if (!responseList.Contains("missing date "))
                    {
                        responseList.Add("illegal date ");

                    }
                }
            }


            Console.WriteLine(responseList[1]);
           foreach (string value in responseList)
            {
               responseBuilder.Status += value;
               
            }
          //  Console.WriteLine(responseBuilder.Status + " this is the final output");


          var message = JsonSerializer.Serialize<ResponseBuilder>(responseBuilder, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

           // responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(message, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            Console.WriteLine(responseBuilder.Status);
            return message;
        }



    }
}

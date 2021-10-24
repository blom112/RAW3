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
/*

        private string status;
        public string Status {
            get {return status; }
            set {status = value; }
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
            ArrayList responseList= new ArrayList();

            /*int ok = 1;
            int created = 2;
            int updated = 3;
            int badRequest = 4;
            int notFound = 5;
            int error = 6;

           

            ResponseBuilder responseBuilder;

            responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(m, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            string[] methods = new string[6] { "create", "read", "write", "update", "delete", "echo" };
            // 02


            foreach (string value in methods)
            {
                if (String.IsNullOrEmpty(responseBuilder.Method))
                {
                    if ((!responseList.Contains("missing method")))
                    {
                        responseList.Add("missing method ");
                    }

                }
               

                if (!(value.Equals(responseBuilder.Method)))
                {
                    if ((!responseList.Contains("illegal method ")))
                    {

                        responseList.Add("illegal method ");
                    }               
                }

                if (!String.IsNullOrEmpty(responseBuilder.Path)) 
                {
                    responseList.Add("missing resource ");
                }

            }
         

           
            
            // 04, 05, 06 , 07 Wrong
            foreach (string value in methods)
            {
                if (!value.Equals(responseBuilder.Path))
                {
                    responseList.Add("missing resource ");

                }
            }
            
         
     
            
           foreach (string value in responseList)
            {
               responseBuilder.Status += value;
                
            }

         
      

         string sending = JsonSerializer.Serialize<ResponseBuilder>(responseBuilder, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
           
            return sending;
        }

*/

    }
}

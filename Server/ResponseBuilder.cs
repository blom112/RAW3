using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Server
{
    class ResponseBuilder
    {
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

        private long date;

        public long Date
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

        public void CreateResponse(string m)
        {

            ResponseBuilder responseBuilder = new ResponseBuilder();
                
            responseBuilder = JsonSerializer.Deserialize <ResponseBuilder>(m);

            Console.WriteLine(responseBuilder.Method);

            /*if(responseBuilder.Method == "")
            string response = "";
            if (clientMessage.)
            {
                response += "is missing";
            }
            

            return response;*/
        }



    }
}

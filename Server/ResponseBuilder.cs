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

        public string CreateResponse(string m)
        {
            Stack responseStack = new Stack();
            int ok = 1;
            int created = 2;
            int updated = 3;
            int badRequest = 4;
            int notFound = 5;
            int error = 6;


            ResponseBuilder responseBuilder = new ResponseBuilder();

            responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(m);

            // 02
            if (responseBuilder.Method.Equals(null))
            {
                responseStack.Push("missing method");
            }

            // 03
            string[] methods = new string[6] { "create", "read", "write", "update", "delete", "echo" };

            foreach (string value in methods)
            {
                if (!(value.Equals(responseBuilder.Method)))
                {
                    responseStack.Push("illigal method");

                }
            }
            // 04, 05, 06 , 07


            if (responseBuilder.Path.Equals(null))
            {
                responseStack.Push("missing resource");


            }
            return responseStack.ToString();
        }



    }
}

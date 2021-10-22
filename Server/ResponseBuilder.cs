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
            ArrayList responseList= new ArrayList();
           
            /*int ok = 1;
            int created = 2;
            int updated = 3;
            int badRequest = 4;
            int notFound = 5;
            int error = 6;

           */

            ResponseBuilder responseBuilder = new ResponseBuilder();

            responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(m);
           
            string[] methods = new string[6] { "create", "read", "write", "update", "delete", "echo" };
            // 02
            Console.WriteLine("starting foreach test 2");
            foreach (string value in methods)
            {
                if (String.IsNullOrEmpty(responseBuilder.Method))
                {
                    responseList.Add("missing method ");

                    Console.WriteLine("test 2");
                    Console.WriteLine(responseList[0]);
                }
            }
            Console.WriteLine("ending foreach test 2");

            // 03
            foreach (string value in methods)
            {
                if (!(value.Equals(responseBuilder.Method)))
                {
                    responseList.Add("illigal method ");

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

            Console.WriteLine("building output string/starting popstack");
     
            Console.WriteLine(responseList[1]);
           foreach (string value in responseList)
            {
               responseBuilder.Status += value;
                Console.WriteLine(responseBuilder.Status);
            }
            Console.WriteLine(responseBuilder.Status + " this is the final output");


          var message = JsonSerializer.Serialize<ResponseBuilder>(responseBuilder);

            responseBuilder = JsonSerializer.Deserialize<ResponseBuilder>(message);
            Console.WriteLine(responseBuilder.Status);
            return message;
        }



    }
}

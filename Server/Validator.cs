using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    class Validator
    {
        private string status;
        public string Status
        {
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

        public string CheckIfTranslatedMessageIsAcceptable(string ToBeTranslated) 
        {

            Validator validator = JsonSerializer.Deserialize<Validator>(ToBeTranslated, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            
            
            ArrayList responseList = new ArrayList();
           

            string[] methods = new string[6] { "create", "read", "write", "update", "delete", "echo" };
            // 02


            foreach (string value in methods)
            {
                if (String.IsNullOrEmpty(validator.Method))
                {
                    if (!responseList.Contains("missing method"))
                    {
                        responseList.Add("missing method ");
                    }
                    
                }


                if (!(value.Equals(validator.Method)))
                {
                    if (!responseList.Contains("illegal method "))
                    {

                        responseList.Add("illegal method ");
                    }
                    
                }

                if (!String.IsNullOrEmpty(validator.Path))
                {
                    responseList.Add("missing resource");
                }




            }

            foreach (string value in responseList)
            {
                validator.Status += value;

            }

            return validator.Status;
           
        }
    }
}

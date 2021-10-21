using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utillities;
using System.Text.Json;

namespace Client
{
    class Request
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
        public string Body {
            get { return body; }
            set { body = value; }
        }


        public long ConvertCurrentDate() {

            DateTime datetime = DateTime.Now; 
                
               date = ((DateTimeOffset)datetime).ToUnixTimeSeconds();
            return date;
        }
    }
 
}

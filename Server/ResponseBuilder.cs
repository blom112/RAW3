using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ResponseBuilder
    {
        public string CreateResponse(string m)
        {
            string response = "";
            if (String.IsNullOrEmpty(m))
            {
                response += "is missing";
            }

            return response;
        }

    }
}

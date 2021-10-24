using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Server
{
    class DualTranslator
    {
        private string translatedJsonToString;

        public string TranslatedJsonToString
        {
            get { return translatedJsonToString; }
            set { translatedJsonToString = value; }
        }

        private string translatedStringToJson;

        public string TranslatedStringToJson
        {
            get { return translatedStringToJson; }
            set { translatedStringToJson = value; }
        }

/*
        public string JsonToString(string m)
        {

            DualTranslator JsonToStringTranslator = new DualTranslator();
            Validator validator = new Validator();
            




            return TranslatedJsonToString;
        }

        */
        public string StringToJson(string m)
        {
           


           TranslatedStringToJson = JsonSerializer.Serialize(m, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

           
            return TranslatedStringToJson;
        }
    }

       
}

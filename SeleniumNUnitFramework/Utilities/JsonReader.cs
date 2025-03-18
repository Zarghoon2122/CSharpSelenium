using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitFramework.Utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

        public string extractData (String tokenName)
        {
            String myJsonString = File.ReadAllText("C:\\Users\\Zarghoon Shinwari\\source\\repos\\CSharpCourse\\SeleniumNUnitFramework\\Utilities\\testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        //if you want to return multiple strings
        public string[] extractDataArray(String tokenName)
        {
            String myJsonString = File.ReadAllText("C:\\Users\\Zarghoon Shinwari\\source\\repos\\CSharpCourse\\SeleniumNUnitFramework\\Utilities\\testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            List<String> productsList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productsList.ToArray();
        }
    }
}

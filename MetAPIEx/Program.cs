using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MetAPIEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.GetStuff();
        }

        public int GetStuff()
        {
        //http://jsonviewer.stack.hu/
        //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166"); 

            //the usual stuff. run the request, parse your json
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    //JToken data = jObj.SelectToken("path");
                    //int valuepm1 = data.Value<int>("keyname");//key name - getting key.value
                    //int valuepm25 = data.Value<int>("pm25");
                    //int radonValue = data.Value<int>("radonShortTermAvg");
                    // inn i db
                  
                }
                return 0;
            }
            catch { Exception ex; }
            return 0;
        }
        

    }
}

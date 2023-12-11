
using BusLayer;

using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetAPIEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            int readInterval = 0;

            while (true)
            {
                if(DateTime.Now.Minute == 1)
                {
                    p.GetWeatherDataNow();
                    Thread.Sleep(1000*60*50);
                }

                readInterval = Int32.Parse(ConfigurationManager.AppSettings["ReadInterval"]); // henter info fra App.config
                Thread.Sleep(readInterval);
            }
        }

        public void GetWeatherDataNow() 
        {
        //http://jsonviewer.stack.hu/
        //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166"); 

            //the usual stuff. run the request, parse your json. with error handling
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
                    JToken weatherData = jObj.SelectToken("properties.timeseries[0].data.instant.details");
                    JToken timeData = jObj.SelectToken("properties.timeseries[0]");

                    // Getting weather data
                    double temp = weatherData.Value<double>("air_temperature"); // key name står i " " - getting key.value
                    double windSpeed = weatherData.Value<double>("wind_speed");
                    double humidity = weatherData.Value<double>("relative_humidity");

                    // Getting time data
                    DateTime dateTime = DateTime.Parse(timeData.Value<string>("time"));

                    //insert to db - call method from bl
                    Weather weather = new Weather();
                    weather.InsertWeatherValues(temp, windSpeed, humidity, dateTime);
                }
            }
            catch { Exception ex; }
        }
    }
}
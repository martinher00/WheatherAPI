using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLayer
{
    public class Weather
    {
        public Weather() { }

        public int DataId { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double Year { get; set; }
        public double Month { get; set; }
        public double Day { get; set; }
        public double Hour { get; set; }
        public DateTime time_inserterd { get; set; }

        //List<Weather> weather_data;

        public void InsertWeatherValues(double temp, double windSpeed, double humidity, DateTime dateTime)
        {
            DBLayer dBLayer = new DBLayer();
            dBLayer.InsertWeatherValues(temp, windSpeed, humidity, dateTime);
        }

        public List<Weather> GetWeatherValues()
        {
            DBLayer dBLayer = new DBLayer();
            List<Weather> weather_data=new List<Weather>();
            //mapping stuff
            foreach(DataRow dr in dBLayer.GetWeatherValues().AsEnumerable())
            {
                Weather weather = new Weather();
                weather.DataId = (int)dr["data_id"];
                weather.Temperature = (double)dr["temperature"];
                weather.WindSpeed = (double)dr["windspeed"];
                weather.Humidity = (double)dr["humidity"];
                weather.Year = (double)dr["year"];
                weather.Month = (double)dr["month"];
                weather.Day = (double)dr["day"];
                weather.Hour = (double)dr["hour"];
                weather.time_inserterd = (DateTime)dr["time_inserted"];

                weather_data.Add(weather);

            }
            return weather_data;
        }
        
    }
}

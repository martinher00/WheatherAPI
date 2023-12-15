using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
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

        public List<Weather> GetAllWeatherValues()
        {
            DBLayer dBLayer = new DBLayer();
            List<Weather> weather_data=new List<Weather>();
            //mapping stuff
            foreach(DataRow dr in dBLayer.GetAllWeatherValues().AsEnumerable())
            {
                Weather weather = new Weather();
                weather.DataId = (int)dr["data_id"];
                weather.Temperature = (double)dr["temperature"];
                weather.WindSpeed = (double)dr["windspeed"];
                weather.Humidity = (double)dr["humidity"];
                weather.Year = (int)dr["year"];
                weather.Month = (int)dr["month"];
                weather.Day = (int)dr["day"];
                weather.Hour = (int)dr["hour"];
                weather.time_inserterd = (DateTime)dr["time_inserted"];

                weather_data.Add(weather);
            }
            return weather_data;
        }

        public List<Weather> GetWeatherValuesByUserInput(string timespan, int year, int month, int day, int hour)
        {
            List<Weather> weather_data = new List<Weather>();

            switch (timespan)
            {
                case "daily":
                    weather_data = GetWeatherValuesByYearMonthDay(year, month, day);
                    break;
                case "monthly":
                    weather_data = GetWeatherValuesByYearMonth(year, month, hour);
                    break;
            }
            return weather_data;
        }
        public List<Weather> GetWeatherValuesByYearMonthDay(int year, int month, int day)
        {
            DBLayer dBLayer = new DBLayer();
            List<Weather> weather_data = new List<Weather>();
            //mapping stuff
            foreach (DataRow dr in dBLayer.GetWeatherValuesByYearMonthDay(year, month, day).AsEnumerable())
            {
                Weather weather = new Weather();
                weather.DataId = (int)dr["data_id"];
                weather.Temperature = (double)dr["temperature"];
                weather.WindSpeed = (double)dr["windspeed"];
                weather.Humidity = (double)dr["humidity"];
                weather.Year = (int)dr["year"];
                weather.Month = (int)dr["month"];
                weather.Day = (int)dr["day"];
                weather.Hour = (int)dr["hour"];
                weather.time_inserterd = (DateTime)dr["time_inserted"];

                weather_data.Add(weather);
            }
            return weather_data;
        }

        public List<Weather> GetWeatherValuesByYearMonth(int year, int month, int hour)
        {
            DBLayer dBLayer = new DBLayer();
            List<Weather> weather_data = new List<Weather>();
            //mapping stuff
            foreach (DataRow dr in dBLayer.GetWeatherValuesByYearMonth(year, month, hour).AsEnumerable())
            {
                Weather weather = new Weather();
                weather.DataId = (int)dr["data_id"];
                weather.Temperature = (double)dr["temperature"];
                weather.WindSpeed = (double)dr["windspeed"];
                weather.Humidity = (double)dr["humidity"];
                weather.Year = (int)dr["year"];
                weather.Month = (int)dr["month"];
                weather.Day = (int)dr["day"];
                weather.Hour = (int)dr["hour"];
                weather.time_inserterd = (DateTime)dr["time_inserted"];

                weather_data.Add(weather);
            }
            return weather_data;
        }
    }
}
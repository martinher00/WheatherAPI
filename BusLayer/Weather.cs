using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLayer
{
    public class Weather
    {
        public void InsertWeatherValues(double temp, double windSpeed, double humidity)
        {
            DBLayer dBLayer = new DBLayer();
            dBLayer.InsertWeatherValues(temp, windSpeed, humidity);
        }
    }
}

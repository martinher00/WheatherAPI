using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseLayer
{
    public class DBLayer
    {
        public DBLayer() { }
        public void InsertWeatherValues(double temp,double windSpeed,double humidity)
        {
            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO weather_data VALUES (@temp, @windSpeed, @humidity);", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@temp", SqlDbType.Float);
                param.Value = temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@windSpeed", SqlDbType.Float);
                param.Value = windSpeed;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@humidity", SqlDbType.Float);
                param.Value = humidity;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

    }
}

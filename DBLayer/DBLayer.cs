using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DataBaseLayer
{
    public class DBLayer
    {
        public DBLayer() { }
        public void InsertWeatherValues(double temp,double windSpeed,double humidity,DateTime datetime)
        {
            // splitting DateTime into Day, Month and Year
            int yr = datetime.Year;
            int mn = datetime.Month;
            int dy = datetime.Day;
            int hr = datetime.Hour;

            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO weather_data VALUES (@temp, @windSpeed, @humidity, @year, @month, @day, @hour, @time_inserted);", conn);
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

                param = new SqlParameter("@year", SqlDbType.Int);
                param.Value = yr;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@month", SqlDbType.Int);
                param.Value = mn;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@day", SqlDbType.Int);
                param.Value = dy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@hour", SqlDbType.Int);
                param.Value = hr;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@time_inserted", SqlDbType.DateTime);
                param.Value = datetime;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DataTable GetWeatherValues()
        {
            DataTable dt = new DataTable(); 
            
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather_data ", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt;
        }
    }
}

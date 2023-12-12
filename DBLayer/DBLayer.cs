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

        public DataTable GetAllWeatherValues()
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

        public DataTable GetWeatherValuesByYearMonthDay(int yr, int mn, int dy)
        {

            DataTable dt = new DataTable();

            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather_data WHERE year = @yr AND month = @mn AND day = @dy", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@yr", SqlDbType.Float);
                param.Value = yr;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@mn", SqlDbType.Float);
                param.Value = mn;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@dy", SqlDbType.Float);
                param.Value = dy;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt;
        }

        public DataTable GetWeatherValuesByYearWeek(int yr, int wk, int hr)
        {

            DataTable dt = new DataTable();

            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather_data WHERE year = @yr AND week = @wk AND hour = @hr", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@yr", SqlDbType.Float);
                param.Value = yr;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@wk", SqlDbType.Float);
                param.Value = hr;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@hr", SqlDbType.Float);
                param.Value = hr;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt;
        }

        public DataTable GetWeatherValuesByYearMonth(int yr, int mn, int hr)
        {

            DataTable dt = new DataTable();

            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather_data WHERE year = @yr AND month = @mn AND hour = @hr", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@yr", SqlDbType.Float);
                param.Value = yr;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@mn", SqlDbType.Float);
                param.Value = mn;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@hr", SqlDbType.Float);
                param.Value = hr;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt;
        }
    }
}

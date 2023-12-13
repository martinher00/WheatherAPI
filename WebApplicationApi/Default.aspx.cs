using BusLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplicationApi
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownLists();

                LabelTimeSpanMonthly.Visible = false;
            }
        }

        protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownLists();
        }

        protected void DropDownListMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownLists();
        }

        private void BindDropDownLists()
        {
            // Adding days to dropdownlist
            DropDownListDays.Items.Clear();
            int year = int.Parse(DropDownListYear.SelectedValue);
            int monthNumber = int.Parse(DropDownListMonth.SelectedValue);
            int days = System.DateTime.DaysInMonth(year, monthNumber);

            for (int i = 1; i < days + 1; i++)
            {
                DropDownListDays.Items.Add(i.ToString());

            }

            // Adding hours to dropdownlist
            DropDownListHour.Items.Clear();

            for (int i = 1; i < 24 + 1; i++)
            {
                DropDownListHour.Items.Add(i.ToString());

            }
        }

        protected void ExecuteQuery_Click(object sender, EventArgs e)
        {
            string timespan = DropDownListTimeSpan.SelectedValue.ToString();
            int year = int.Parse(DropDownListYear.SelectedValue);
            int month = int.Parse(DropDownListMonth.SelectedValue);
            int day = int.Parse(DropDownListDays.SelectedValue);
            int hour;

            try
            {
                hour = int.Parse(DropDownListHour.SelectedValue);
            }
            catch 
            { 
                hour = 0;
            }
            

            Weather weather = new Weather();
            List<Weather> weatherList = new List<Weather>();

            weatherList = weather.GetWeatherValuesByUserInput(timespan, year, month, day, hour);

            WeatherChartBind(weatherList, timespan);
            
        }

        protected void WeatherChartBind(List<Weather> weatherList, string timespan)
        {
            ChartWeatherTemp.Series[0].YValueMembers = "Temperature";

            switch (timespan)
            {   case "daily":
                    ChartWeatherTemp.Series[0].XValueMember = "Hour";
                    ChartWeatherTemp.ChartAreas[0].AxisX.Title = "Hours";
                    break;
                case "monthly":
                    ChartWeatherTemp.Series[0].XValueMember = "Day";
                    ChartWeatherTemp.ChartAreas[0].AxisX.Title = "Days";
                    break;
            }
            
            try
            {
                ChartWeatherTemp.Width = 500;
                var max = weatherList.Max(t => t.Temperature);

                ChartWeatherTemp.DataSource = weatherList;
                ChartWeatherTemp.DataBind();
            }
            catch (Exception ex)
            {
                return;
            }    
        }
        protected void DropDownListTimeSpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownListTimeSpan.SelectedValue.ToString())
            {
                case "daily":
                    DropDownListYear.Visible = true;
                    DropDownListMonth.Visible = true;
                    DropDownListDays.Visible = true;
                    DropDownListHour.Visible = false;

                    LabelTimeSpanDaily.Visible = true;
                    LabelTimeSpanMonthly.Visible = false;
                    LabelSelectHour.Visible = false;
                    break;
                case "monthly":
                    DropDownListYear.Visible = true;
                    DropDownListMonth.Visible = true;
                    DropDownListDays.Visible = false;
                    DropDownListHour.Visible = true;

                    LabelTimeSpanDaily.Visible = false;
                    LabelTimeSpanMonthly.Visible = true;
                    LabelSelectHour.Visible = true;
                    break;
                default:
                    return;
            }
        }
    }
}
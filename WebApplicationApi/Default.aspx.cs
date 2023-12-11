using BusLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace WebApplicationApi
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            if (DropDownListTimeSpan.SelectedValue == "daily")
            {
                BindDropDownListDays();
            }
            else if (DropDownListTimeSpan.SelectedValue == "monthly")
            {
                DropDownListDays.Visible = false;
            }
            else { BindDropDownListDays(); }


        }

        private void BindDropDownListDays()
        {
            DropDownListDays.Items.Clear();
            int year = int.Parse(DropDownListYear.SelectedValue);
            int monthNumber = int.Parse(DropDownListMonth.SelectedValue);
            int days = System.DateTime.DaysInMonth(year, monthNumber);

            for (int i = 1; i < days + 1; i++)
            {
                DropDownListDays.Items.Add(i.ToString());

            }
        }

        protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownListDays();
        }

        protected void DropDownListMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownListDays();
        }

        protected void ExecuteQuery_Click(object sender, EventArgs e)
        {
            int year = int.Parse(DropDownListYear.SelectedValue);
            int monthNumber = int.Parse(DropDownListMonth.SelectedValue);
            int day = int.Parse(DropDownListDays.SelectedValue);

            Weather weather = new Weather();

            List<Weather> weatherList = new List<Weather>();
            weatherList = weather.GetWeatherValuesByYearMonthDay(year, monthNumber, day);

            try
            {
                var max = weatherList.Max(t => t.Temperature);

                ChartWeatherTemp.DataSource = weatherList;
                ChartWeatherTemp.Series[0].YValueMembers = "Temperature";
                ChartWeatherTemp.Series[0].XValueMember = "Hour";
            }
            catch (Exception ex)
            {
                return;
            }

            ChartWeatherTemp.DataBind();
        }
    }
}
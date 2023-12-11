using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using BusLayer;

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

            var max = weatherList.Max(t => t.Temperature);

            ChartWeatherTemp.DataSource = weatherList;
            ChartWeatherTemp.Series[0].XValueMember = "Temperature";
            ChartWeatherTemp.Series[0].YValueMembers = "Hour"; 

            ChartWeatherTemp.DataBind();
        }
    }
}
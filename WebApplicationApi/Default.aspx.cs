using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationApi
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDropDownListDates();
        }

        private void BindDropDownListDates()
        {
            int monthNumber = int.Parse(DropDownListMonth.SelectedValue);
            int days;

            switch(monthNumber)
            {
                case 01:
                    days = 31;
                    for (int i = 1; i < days+1; i++)
                    {
                        DropDownListDate.Items.Add(i.ToString());
                    }

                    break;
                case 02:
                    days = 28;
                    break;
                case 03:
                    days = 31;
                    break;
                case 04:
                    days = 30;
                    break;
                case 05:
                    days = 31;
                    break;
                case 06:
                    days = 30;
                    break;
                case 07:
                    days = 31;
                    break;
                case 08:
                    days = 31;
                    break;
                case 09:
                    days = 30;
                    break;
                case 10:
                    days = 31;
                    break;
                case 11:
                    days = 30;
                    break;
                case 12:
                    days = 31;
                    break;
            }
        }
    }
}
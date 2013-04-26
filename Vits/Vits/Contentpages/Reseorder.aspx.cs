using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vits
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calendarFromDate_SelectionChanged(object sender, EventArgs e)
        {
            txtTravelFromDate.Text = calendarFromDate.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void calendarToDate_SelectionChanged(object sender, EventArgs e)
        {
            txtTravelToDate.Text = calendarToDate.SelectedDate.ToString("yyyy-M-dd");
        }

    }
}
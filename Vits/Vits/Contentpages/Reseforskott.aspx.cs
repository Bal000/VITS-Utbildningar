using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vits.Contentpages
{
    public partial class Reseforskott : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Send_Click(object sender, EventArgs e)
        {

        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            tbDate.Text = Calendar.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vits
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void cbFardsatt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFardsatt.Checked == true)
            {
                ddlFardsatt.Enabled = true;
                if (ddlFardsatt.SelectedIndex == 0)
                {
                    txtMiltal.Enabled = true;
                }
            }
            else
            {
                ddlFardsatt.Enabled = false;
                txtMiltal.Enabled = false;
                txtMiltal.Text = "";
            }

            
        }

        protected void ddlFardsatt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFardsatt.SelectedIndex == 0)
                txtMiltal.Enabled = true;
            else
            {
                txtMiltal.Enabled = false;
                txtMiltal.Text = "";
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string myString = Calendar1.SelectedDate.ToString().Substring(0,10);
            txtFrom.Text = myString;
        }
    }
}
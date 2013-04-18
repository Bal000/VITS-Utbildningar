using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vits
{
    public partial class Uppdrag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlChef.Items.Add("Välj chef");
            ddlKontor.Items.Add("Välj uppdragskontor");

        }

        protected void btnSkapaUppdrag_Click(object sender, EventArgs e)
        {
            
        }

        protected void Kalender_SelectionChanged(object sender, EventArgs e)
        {
            tbDatum.Text = Kalender.SelectedDate.ToString("yyyy-MM-dd");
        }

        
    }
}
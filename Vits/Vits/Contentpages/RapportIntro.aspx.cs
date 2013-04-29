using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using Vits.ServiceReference1;


namespace Vits
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string currentUser = "";
        int eid = 0;
        List<CompositeMission> missList;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            missList = new List<CompositeMission>();
            currentUser = HttpContext.Current.User.Identity.Name;

            
        }

        protected void btnTillRapport_Click(object sender, EventArgs e)
        {
            Klasser.Global.currentMission = ddlChooseMission.SelectedValue.ToString();
            Response.Redirect("~/Contentpages/Rapport.aspx");
        }

        protected void FillMissonsDDL()
        {
            using (var client = new ServiceReference1.Service1Client())
            {
                eid = client.GetEmployeeByIdNumber(currentUser);

                missList = client.GetMissionsByEid(eid);

                foreach (CompositeMission m in missList)
                {
                    ddlChooseMission.Items.Add(new ListItem(m.Office.Name + ", " + m.Description)); 
                }
            
            }
        }
    }
}
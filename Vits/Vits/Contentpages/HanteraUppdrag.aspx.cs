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
            

        }

        protected void btnEditMission_Click(object sender, EventArgs e)
        {
            btnEditMission.Visible = false;
            btnAddMission.Visible = false;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = true;
            btnSave.Visible = true;

            ddManager.Enabled = true;
            ddOffice.Enabled = true;
            tbDescription.Enabled = true;
            Calendar.Enabled = true;
        }

        protected void btnAddMission_Click(object sender, EventArgs e)
        {
            btnEditMission.Visible = false;
            btnAddMission.Visible = false;
            btnAddMission2.Visible = true;
            btnAvbryt.Visible = true;
            btnSave.Visible = false;

            ddManager.Enabled = true;
            ddOffice.Enabled = true;
            tbDescription.Enabled = true;
            Calendar.Enabled = true;
        }

        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            btnEditMission.Visible = true;
            btnAddMission.Visible = true;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = false;
            btnSave.Visible = false;

            ddManager.Enabled = false;
            ddOffice.Enabled = false;
            tbDescription.Enabled = false;
            Calendar.Enabled = false;
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            tbDate.Text = Calendar.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void btnAddMission_Click1(object sender, EventArgs e)
        {
            ServiceReference1.Mission mission = new ServiceReference1.Mission;

            mission.OID = byte.Parse(ddOffice.SelectedValue);
            mission.MID = byte.Parse(ddManager.SelectedValue);
            mission.Description = tbDescription.Text;
            mission.StartDate = DateTime.Parse(tbDate.Text);

        }

        
    }
}
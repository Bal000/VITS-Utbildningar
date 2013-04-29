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
        string Office = "";
        string Manager = "";
        string Description = "";
        DateTime Date = new DateTime();
        

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEditMission_Click(object sender, EventArgs e)
        {
            /*
            if((MissionList.SelectedValue) == null)
            {
                MissionList.Visible = true;

            } else{
                buttonsEditMission();
                setFieldsEnabled(true);
            }
             */
        }

        protected void btnAddMission_Click(object sender, EventArgs e)
        {
            buttonsAddMission();
            //MissionList.SelectedValue = null;
            setFieldsEnabled(true);
            resetFields();
        }

        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            buttonsAvbryt();
            resetFields();
            setFieldsEnabled(false);
        }        

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            tbDate.Text = Calendar.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void btnAddMission2_Click(object sender, EventArgs e)
        {
            setFields();
            ServiceReference1.Employee testemployee = new ServiceReference1.Employee();
            ServiceReference1.Office testoffice = new ServiceReference1.Office();
            ServiceReference1.Mission mission = new ServiceReference1.Mission();
            mission.Description = Description;
            mission.Office = testoffice;
            mission.Employee = testemployee;
            mission.StartDate = Date;



            buttonsAddMission2();
            setFieldsEnabled(false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            setFields();
            setFieldsEnabled(false);
            buttonsSave();
        }

        private void buttonsEditMission()
        {
            btnEditMission.Visible = false;
            btnAddMission.Visible = false;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = true;
            btnSave.Visible = true;
        }

        private void buttonsAddMission()
        {
            btnEditMission.Visible = false;
            btnAddMission.Visible = false;
            btnAddMission2.Visible = true;
            btnAvbryt.Visible = true;
            btnSave.Visible = false;
        }

        private void buttonsAvbryt()
        {
            btnEditMission.Visible = true;
            btnAddMission.Visible = true;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = false;
            btnSave.Visible = false;
        }

        private void buttonsAddMission2()
        {
            btnEditMission.Visible = true;
            btnAddMission.Visible = true;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = false;
            btnSave.Visible = false;
        }

        private void buttonsSave()
        {
            btnSave.Visible = false;
            btnAvbryt.Visible = false;
            btnAddMission2.Visible = false;
            btnAddMission.Visible = true;
            btnEditMission.Visible = true;
        }

        protected void setFieldsEnabled(bool x)
        {
            ddManager.Enabled = x;
            ddOffice.Enabled = x;
            tbDescription.Enabled = x;
            Calendar.Enabled = x;
        }

        protected void resetFields()
        {
            ddOffice.SelectedValue = "";
            ddManager.SelectedValue = "";
            tbDescription.Text = "";
            tbDate.Text = "";
            DateTime x = new DateTime();
            Calendar.SelectedDate = x;
        }
        protected void setFields()
        {
            Office = ddOffice.SelectedValue.ToString();
            Manager = ddManager.SelectedValue.ToString();
            Description = tbDescription.Text;
            Date = Calendar.SelectedDate;
        }
        protected void btnAddMission_Click1(object sender, EventArgs e)
        {
            ServiceReference1.Mission mission = new ServiceReference1.Mission();

            mission.OID = byte.Parse(ddOffice.SelectedValue);
            mission.MID = byte.Parse(ddManager.SelectedValue);
            mission.Description = tbDescription.Text;
            mission.StartDate = DateTime.Parse(tbDate.Text);

        }

        protected void gwMissions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gwMissions.DataKeys[index].Value.ToString());
            ServiceReference1.CompositeMission mission = new ServiceReference1.CompositeMission();
            ServiceReference1.Service1Client x = new ServiceReference1.Service1Client();
            mission = x.GetMission(id);

        }

        protected void gwMissions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
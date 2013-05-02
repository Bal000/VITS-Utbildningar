using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vits.ServiceReference1;

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
            //setDD();
            
        }
        protected void setDD()
        {
            ddEmployee.SelectedValue = null;
            ddManager.SelectedValue = null;
            ddOffice.SelectedValue = null;
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
        protected void updateGW()
        {
            gwMissions.DataBind();
        }
        protected void btnAddMission_Click(object sender, EventArgs e)
        {
            buttonsAddMission();
            //MissionList.SelectedValue = null;
            setFieldsEnabled(true);
            resetFields();
            setDD();

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
            ServiceReference1.Service1Client x = new ServiceReference1.Service1Client();
            setFields();
            ServiceReference1.CompositeMission mission = new ServiceReference1.CompositeMission();
            mission.Description = Description;



            int oid = Convert.ToInt32(ddOffice.SelectedValue);
            ServiceReference1.CompositeOffice office = new ServiceReference1.CompositeOffice();
            office = x.GetOffice(oid);
            mission.OID = office.OID;

            int eid = Convert.ToInt32(ddEmployee.SelectedValue);
            ServiceReference1.CompositeEmployee employee = new ServiceReference1.CompositeEmployee();
            employee = x.GetEmployee(eid);
            mission.EID = employee.EID;

            mission.StartDate = Date;

            int manager = Convert.ToInt32(ddManager.SelectedValue);
            ServiceReference1.CompositeEmployee mana = new ServiceReference1.CompositeEmployee();
            mana = x.GetEmployee(manager);
            mission.Manager = mana.EID;

            
            x.SaveMission(mission);


            buttonsAddMission2();
            setFieldsEnabled(false);
            updateGW();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            setFields();
            setFieldsEnabled(false);
            buttonsSave();
        }

        private void buttonsEditMission()
        {
            btnAddMission.Visible = false;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = true;
        }

        private void buttonsAddMission()
        {
            btnAddMission.Visible = false;
            btnAddMission2.Visible = true;
            btnAvbryt.Visible = true;
        }

        private void buttonsAvbryt()
        {
            btnAddMission.Visible = true;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = false;
        }

        private void buttonsAddMission2()
        {
            btnAddMission.Visible = true;
            btnAddMission2.Visible = false;
            btnAvbryt.Visible = false;
        }

        private void buttonsSave()
        {
            btnAvbryt.Visible = false;
            btnAddMission2.Visible = false;
            btnAddMission.Visible = true;
        }

        protected void setFieldsEnabled(bool x)
        {
            ddManager.Enabled = x;
            ddOffice.Enabled = x;
            tbDescription.Enabled = x;
            Calendar.Enabled = x;
            ddEmployee.Enabled = x;
        }

        

        
        protected void resetFields()
        {
            ddOffice.SelectedValue = null;
            ddManager.SelectedValue = null;
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

            tbDate.Text = mission.StartDate.ToString();
            tbDescription.Text = mission.Description;
            Calendar.SelectedDate = mission.StartDate;
            int officeid = mission.OID;
            int managerid = mission.Manager;
            int employeeid = mission.EID;

            ServiceReference1.CompositeOffice office = new ServiceReference1.CompositeOffice();
            ServiceReference1.CompositeEmployee manager = new ServiceReference1.CompositeEmployee();
            ServiceReference1.CompositeEmployee employee = new ServiceReference1.CompositeEmployee();

            office = x.GetOffice(officeid);
            manager = x.GetEmployee(managerid);
            employee = x.GetEmployee(employeeid);


            ddOffice.Items.FindByValue(office.OID.ToString()).Selected = true;
            
            ddManager.Items.FindByValue(manager.EID.ToString()).Selected = true;

            ddEmployee.Items.FindByValue(employee.EID.ToString()).Selected = true;

            /*
            ListItem off = ddOffice.Items.FindByValue(office.OID.ToString());
            ListItem man = ddManager.Items.FindByValue(manager.EID.ToString());
            ListItem emp = ddEmployee.Items.FindByText(employee.EID.ToString());

            List<ListItem> ddofficelistan = new List<ListItem>();
            for (int i = 0; i < ddOffice.Items.Count; i++)
            {
                ddofficelistan.Add(ddOffice.Items[i]);
            }
            for (int i = 0; i < ddofficelistan.Count; i++)
            {
                if (ddofficelistan[i] == off)
                {
                    ddOffice.SelectedIndex = i;
                }
            }
            List<ListItem> ddmanagerlistan = new List<ListItem>();
            for (int i = 0; i < ddManager.Items.Count; i++)
            {
                ddmanagerlistan.Add(ddManager.Items[i]);
            }
            for (int i = 0; i < ddmanagerlistan.Count; i++)
            {
                if (ddmanagerlistan[i] == man)
                {
                    ddManager.SelectedIndex = i;
                }
            }
            List<ListItem> ddemployeelistan = new List<ListItem>();
            for (int i = 0; i < ddEmployee.Items.Count; i++)
            {
                ddemployeelistan.Add(ddEmployee.Items[i]);
            }
            for (int i = 0; i < ddemployeelistan.Count; i++)
            {
                if (ddemployeelistan[i] == emp)
                {
                    ddEmployee.SelectedIndex = i;
                }
            }

            */
            
            
    }

        /*
        protected void FillDropDowns()
        {

            using (var client = new ServiceReference1.Service1Client())
            {
                List<ServiceReference1.CompositeOffice> officeList = new List<CompositeOffice>();
                officeList = client.GetOffices();

                ddOffice.DataSource = officeList;

                foreach (ServiceReference1.CompositeOffice office in officeList)
                {
                    ddOffice.Items.Add(office.Name);
                }


                List<ServiceReference1.CompositeEmployee> empList = new List<CompositeEmployee>();
                empList = client.GetEmployees();

                ddManager.DataSource = empList;

                foreach (ServiceReference1.CompositeEmployee emp in empList)
                {
                    if (emp.Manager == true)
                    {
                        ddManager.Items.Add(emp.FirstName + " " + emp.LastName);
                    }
                }

                List<ServiceReference1.CompositeEmployee> empList2 = new List<CompositeEmployee>();
                empList2 = client.GetEmployees();

                ddEmployee.DataSource = empList2;

                foreach (ServiceReference1.CompositeEmployee emp in empList2)
                {
                    
                        ddEmployee.Items.Add(emp.FirstName + " " + emp.LastName);
                    
                }


                ddOffice.DataSource = officeList;
                ddOffice.DataTextField = "Name";
                ddOffice.DataValueField = "OID";
                ddOffice.DataBind();
                ddManager.DataSource = empList;
                ddManager.DataTextField = "FirstName";
                ddManager.DataValueField = "EID";
                ddManager.DataBind();
                ddEmployee.DataSource = empList2;
                ddEmployee.DataTextField = "FirstName";
                ddEmployee.DataValueField = "EID";
                ddEmployee.DataBind();
            }
        }
       */
}

}
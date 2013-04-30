using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Vits
{
    public partial class WebForm5 : System.Web.UI.Page

    {
        UppdragStatus uppdrag; 
        protected void Page_Load(object sender, EventArgs e)
        {
             uppdrag = new UppdragStatus();
            LoadMissions();
        }

       
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        

             //Ej skickad, alla 3 false.
            if (e.Row.Cells[6].Text.ToString().ToLower() == "false" && e.Row.Cells[5].Text.ToString().ToLower() == "false" && e.Row.Cells[2].Text.ToString().ToLower() == "false") 
            {
                Button button = new Button();
                e.Row.Cells[2].Controls.Add(button);

                button.ID = "btnSendTravelOrder";
                button.Visible = true;
                button.Width = 150;
                button.Height = 30;
                button.Text = "Skicka in reseorder";
                button.Click += new EventHandler(this.button_Click);
                button.CssClass = "button";
                uppdrag.TravelOrder.SENT = true;
            }
            // INskickad sent true resten false
            else if (e.Row.Cells[6].Text.ToString().ToLower() == "true" && e.Row.Cells[2].Text.ToString().ToLower() == "false" && e.Row.Cells[5].Text.ToString().ToLower() == "false")
            {
                Label label = new Label();
                e.Row.Cells[2].Controls.Add(label);
                label.CssClass = "Inskickad";
                label.Text = "Inskickad";
            }
            // Godkänd      alla true
            else if (e.Row.Cells[6].Text.ToString().ToLower() == "true" && e.Row.Cells[2].Text.ToString().ToLower() == "true" && e.Row.Cells[5].Text.ToString().ToLower() == "true")
            {
                Label label = new Label();
                e.Row.Cells[2].Controls.Add(label);
                label.CssClass = "Godkand";
    
                label.Text = "Godkänd";
            }

            // Ej godkänd  sent true, approved false, answered = true
            else if (e.Row.Cells[6].Text.ToString().ToLower() == "true" && e.Row.Cells[2].Text.ToString().ToLower() == "false" && e.Row.Cells[5].Text.ToString().ToLower() == "true")
            {
                Label label = new Label();
                e.Row.Cells[2].Controls.Add(label);
                label.CssClass = "Ejgodkand";
                label.Text = "Ej godkänd";
            }

            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

        void button_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/Contentpages/ReseOrder.aspx");
        }
        

        protected void LoadMissions()
        {


            using (var client = new ServiceReference1.Service1Client())
            {
                
                List<UppdragStatus> missionList = new List<UppdragStatus>();
                //String currUser = HttpContext.Current.User.Identity.Name;

                //int eid = client.GetEmployeeByIdNumber(currUser);

                //missionList = client.GetMissionsByEid(eid);

                
                uppdrag.Mission.Description = "CGI";
                uppdrag.Mission.StartDate = DateTime.Today;
                uppdrag.Mission.EID = 1;
                uppdrag.Mission.MID = 1;
                uppdrag.TravelOrder.SENT = true;
                uppdrag.TravelOrder.Approved = true;
                uppdrag.TravelOrder.Answered = true;
                
                             //Sent, Ap, An
                // Skickad      1, 0, 0
                // Ej godkänd   1, 0, 1   
                // Godkänd      1, 1, 1
                // Ej skickad   0, 0, 0

                missionList.Add(uppdrag);
                
                

               
                



                GridView1.DataSource = missionList;
                GridView1.DataBind();

            }

        
        }
    }
}
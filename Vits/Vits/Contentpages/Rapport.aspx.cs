using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;

namespace Vits
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<Klasser.Traktamente> lstTraktamente;
        private Klasser.Traktamente traktamente;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lstTraktamente = new List<Klasser.Traktamente>();
            traktamente = new Klasser.Traktamente("", 0);
            FillCountry();
        }

        protected void FillCountry()
        {
            String sokvag_traktamente_adress = "http://www.skatteverket.se/privat/skatter/arbeteinkomst/traktamente/utlandstraktamente.4.2b543913a42158acf800016035.html";
            String sokvag_traktamente_fil = @"c:\vits\trakt.html";

            if (!Directory.Exists(@"c:\vits"))
            {
                Directory.CreateDirectory(@"c:\vits");
                Debug.WriteLine("\n\nSkapar mapp c:\\vits\n\n");
            }

            lstTraktamente = traktamente.HamtaUtlandstraktamenten(sokvag_traktamente_adress, sokvag_traktamente_fil);

            for (int i = 0; i < lstTraktamente.Count; i++)
            {
                ddlCountry.Items.Add(lstTraktamente[i].Land);
                ddlTractCountry.Items.Add(lstTraktamente[i].Land);
            }
        }

        
        
        // Valt land = DropDownList Index (ddlIndex)
        protected void btnAddReceipt_Click(object sender, EventArgs e)
        {
            int ddlIndex = ddlCountry.SelectedIndex;
            Klasser.Global.PopUp(lstTraktamente[ddlIndex].Land + " " + lstTraktamente[ddlIndex].Kronor);
        }
    }
}

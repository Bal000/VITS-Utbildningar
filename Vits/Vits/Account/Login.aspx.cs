using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vits.ServiceReference1;

namespace Vits.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            //SetCountries();
        }

        private static void SetCountries()
        {
            List<Klasser.Traktamente> lander = new List<Klasser.Traktamente>();
            String sokvagTraktamenteFil = @"c:\vits\trakt.html";
            lander = Klasser.Traktamente.HamtaUtlandstraktamenten(Klasser.Global.sokvagTraktamenteAdress, sokvagTraktamenteFil);

            List<string> land = new List<string>();

            for (int i = 0; i < lander.Count; i++)
            {
                CompositeCountry country = new CompositeCountry();

                country.Name = lander[i].Land;

                using (var client = new Service1Client())
                {
                    client.SaveCountry(country);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;


namespace Vits
{
    public partial class HanteraKunder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEditOffice_Click(object sender, EventArgs e)
        {
            btnAvbryt.Visible = true;
            btnSaveOffice.Visible = true;
            btnEditOffice.Visible = false;
            btnAddOffice.Visible = false;
            Tbadress.Enabled = true;
            Tbcity.Enabled = true;
            Tbnamn.Enabled = true;
            Tborgnummer.Enabled = true;
            Tbzipcode.Enabled = true;
            ddLand.Enabled = true;
            
            
        }

        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            btnAddOffice2.Visible = false;
            btnAvbryt.Visible = false;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = true;
            btnAddOffice.Visible = true;
            Tbadress.Enabled = false;
            Tbcity.Enabled = false;
            Tbnamn.Enabled = false;
            Tborgnummer.Enabled = false;
            Tbzipcode.Enabled = false;
            ddLand.Enabled = false;
        }

        protected void btnAddOffice_Click(object sender, EventArgs e)
        {
            btnAvbryt.Visible = true;
            btnAddOffice2.Visible = true;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = false;
            btnAddOffice.Visible = false;
            Tbadress.Enabled = true;
            Tbcity.Enabled = true;
            Tbnamn.Enabled = true;
            Tborgnummer.Enabled = true;
            Tbzipcode.Enabled = true;
            ddLand.Enabled = true;

            ServiceReference1.Office office = new ServiceReference1.Office();
            office.Adress = Tbadress.Text;
            office.City = Tbcity.Text;
           // office.Country = int.Parse(ddLand.SelectedItem);//
            office.OrgNumber = int.Parse(Tborgnummer.Text);
            office.ZipCode = int.Parse(Tbzipcode.Text);
            office.Name = Tbnamn.Text;

            
            


        
        }

        protected void btnSaveOffice_Click(object sender, EventArgs e)
        {
            btnAvbryt.Visible = false;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = true;
            btnAddOffice.Visible = true;
            Tbadress.Enabled = false;
            Tbcity.Enabled = false;
            Tbnamn.Enabled = false;
            Tborgnummer.Enabled = false;
            Tbzipcode.Enabled = false;
            ddLand.Enabled = false;
            OfficeList.SelectedValue = null;
        }
    }
}
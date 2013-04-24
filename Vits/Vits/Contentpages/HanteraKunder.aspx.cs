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

        private List<Klasser.Traktamente> lstAllaTraktamenten;
        string Name = "";
        string OrgNumber = "";
        string Address = "";
        string ZipCode = "";
        string City = "";
        string Country = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void FillCountry()
        {
            String sokvagTraktamenteFil = @"c:\vits\trakt.html";
            lstAllaTraktamenten = Klasser.Traktamente.HamtaUtlandstraktamenten(Klasser.Global.sokvagTraktamenteAdress, sokvagTraktamenteFil);

            for (int i = 0; i < lstAllaTraktamenten.Count; i++)
            {
                ddlCountry.Items.Add(lstAllaTraktamenten[i].Land);
            }
        }
        protected void btnEditOffice_Click(object sender, EventArgs e)
        {
            buttonsEditOffice();

            setFieldsEnabled(true);
        }
        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            buttonsAvbryt();

            setFieldsEnabled(false);
        }
        protected void btnAddOffice_Click(object sender, EventArgs e)
        {
            buttonsAddOffice();

            setFieldsEnabled(true);
            FillCountry();
        }
        protected void btnAddOffice2_Click(object sender, EventArgs e)
        {
            
            ServiceReference1.Country testland = new ServiceReference1.Country();
            

            ServiceReference1.Office office = new ServiceReference1.Office();
            office.Adress = Address;
            office.City = City;
            office.Country = testland;
            office.OrgNumber = Convert.ToInt32(OrgNumber);
            office.ZipCode = Convert.ToInt32(ZipCode);
            office.Name = Name;

            buttonsAddOffice2();
            setFieldsEnabled(true);
        }
        protected void btnSaveOffice_Click(object sender, EventArgs e)
        {
            buttonsSaveOffice();
            setFieldsEnabled(false);
            OfficeList.SelectedValue = null;
        }
        private void setFieldsEnabled(bool x)
        {
            Tbadress.Enabled = x;
            Tbcity.Enabled = x;
            Tbnamn.Enabled = x;
            Tborgnummer.Enabled = x;
            Tbzipcode.Enabled = x;
            ddlCountry.Enabled = x;
        }
        private void setAttributes()
        {
            Address = Tbadress.Text;
            City = Tbcity.Text;
            Name = Tbnamn.Text;
            OrgNumber = Tborgnummer.Text;
            ZipCode = Tbzipcode.Text;
            Country = ddlCountry.SelectedValue.ToString();

        }
        private void buttonsAddOffice()
        {
            btnAvbryt.Visible = true;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = false;
            btnAddOffice.Visible = false;
            btnAddOffice2.Visible = true;
        }
        private void buttonsEditOffice()
        {
            btnAvbryt.Visible = true;
            btnSaveOffice.Visible = true;
            btnEditOffice.Visible = false;
            btnAddOffice.Visible = false;
        }
        private void buttonsAddOffice2()
        {
            btnAvbryt.Visible = true;
            btnAddOffice2.Visible = true;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = false;
            btnAddOffice.Visible = false;
        }
        private void buttonsSaveOffice()
        {
            btnAvbryt.Visible = false;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = true;
            btnAddOffice.Visible = true;
        }
        private void buttonsAvbryt()
        {
            btnAddOffice2.Visible = false;
            btnAvbryt.Visible = false;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = true;
            btnAddOffice.Visible = true;
        }
    }
}
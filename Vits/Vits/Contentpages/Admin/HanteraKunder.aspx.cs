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
        string OfficeName = "";
        string OrgNumber = "";
        string Address = "";
        string ZipCode = "";
        string City = "";
        string Country = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        
        }
        protected void updateGW()
        {
            gwOffices.DataBind();
        }
        protected void btnEditOffice_Click(object sender, EventArgs e)
        {
            buttonsEditOffice();

            setFieldsEnabled(true);
        }
        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            buttonsAvbryt();
            resetFields();
            setFieldsEnabled(false);
        }
        protected void btnAddOffice_Click(object sender, EventArgs e)
        {
            buttonsAddOffice();
            resetFields();
            setFieldsEnabled(true);
        }
        protected void btnAddOffice2_Click(object sender, EventArgs e)
        {
            setAttributes();
            
            ServiceReference1.Service1Client x = new ServiceReference1.Service1Client();


            ServiceReference1.CompositeOffice office = new ServiceReference1.CompositeOffice();
            office.Adress = Address;
            office.City = City;

            int CID = Convert.ToInt32(ddlCountry.SelectedValue);
            
            //office.Country = ddlCountry.SelectedItem;
            int n;
            bool r = int.TryParse(OrgNumber, out n);
            office.OrgNumber = n;
            int n2;
            bool r2 = int.TryParse(ZipCode, out n2);
            office.ZipCode = n2;
            office.Name = OfficeName;
            office.CID = CID;

            
            
            x.SaveOffice(office);

            buttonsAddOffice2();
            setFieldsEnabled(false);
            updateGW();
            resetFields();

        }
        protected void btnSaveOffice_Click(object sender, EventArgs e)
        {
            buttonsSaveOffice();
            setFieldsEnabled(false);
            //OfficeList.SelectedValue = null;
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
            OfficeName = Tbnamn.Text;
            OrgNumber = Tborgnummer.Text;
            ZipCode = Tbzipcode.Text;
            Country = ddlCountry.SelectedValue.ToString();

        }
        private void buttonsAddOffice()
        {
            btnAvbryt.Visible = true;
            btnAddOffice.Visible = false;
            btnAddOffice2.Visible = true;
        }
        private void buttonsEditOffice()
        {
            btnAvbryt.Visible = true;
            btnAddOffice.Visible = false;
        }
        private void buttonsAddOffice2()
        {
            btnAvbryt.Visible = false;
            btnAddOffice2.Visible = false;
            btnAddOffice.Visible = true;
        }
        private void buttonsSaveOffice()
        {
            btnAvbryt.Visible = false;
            btnAddOffice.Visible = true;
            btnAddOffice2.Visible = false;
        }
        private void buttonsAvbryt()
        {
            btnAddOffice2.Visible = false;
            btnAvbryt.Visible = false;
            btnAddOffice.Visible = true;
        }
        protected void gwOffices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gwOffices.DataKeys[index].Value.ToString());
            ServiceReference1.CompositeOffice office = new ServiceReference1.CompositeOffice();
            ServiceReference1.Service1Client x = new ServiceReference1.Service1Client();
            office = x.GetOffice(id);

            Tbnamn.Text = office.Name.ToString();
            Tborgnummer.Text = office.OrgNumber.ToString();
            Tbzipcode.Text = office.ZipCode.ToString();
            Tbcity.Text = office.City.ToString();
            Tbadress.Text = office.Adress.ToString();

            int cid = office.CID;
            ddlCountry.ClearSelection();
            ddlCountry.Items.FindByValue(cid.ToString()).Selected = true;
        }
        protected void resetFields()
        {
            Tbnamn.Text = "";
            Tbadress.Text = "";
            Tbcity.Text = "";
            Tborgnummer.Text = "";
            Tbzipcode.Text = "";
            
            ddlCountry.SelectedValue = null;
        }
    }
}
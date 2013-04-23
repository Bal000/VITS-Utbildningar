using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vits
{
    public partial class HanteraKunder : System.Web.UI.Page
    {
        string Name = "";
        string Adress = "";
        string City = "";
        string Organisationnumber = "";
        string Zipcode = "";
        string Country = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEditOffice_Click(object sender, EventArgs e)
        {
            if ((OfficeList.SelectedValue) == null)
            {
                lblOfficeList.Visible = true;

            }
            else
            {
                buttonsEditoffice();
                setFieldsEnabled(true);
            }
        }

        

        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            buttonsAvbryt();
            setFieldsEnabled(false);
            OfficeList.SelectedValue = "";
            resetFields();
        }

        protected void btnAddOffice_Click(object sender, EventArgs e)
        {
            buttonsAddoffice();
            setFieldsEnabled(true);
            resetFields();
            OfficeList.SelectedValue = null;
        }

        protected void btnSaveOffice_Click(object sender, EventArgs e)
        {
            buttonsSaveOffice();
            setFieldsEnabled(false);
            OfficeList.SelectedValue = null;
            setAttributes();
            resetFields();
        }

        
        

        protected void btnAddOffice2_Click(object sender, EventArgs e)
        {
            buttonsAddOffice2();
            setFieldsEnabled(false);
            OfficeList.SelectedValue = null;

            setAttributes();
            resetFields();
        }

        private void buttonsAddoffice()
        {
            btnAvbryt.Visible = true;
            btnAddOffice2.Visible = true;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = false;
            btnAddOffice.Visible = false;

        }
        private void buttonsAvbryt()
        {
            btnAddOffice2.Visible = false;
            btnAvbryt.Visible = false;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = true;
            btnAddOffice.Visible = true;
        }
        private void buttonsSaveOffice()
        {
            btnAvbryt.Visible = false;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = true;
            btnAddOffice.Visible = true;
        }
        private void buttonsEditoffice()
        {
            btnAvbryt.Visible = true;
            btnSaveOffice.Visible = true;
            btnEditOffice.Visible = false;
            btnAddOffice.Visible = false;
        }
        private void buttonsAddOffice2()
        {
            btnAddOffice2.Visible = false;
            btnAvbryt.Visible = false;
            btnSaveOffice.Visible = false;
            btnEditOffice.Visible = true;
            btnAddOffice.Visible = true;
        }

        
        protected void setFieldsEnabled(bool x)
        {
            Tbadress.Enabled = x;
            Tbcity.Enabled = x;
            Tbnamn.Enabled = x;
            Tborgnummer.Enabled = x;
            Tbzipcode.Enabled = x;
            ddLand.Enabled = x;
        }
        protected void resetFields()
        {
            Tbnamn.Text = "";
            Tbadress.Text = "";
            Tbcity.Text = "";
            Tborgnummer.Text = "";
            Tbzipcode.Text = "";
            ddLand.SelectedValue = null;
        }

        protected void setAttributes()
        {
            Name = Tbnamn.Text;
            Adress = Tbadress.Text;
            City = Tbcity.Text;
            Organisationnumber = Tborgnummer.Text;
            Zipcode = Tbzipcode.Text;
            Country = ddLand.SelectedValue.ToString();
        }
    }

}
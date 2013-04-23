using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vits.Contentpages
{
    public partial class HanteraAnvandare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            btnAvbryt.Visible = true;
            btnSave.Visible = true;
            btnEditUser.Visible = false;
            btnAddUser.Visible = false;
            tbCity.Enabled = true;
            tbEmail.Enabled = true;
            tbFirstName.Enabled = true;
            tbID.Enabled = true;
            tbLastName.Enabled = true;
            tbZipCode.Enabled = true;
            tbAdress.Enabled = true;
            radiobutton.Enabled = true;
        }

        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            btnAddUser2.Visible = false;
            btnSave.Visible = false;
            btnAvbryt.Visible = false;
            btnEditUser.Visible = true;
            btnAddUser.Visible = true;
            tbAdress.Enabled = false;
            tbCity.Enabled = false;
            tbEmail.Enabled = false;
            tbFirstName.Enabled = false;
            tbID.Enabled = false;
            tbLastName.Enabled = false;
            tbZipCode.Enabled = false;
            radiobutton.Enabled = false;
            
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnAddUser2.Visible = true;
            btnAvbryt.Visible = true;
            btnEditUser.Visible = false;
            btnAddUser.Visible = false;
            tbAdress.Enabled = true;
            tbCity.Enabled = true;
            tbEmail.Enabled = true;
            tbFirstName.Enabled = true;
            tbID.Enabled = true;
            tbLastName.Enabled = true;
            tbZipCode.Enabled = true;
            radiobutton.Enabled = true;

            ServiceReference1.Employee employee = new ServiceReference1.Employee();

            employee.FirstName = tbFirstName.Text;
            employee.LastName = tbLastName.Text;
            employee.Adress = tbAdress.Text;
            employee.ZipCode = tbZipCode.Text;
            employee.City = tbCity.Text;
            employee.IdNumber = tbID.Text;
            employee.Email = tbEmail.Text;

            if(radiobutton.SelectedIndex == 0){
                employee.Manager = false;
            }
            else{
                employee.Manager = true;
            }
            


        
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnAvbryt.Visible = false;
            btnEditUser.Visible = true;
            btnAddUser.Visible = true;
            tbAdress.Enabled = false;
            tbCity.Enabled = false;
            tbEmail.Enabled = false;
            tbFirstName.Enabled = false;
            tbID.Enabled = false;
            tbLastName.Enabled = false;
            tbZipCode.Enabled = false;
            radiobutton.Enabled = false;
            UserList.SelectedValue = null;
        }

        
    }
}
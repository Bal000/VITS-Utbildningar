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
        string Adress = "";
        string City = "";
        string Email = "";
        string FirstName = "";
        string ID = "";
        string LastName = "";
        string ZipCode = "";
        string roll = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            if ((UserList.SelectedValue) == null)
            {
                UserList.Visible = true;

            }
            else
            {
                buttonsEditUser();
                setFieldsEnabled(true);
            }
        }

        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            buttonsAvbryt();
            UserList.SelectedValue = null;
            setFieldsEnabled(false);
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            buttonsAddUser();
            UserList.SelectedValue = "";
            setFieldsEnabled(true);
            resetFields();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            buttonsSave();
            UserList.SelectedValue = null;
            setFieldsEnabled(false);
            setAttributes();
        }

        protected void btnAddUser2_Click(object sender, EventArgs e)
        {
            setAttributes();
            resetFields();
            buttonsAddUser2();
            setFieldsEnabled(false);
            UserList.SelectedValue = null;
        }

        private void buttonsEditUser()
        {
            btnAvbryt.Visible = true;
            btnSave.Visible = true;
            btnEditUser.Visible = false;
            btnAddUser.Visible = false;
            btnAddUser2.Visible = false;
        }

        private void buttonsSave()
        {
            btnSave.Visible = false;
            btnAvbryt.Visible = false;
            btnEditUser.Visible = true;
            btnAddUser.Visible = true;
        }

        private void buttonsAvbryt()
        {
            btnAddUser2.Visible = false;
            btnSave.Visible = false;
            btnAvbryt.Visible = false;
            btnEditUser.Visible = true;
            btnAddUser.Visible = true;
        }

        private void buttonsAddUser()
        {
            btnSave.Visible = false;
            btnAddUser2.Visible = true;
            btnAvbryt.Visible = true;
            btnEditUser.Visible = false;
            btnAddUser.Visible = false;
<<<<<<< HEAD
=======
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
            


        
>>>>>>> ändring i contentpages
        }

        private void buttonsAddUser2()
        {
            btnAddUser2.Visible = false;
            btnSave.Visible = false;
            btnAvbryt.Visible = false;
            btnEditUser.Visible = true;
            btnAddUser.Visible = true;
        }
        
        protected void setFieldsEnabled(bool x)
        {
            tbAdress.Enabled = x;
            tbCity.Enabled = x;
            tbEmail.Enabled = x;
            tbFirstName.Enabled = x;
            tbID.Enabled = x;
            tbLastName.Enabled = x;
            tbZipCode.Enabled = x;
            radiobutton.Enabled = x;
        }
        protected void resetFields()
        {
            tbAdress.Text = "";
            tbCity.Text = "";
            tbEmail.Text = "";
            tbFirstName.Text = "";
            tbID.Text = "";
            tbLastName.Text = "";
            tbZipCode.Text = "";
            radiobutton.SelectedValue = null;
        }
        protected void setAttributes()
        {
            Adress = tbAdress.Text;
            City = tbCity.Text;
            Email = tbEmail.Text;
            FirstName = tbFirstName.Text;
            ID = tbID.Text;
            LastName = tbLastName.Text;
            ZipCode = tbZipCode.Text;
            roll = radiobutton.SelectedValue.ToString();
        }
        
        
        
    }
}
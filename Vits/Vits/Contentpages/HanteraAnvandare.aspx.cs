using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;
using System.Web.Security;

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
        bool Manager = false;

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

            ServiceReference1.Employee employee = new ServiceReference1.Employee();
            employee.Adress = Adress;
            employee.City = City;
            employee.Email = Email;
            employee.FirstName = FirstName;  
            employee.LastName = LastName;
            employee.ZipCode = ZipCode;
            employee.IdNumber = ID; 
            employee.Manager = Manager;

            //Lägger till i databasen
            ServiceReference1.Service1Client x = new ServiceReference1.Service1Client();
            x.SaveEmployee(employee);

            //Lägger till i WebProfiles för inloggning
            System.Web.Security.Membership.CreateUser(ID, "pass123");
            string roll = "";
            if (Manager == true)
            {
                roll = "Admin";
            }
            else
            {
                roll = "User";
            }
            Roles.AddUserToRole(ID, roll);

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


            setFieldsEnabled(true);


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
            if (radiobutton.SelectedValue.ToString() == "Konsult")
            {
                Manager = false;
            }
            else if(radiobutton.SelectedValue.ToString() == "Chef")
            {
                Manager = true;
            }
        }
        
        
        
    }
}
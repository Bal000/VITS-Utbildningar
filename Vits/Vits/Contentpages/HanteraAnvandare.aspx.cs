using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;
using System.Web.Security;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.ServiceModel;
using Vits.ServiceReference1;


namespace Vits.Contentpages
{
    public partial class HanteraAnvandare : System.Web.UI.Page
    {
        string adress = "";
        string city = "";
        string email = "";
        string firstname = "";
        string idnumber = "";
        string lastname = "";
        string zipcode = "";
        bool manager = false;

        protected void Page_Load(object sender, EventArgs e)
        {
           
                
                fillUserList();
                    
        }

        private void fillUserList()
        {
            UserList.Items.Clear();

            List<CompositeEmployee> employees = new List<CompositeEmployee>();
            var client = new ServiceReference1.Service1Client();

            employees = client.GetEmployees();

            for (int i = 0; i < employees.Count; i++)
            {
                UserList.Items.Add(employees[i].IdNumber);
                
            }
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
            UserList.SelectedValue = null;
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

            ServiceReference1.CompositeEmployee employee = new ServiceReference1.CompositeEmployee();
            employee.Adress = adress;
            employee.City = city;
            employee.Email = email;
            employee.FirstName = firstname;  
            employee.LastName = lastname;
            employee.ZipCode = zipcode;
            employee.IdNumber = idnumber; 
            employee.Manager = manager;

            //Lägger till i databasen
            ServiceReference1.Service1Client x = new ServiceReference1.Service1Client();
            x.SaveEmployee(employee);

            //Lägger till i WebProfiles för inloggning
            System.Web.Security.Membership.CreateUser(idnumber, "pass123");
            string roll = "";
            if (manager == true)
            {
                roll = "Admin";
            }
            else
            {
                roll = "User";
            }
            Roles.AddUserToRole(idnumber, roll);

            resetFields();
            buttonsAddUser2();
            setFieldsEnabled(false);
            UserList.SelectedValue = null;
            fillUserList();
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
            adress = tbAdress.Text;
            city = tbCity.Text;
            email = tbEmail.Text;
            firstname = tbFirstName.Text;
            idnumber = tbID.Text;
            lastname = tbLastName.Text;
            zipcode = tbZipCode.Text;
            if (radiobutton.SelectedValue.ToString() == "Konsult")
            {
                manager = false;
            }
            else if(radiobutton.SelectedValue.ToString() == "Chef")
            {
                manager = true;
            }
        }
        
        
        
    }
}
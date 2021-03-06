﻿using System;
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
           
                
                //fillUserList();
                    
        }

       

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            /*
            if ((UserList.SelectedValue) == null)
            {
                UserList.Visible = true;

            }
            else
            {
                buttonsEditUser();
                setFieldsEnabled(true);
            }
             */
        }

        protected void btnAvbryt_Click(object sender, EventArgs e)
        {
            buttonsAvbryt();
            //UserList.SelectedValue = null;
            setFieldsEnabled(false);
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            buttonsAddUser();
            //UserList.SelectedValue = null;
            setFieldsEnabled(true);
            resetFields();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            buttonsSave();
            //UserList.SelectedValue = null;
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
            updateGW();
        }

        protected void updateGW()
        {
            gwUsers.DataBind();
        }

        private void buttonsEditUser()
        {
            btnAvbryt.Visible = true;
            btnAddUser.Visible = false;
            btnAddUser2.Visible = false;
        }

        private void buttonsSave()
        {
            btnAvbryt.Visible = false;
            btnAddUser.Visible = true;
        }

        private void buttonsAvbryt()
        {
            btnAddUser2.Visible = false;
            btnAvbryt.Visible = false;
            btnAddUser.Visible = true;
        }

        private void buttonsAddUser()
        {
            btnAddUser2.Visible = true;
            btnAvbryt.Visible = true;
            btnAddUser.Visible = false;


            setFieldsEnabled(true);


        }

        private void buttonsAddUser2()
        {
            btnAddUser2.Visible = false;
            btnAvbryt.Visible = false;
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

        protected void gwUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gwUsers.DataKeys[index].Value.ToString());
            ServiceReference1.CompositeEmployee employee = new ServiceReference1.CompositeEmployee();
            ServiceReference1.Service1Client x = new ServiceReference1.Service1Client();
            employee = x.GetEmployee(id);

            tbAdress.Text = employee.Adress.ToString();
            tbCity.Text = employee.City;
            tbEmail.Text = employee.Email;
            tbFirstName.Text = employee.FirstName;
            tbLastName.Text = employee.LastName;
            tbID.Text = employee.IdNumber;
            tbZipCode.Text = employee.ZipCode;

            if (employee.Manager == true)
            {

                radiobutton.Items.FindByText("Konsult").Selected = false;
                radiobutton.Items.FindByText("Chef").Selected = true;
            }
            else
            {
                radiobutton.Items.FindByText("Chef").Selected = false;
                radiobutton.Items.FindByText("Konsult").Selected = true;

            }

        }

        protected void gwUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        
        
    }
}
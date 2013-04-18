using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Vits.Klasser
{
    public static class Validator
    {
      
        public static bool ValidateEmail(TextBox tbox, Label lbl, Label error)
        {
            Regex rx = new Regex("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");
            if(!rx.IsMatch(tbox.Text))
            {
               lbl.Text = "Inte en godkänd email-adress!";
              lbl.Visible = true;
                return false;
            }
           error.Visible = false;
            return true;
            
        }
       
        public static bool ValidateRequiredField(TextBox tboxReq, Label lbl, Label error)
        {
            
            tboxReq.Text = tboxReq.Text.Trim();
            tboxReq.Text = tboxReq.Text.Replace(" ", "");
            
            if (tboxReq.Text == "") // Kollar giltigt värde.
            {
                lbl.Visible = true;
                lbl.Text = "";
                return false;
            }

            error.Visible = false;
            return true;
        }
        
        public static bool ValidateTextLength(TextBox tboxName, Label lbl, Label error, int min, int max)
        {

            if ( tboxName.Text.Length > min && tboxName.Text.Length < max)
            {
                lbl.Visible = true;
                lbl.Text = "";
                return false;
            }

            error.Visible = false;
            return true;
        }
        
        public static bool ValidateEmailLength(TextBox tboxEmail, Label lbl, Label error, int min, int max)
        {
            if (tboxEmail.Text.Length > min && tboxEmail.Text.Length < max)
            {
                lbl.Text = "";
                lbl.Visible = true;
                return false;
            }
            error.Visible = false;
            return true;

        }
        
        public static bool ValidateDescriptionLength(TextBox tboxDescription, Label lbl, Label error, int min, int max)
        {
            if (tboxDescription.Text.Length > min && tboxDescription.Text.Length < max)
            {
              lbl.Text = "";
              lbl.Visible = true;
              return false;
            }
            error.Visible = false;
            return true;
            
        }

        public static bool ValueSelectedDropDown(DropDownList dropDown, Label lbl, string text, string felMeddelande)
        {
            if (dropDown.SelectedValue == text)
            {
                lbl.Text = felMeddelande ;
                lbl.Visible = true;
                return false;
            }

            lbl.Visible = false;
            return true;
        }

       
       
        //protected bool IsValidInformation()
        //{
        //    //return ValidateFname() &&
        //    //       ValidateLname() &&
        //    //       ValidateEmailLength() &&
        //    //       ValidateEmail() &&
        //    //       ValidateDescriptionLength();

        //}

    }
}
    

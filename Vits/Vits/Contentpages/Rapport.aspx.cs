using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vits
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string[] datumLista = new string[2];

        private string[] DatumLista
        {
            get { return datumLista;}
            set { datumLista = DatumLista;}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void cbOwnCar_CheckedChanged(object sender, EventArgs e)
        {
            
            if (cbOwnCar.Checked)
            {
                lblMiles.Visible = true;
                txtlOWnCar.Visible = true;
                txtlOWnCar.Focus();
                txtlOWnCar.Enabled = true;
            }

            else 
            {
                lblMiles.Visible = false;
                txtlOWnCar.Visible = false;
            }
        }

        protected void calFrom_SelectionChanged(object sender, EventArgs e)
        {
            string fromDate = calFrom.SelectedDate.ToShortDateString();
            string x = "calFrom";
            calToList(fromDate, x);
           
        }

        private void calToList(string date, string calname)
        {
            
            
            if(calname.Equals("calFrom"))
            {
                datumLista[0] = date;
                
            }

            if (calname.Equals("calTo"))
            {
                datumLista[1] = date;
                
            }

            else {
                Console.WriteLine("Skickade med fel parametrar bro!");
            }
     

           
        }

        protected void calTo_SelectionChanged(object sender, EventArgs e)
        {
            string toDate = calTo.SelectedDate.ToShortDateString();
            string x = "calTo";
            calToList(toDate, x);
        }

       

      
    }
}
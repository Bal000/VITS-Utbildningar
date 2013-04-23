using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Vits
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<ServiceReference1.Expense> expenseList;
        private List<Klasser.Traktamente> lstAllaTraktamenten;
        private List<Klasser.Traktamente> lstTraktamenteGrid;
        private List<String> lstRadioKnappar;

        protected void Page_Load(object sender, EventArgs e)
        {
            ID = Guid.NewGuid().ToString();
            FillCategoryDropDown();
            lstAllaTraktamenten = new List<Klasser.Traktamente>();
            lstTraktamenteGrid = new List<Klasser.Traktamente>();
            lstRadioKnappar = new List<String>();
            expenseList = new List<ServiceReference1.Expense>();
            FillCountry();
            
            
           



            if (Session["RADIO"] != null)
            {
                lstRadioKnappar = (List<String>)Session["RADIO"];
                Debug.WriteLine(lstRadioKnappar.Count + "<--- längd radio");
                RadioButtonList rbl = new RadioButtonList();
            }


        }



        protected void FillCountry()
        {
            String sokvagTraktamenteFil = @"c:\vits\trakt.html";
            lstAllaTraktamenten = Klasser.Traktamente.HamtaUtlandstraktamenten(Klasser.Global.sokvagTraktamenteAdress, sokvagTraktamenteFil);

            for (int i = 0; i < lstAllaTraktamenten.Count; i++)
            {
                ddlCountry.Items.Add(lstAllaTraktamenten[i].Land);
                ddlTractCountry.Items.Add(lstAllaTraktamenten[i].Land);
            }
        }

        //lägg till
        protected void btnTract_Click(object sender, EventArgs e)
        {
            int ddlIndex = ddlTractCountry.SelectedIndex;
            lstRadioKnappar.Clear(); // test

            if (Session["TRAKT"] != null)
            {
                lstTraktamenteGrid = (List<Klasser.Traktamente>)Session["TRAKT"];
            }
            Klasser.Traktamente tm = new Klasser.Traktamente(lstAllaTraktamenten[ddlIndex].Land,
                                                            lstAllaTraktamenten[ddlIndex].Kronor,
                                                            calFrom.SelectedDate.ToShortDateString());
            lstTraktamenteGrid.Add(tm);
            Response.Write("Antal objekt: " + lstTraktamenteGrid.Count);
            Session["TRAKT"] = lstTraktamenteGrid;

            gwTract.DataSource = lstTraktamenteGrid;
            gwTract.DataBind();

            BeraknaTraktamente();

        }

        // ta bort
        protected void gwTract_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0)
                {
                    RadioButtonList rbl = (RadioButtonList)gwTract.Rows[index].FindControl("RadioButtonList1");
                    if (rbl != null)
                    {
                        if (Session["TRAKT"] != null)
                        {
                            lstTraktamenteGrid = (List<Klasser.Traktamente>)Session["TRAKT"];
                        }

                        lstTraktamenteGrid.RemoveAt(index);
                        Response.Write("Antal objekt: " + lstTraktamenteGrid.Count);
                        Session["TRAKT"] = lstTraktamenteGrid;

                        gwTract.DataSource = lstTraktamenteGrid;
                        gwTract.DataBind();
                    }
                }
            }
        }


        // beräkna
        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Klasser.Traktamente> lstBerakna = new List<Klasser.Traktamente>();
            int ddlIndex = ddlTractCountry.SelectedIndex;

            if (Session["TRAKT"] != null)
            {
                lstTraktamenteGrid = (List<Klasser.Traktamente>)Session["TRAKT"];
            }

            for (int i = 0; i < lstTraktamenteGrid.Count; i++)
            {
                RadioButtonList rbl = (RadioButtonList)gwTract.Rows[i].FindControl("RadioButtonList1");
                if (rbl != null)
                {
                    //String valtAvdrag = rbl.SelectedItem.Text; // ändra till Value istället (säkrare!!!)
                    int nyttTraktamente = BeraknaAvdrag(rbl.SelectedItem.Value, lstTraktamenteGrid[i].Kronor); // Traktamente - avdrag (mat)
                    lstBerakna.Add(new Klasser.Traktamente(lstTraktamenteGrid[i].Land, nyttTraktamente, lstTraktamenteGrid[i].Datum));
                }
            }

            for (int i = 0; i < lstBerakna.Count; i++)
            {
                Debug.WriteLine(lstBerakna[i].Datum + " " +
                                    lstBerakna[i].Land + " " +
                                    lstBerakna[i].Kronor);
            }

            Session["TRAKT"] = lstTraktamenteGrid;

        }


        protected void Save_Radio()
        {
            if (Session["RADIO"] != null)
            {
                lstRadioKnappar = (List<String>)Session["RADIO"];
            }
            for (int i = 0; i < lstTraktamenteGrid.Count - 1; i++)
            {
                RadioButtonList rbl = (RadioButtonList)gwTract.Rows[i].FindControl("RadioButtonList1");
                if (rbl != null)
                {
                    lstRadioKnappar.Add(rbl.SelectedItem.Value);
                }
            }
            Session["RADIO"] = lstRadioKnappar;
        }


        // avdrag procent
        protected int BeraknaAvdrag(String avdrag, int kronor)
        {
            int avdragProcent;
            float nyTrakt = (float)kronor;
            bool b = int.TryParse(avdrag, out avdragProcent);
            if (!b)
            {
                Klasser.Global.PopUp("Fel i BeräknaAvdrag()");
                return 0;
            }

            switch (avdragProcent)
            {
                case 0:
                    {
                        nyTrakt = (float)kronor;
                        break;
                    }
                case 1:
                    {
                        nyTrakt = (float)(kronor * 0.85); // 15% avdrag
                        break;
                    }

                case 2:
                    {
                        nyTrakt = (float)(kronor * 0.65); // 35% avdrag
                        break;
                    }
                case 3:
                    {
                        nyTrakt = (float)(kronor * 0.30); // 70% avdrag
                        break;
                    }
                case 4:
                    {
                        nyTrakt = (float)(kronor * 0.15); // 85% avdrag
                        break;
                    }
            }
            return (int)Math.Round(nyTrakt);
        }

        protected void btnAddReceipt_Click(object sender, EventArgs e)
        {
            

            if (ID != "")
            {
                ServiceReference1.Expense expenseObj = new ServiceReference1.Expense();
                expenseObj.REPID = ID;
                string value = ddlCategory.SelectedValue.ToString();
                int newVal = 0;

                switch (value)
                {
                    case "Mat":
                        {
                            newVal = 1;
                            break;
                        }
                    case "Transport": 
                        {
                            newVal = 2;
                            break;
                    }
                    case "Boende":
                        {
                            newVal = 3;
                            break;
                        }
                    case "Övrigt": 
                        {
                            newVal = 4;
                            break;
                        }
                
                }
                
               
                expenseObj.CCID = (byte) newVal;
                expenseObj.From = Convert.ToDateTime(txtBoxDateFrom.Text);
                expenseObj.To = Convert.ToDateTime(txtBoxDateTo.Text);
                expenseObj.Sum = int.Parse(txtBoxAmount.Text);
                expenseObj.Description = txtBoxDescription.Text;

                if (ddlCountry.SelectedValue.ToString().Equals("Sverige"))
                {
                    switch (ddlCategory.SelectedValue.ToString())
                    {
                        case "Mat":
                            {
                                expenseObj.VAT = 12;
                                break;
                            }
                        case "Transport":
                            {
                                expenseObj.VAT = 6;
                                break;
                            }

                        case "Boende":
                            {
                                expenseObj.VAT = 25;
                                break;
                            }
                        case "Övrigt":
                            {
                                expenseObj.VAT = 25;
                                break;
                            }
                        default:
                            {
                                expenseObj.VAT = 0;
                                break;
                            }
                    }
                }
                else
                {
                    expenseObj.VAT = 0;
                }


                expenseList.Add(expenseObj);
            }

            
                FillExpenseGrid();
        }

        protected void FillCategoryDropDown()
        {
            using (var client = new ServiceReference1.Service1Client())
            {
                List<ServiceReference1.CostCenter> costCenterList = client.GetCostCenterList();

                ddlCategory.DataSource = costCenterList;

                foreach (ServiceReference1.CostCenter cost in costCenterList)
                {
                    ddlCategory.Items.Add(cost.Name);
                }

            }
        }

        protected void BeraknaTraktamente()
        {
            DateTime fromDate = calFrom.SelectedDate.Date;
            DateTime toDate = calTo.SelectedDate.Date;

            TimeSpan result = fromDate.Subtract(toDate);
            Double result2 = result.TotalDays;

            lblTest.Text = result2.ToString();
        }

        protected void FillExpenseGrid()
        {   
            gvReciept.DataSource = expenseList;
            gvReciept.DataBind();
        }

        protected void Click(object sender, EventArgs e)
        {

        }
    }
}

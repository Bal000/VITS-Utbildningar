using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Text;
using Vits.ServiceReference1;

namespace Vits
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<ServiceReference1.Expense> expense;
        private List<Klasser.Traktamente>   lstAllaTraktamenten;
        private List<Klasser.Traktamente>   lstTraktamenteGrid;
        private List<Klasser.Traktamente>   lstTraktTillRapport;
        private List<DateTime>              lstAvvikelserTillRapport;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = Guid.NewGuid().ToString();
            lstAllaTraktamenten     = new List<Klasser.Traktamente>();
            lstTraktamenteGrid      = new List<Klasser.Traktamente>();
            lstTraktTillRapport     = new List<Klasser.Traktamente>();
            lstAvvikelserTillRapport = new List<DateTime>();
        
            lstTraktTillRapport.Clear();
            FillCountry();
        }




// ________________________________________________ BÖRJAN TRAKTAMENTEN / AVVIKELSER ______________________________________________________


        // ------------------------------------------------------------------------------------------------------
        // Fyll dropdown
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




        // ------------------------------------------------------------------------------------------------------
        // Lägg till
        protected void LaggTillTraktGrid(DateTime date)
        {
            int ddlIndex = ddlTractCountry.SelectedIndex;
            
            if (Session["TRAKT"] != null)
            {
                lstTraktamenteGrid = (List<Klasser.Traktamente>)Session["TRAKT"];
            }
            Klasser.Traktamente tm = new Klasser.Traktamente(lstAllaTraktamenten[ddlIndex].Land,
                                                                lstAllaTraktamenten[ddlIndex].Kronor,
                                                                date.ToShortDateString());
            lstTraktamenteGrid.Add(tm);
            Session["TRAKT"] = lstTraktamenteGrid;

            lstTraktamenteGrid = lstTraktamenteGrid.OrderBy(x => x.Datum).ToList();
            gwTract.DataSource = lstTraktamenteGrid;
            gwTract.DataBind();
            
        }
        
        
        
        
        // ------------------------------------------------------------------------------------------------------
        //Välj datum (period)
        protected void btnTract_Click(object sender, EventArgs e)
        {
            ValjDatumForTraktamente();
            ddlTractCountry.Items.Clear();
            ddlCountry.Items.Clear();
            FillCountry();
            //Response.Write("Antal objekt i Trakt-GridView: " + lstTraktamenteGrid.Count);
        }




        // ------------------------------------------------------------------------------------------------------
        //  Beräkna Traktamenten + Avvikelser. Till Rapport
        // ------------------------------------------------------------------------------------------------------
        // knapp
        protected void Button2tmp_Click(object sender, EventArgs e)
        {
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
                    //String valtAvdrag = rbl.SelectedItem.Text; // Vilket avdrag = text
                    int nyttTraktamente = BeraknaAvdrag(rbl.SelectedItem.Value, lstTraktamenteGrid[i].Kronor); // Traktamente - avdrag (mat)
                    lstTraktTillRapport.Add(new Klasser.Traktamente(lstTraktamenteGrid[i].Land, nyttTraktamente, lstTraktamenteGrid[i].Datum));
                }
            }

            Session["TRAKT"] = lstTraktamenteGrid;

            
            lstAvvikelserTillRapport = Avvikelser(); // beräka avvikelser

            Debug.WriteLine("\n\n---------- Traktamente / Avvikelser ----------");
            for (int i = 0; i < lstAvvikelserTillRapport.Count; i++)
            {
                Debug.WriteLine("Avvikelse: " + lstAvvikelserTillRapport[i].ToShortDateString());
            }
            for (int i = 0; i < lstTraktTillRapport.Count; i++)
            {
                Debug.WriteLine("Traktamente: " + lstTraktTillRapport[i].Datum + " " + lstTraktTillRapport[i].Land + " " + lstTraktTillRapport[i].Kronor);
            }
            Debug.WriteLine("---------- SLUT RAPPORT ----------\n\n");
        }




        // ------------------------------------------------------------------------------------------------------
        // Väljer vilka datum som man ska ha traktamente
        protected void ValjDatumForTraktamente()
        {
            DateTime fromDate = calFrom.SelectedDate.Date;
            DateTime toDate = calTo.SelectedDate.Date;

            TimeSpan result = toDate.Subtract(fromDate);
            Double result2 = result.TotalDays + 1;

            DateTime date = fromDate;

            for (int i = 0; i < result2; i++)
            {
                LaggTillTraktGrid(date);
                date = date.AddDays(1);
            }
        }




        // ------------------------------------------------------------------------------------------------------
        //Avvikelser
        protected List<DateTime> Avvikelser()
        {
            lstTraktTillRapport = lstTraktTillRapport.OrderBy(x => x.Datum).ToList();
            DateTime dateStart = Convert.ToDateTime(lstTraktTillRapport[0].Datum);
            DateTime dateStop = Convert.ToDateTime(lstTraktTillRapport[lstTraktTillRapport.Count - 1].Datum);
            List<DateTime> lstAvTmp = new List<DateTime>();
            int i = 0;
                        
            while (dateStart <= dateStop)
            {
                if (dateStart.ToShortDateString() == lstTraktTillRapport[i].Datum)
                {
                    //Debug.WriteLine("yep");
                    i++;
                }
                else
                {
                    //Debug.WriteLine("Avvikelse: " + dateStart.ToShortDateString());

                    //DateTime nd = new DateTime();
                    //nd = dateStart;
                    lstAvTmp.Add(dateStart);
                }
                
                dateStart = dateStart.AddDays(1);
            }
            return lstAvTmp;
        }




        // ------------------------------------------------------------------------------------------------------
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




        // ------------------------------------------------------------------------------------------------------
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
// ________________________________________________ SLUT TRAKTAMENTEN / AVVIKELSER ________________________________________________
        



        // ------------------------------------------------------------------------------------------------------
        protected void btnAddReceipt_Click(object sender, EventArgs e)
        {
            if (ID != "")

            {
                ServiceReference1.Expense expenseObj = new ServiceReference1.Expense();
                expenseObj.REPID = ID;
                //expenseOjb.CostCenter = ddlCategory.SelectedValue;
                //expenseObj.From = Convert.ToDateTime(txtBoxDateFrom.Text);
                //expenseObj.To = Convert.ToDateTime(txtBoxDateTo.Text);
                expenseObj.Sum = int.Parse(txtBoxAmount.Text);
            }
        }
    }
}

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
using Vits;

namespace Vits
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<CompositeExpense> expense;
        private List<Klasser.Traktamente>   lstAllaTraktamenten;
        private List<Klasser.Traktamente>   lstTraktamenteGrid;
        private List<Klasser.Traktamente>   lstTraktTillRapport;
        private List<DateTime>              lstAvvikelserTillRapport;
        private string repID;
        private int totalExpenses = 0;
        private int missionID = 0;
        private int km = 0;
        private bool car = false;
        private string currentUser = "";
        private int eid = 0;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            SetRepID(); // gör nytt repID, om det finns, återställ från session

            lstAllaTraktamenten = new List<Klasser.Traktamente>();
            currentUser = HttpContext.Current.User.Identity.Name;
            SetMissionID();
            expense = new List<CompositeExpense>();
                
            //lstTraktTillRapport.Clear();
            
            FillCountry();
            FillCategoryDropDown();

        }

        private void SetRepID()
        {
            if (Session["REPID"] == null)
            {
                repID = Guid.NewGuid().ToString();
                Session["REPID"] = (string)repID;
            }
            if (Session["REPID"] != null)
            {
                repID = (string)Session["REPID"];
            }
        }

        //Börjar kod för Utgifter

        protected void FillCategoryDropDown() 
        {

            using (var client = new ServiceReference1.Service1Client())
            {
                List<ServiceReference1.CompositeCostCenter> costCenterList = client.GetCostCenter();

                ddlCategory.DataSource = costCenterList;

                foreach (ServiceReference1.CompositeCostCenter cost in costCenterList)
                {
                    ddlCategory.Items.Add(cost.Name);
                }

            }
        }

        //Slutar kod för Utgifter


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
            
            lstTraktamenteGrid = new List<Klasser.Traktamente>();
            

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

            BeraknaTraktAv();
        }

        private void BeraknaTraktAv()
        {
            lstTraktamenteGrid = new List<Klasser.Traktamente>();
            lstTraktTillRapport = new List<Klasser.Traktamente>();
            lstAvvikelserTillRapport = new List<DateTime>();
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

            lstTraktTillRapport = lstTraktTillRapport.OrderBy(x => x.Datum).ToList();

            lstAvvikelserTillRapport = Avvikelser(); // beräka avvikelser

            Session["TRAKT_RAPPORT"] = lstTraktTillRapport;
            Session["AVVIKELSE_RAPPORT"] = lstAvvikelserTillRapport;

            //Debug.WriteLine("\n\n---------- Traktamente / Avvikelser ----------");
            //for (int i = 0; i < lstAvvikelserTillRapport.Count; i++)
            //{
            //    Debug.WriteLine("Avvikelse: " + lstAvvikelserTillRapport[i].ToShortDateString());
            //}
            //for (int i = 0; i < lstTraktTillRapport.Count; i++)
            //{
            //    Debug.WriteLine("Traktamente: " + lstTraktTillRapport[i].Datum + " " + lstTraktTillRapport[i].Land + " " + lstTraktTillRapport[i].Kronor);
            //}
            //Debug.WriteLine("---------- SLUT RAPPORT ----------\n\n");


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
            
            lstTraktamenteGrid = new List<Klasser.Traktamente>();
            
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

            expense = new List<CompositeExpense>();

            if (Session["EXPENSE"] != null)
            {
                expense = (List<CompositeExpense>)Session["EXPENSE"];
            }

            if (repID != "")
            {
                CompositeExpense expenseObj = new CompositeExpense();
                expenseObj.REPID = repID;
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
                expenseObj.Date = Convert.ToDateTime(txtBoxDate.Text);
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


                expense.Add(expenseObj);
                
            }

            
                FillExpenseGrid();
                ClearExpenseFields();
                Session["EXPENSE"] = expense;
            
        }

        // Fyller alla utgifter i griden.
        protected void FillExpenseGrid()
        {
            gvReciept.DataSource = expense;
            gvReciept.DataBind();
        }

        // Sparar ner rapport
        protected void btnSendReport_Click(object sender, EventArgs e)
        {
            BeraknaTraktAv();

            setEID();
            countExpenses();
            CheckCar();
            //Skapar en ny rapport för sparning.
            CompositeReport rep = new CompositeReport();
            rep.REPID = repID;
            rep.EID = eid;
            rep.Expenses = totalExpenses;
            rep.MID = missionID;
            rep.Car = car;
            rep.Miles = km;

            //Rapportör
            CompositeEmployee emp = new CompositeEmployee();
            //ChefObjekt
            CompositeEmployee empChef = new CompositeEmployee();
            //Mission för att hämta manager.
            CompositeMission mission = new CompositeMission();
            //Chef
            int chefID = 0;

            using (var client = new Service1Client())
            {
                client.SaveReport(rep);

                SaveExpenses();
                SaveSubsistences();
                SaveDeviations();

                emp = client.GetEmployee(eid);

                mission = client.GetMission(missionID);

                chefID = mission.Manager;
                empChef = client.GetEmployee(chefID);
            }



            bool epostSkickat = Klasser.Epost.Skicka(empChef.Email, "Ny Rapport", "Du har en ny rapport att godkänna från: " + emp.FirstName + " " + emp.LastName);
            if (epostSkickat)
            {
            }
            

            

        }

        // Beräknar alla avvikelser
        protected void BeraknaTraktamenteAvvikelser()
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

            lstTraktTillRapport = lstTraktTillRapport.OrderBy(x => x.Datum).ToList();

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

        // Tömmer utgiftsfälten
        protected void ClearExpenseFields()
        {
            txtBoxDate.Text = "";
            txtBoxAmount.Text = "";
            txtBoxDescription.Text = "";
        }

        // Sparar alla utgifter
        protected void SaveExpenses()
        {
            if (Session["EXPENSE"] != null)
            {
                expense = (List<CompositeExpense>)Session["EXPENSE"];
            }
            using (var client = new Service1Client())
            {
                for (int i = 0; i < expense.Count; i++)
                {
                    CompositeExpense ex = new CompositeExpense();


                    ex.REPID = repID;
                    ex.CCID = expense[i].CCID;
                    ex.Sum = expense[i].Sum;
                    ex.VAT = expense[i].VAT;
                    ex.Date = expense[i].Date;
                    ex.Description = expense[i].Description;
                 
                    client.SaveExpense(ex);


                }
            }
        }

        // Summerar alla utgifter
        protected void countExpenses()
        {
            if (Session["EXPENSE"] != null)
            {
                expense = (List<CompositeExpense>)Session["EXPENSE"];
            }

            foreach (CompositeExpense ex in expense)
            {
                totalExpenses += ex.Sum;
            }       
        
        }

        // Sparar alla traktamenten
        protected void SaveSubsistences()
        {
            if (Session["TRAKT_RAPPORT"] != null)
            {
                lstTraktTillRapport = (List<Klasser.Traktamente>)Session["TRAKT_RAPPORT"];
            }

            

            using (var client = new Service1Client())
            {
                for (int i = 0; i < lstTraktTillRapport.Count; i++)
                {
                    CompositeSubsistence sub = new CompositeSubsistence();
                    sub.REPID = repID;
                    sub.CID = client.GetCountryIdByName(lstTraktTillRapport[i].Land);
                    sub.SUM = lstTraktTillRapport[i].Kronor;
                    sub.DATE = Convert.ToDateTime(lstTraktTillRapport[i].Datum);

                    client.SaveSubsistence(sub);
                }
            }
        }

        // Sparar alla avvikelser
        protected void SaveDeviations()
        {
            if (Session["AVVIKELSE_RAPPORT"] != null)
            {
                lstAvvikelserTillRapport = (List<DateTime>)Session["AVVIKELSE_RAPPORT"];
            }

            using (var client = new Service1Client())
           {
                for(int i = 0; i < lstAvvikelserTillRapport.Count; i++)
                {
                    CompositeDeviation dev = new CompositeDeviation();

                    dev.REPID = repID;
                    dev.StartDate = lstAvvikelserTillRapport[i].Date;
                    dev.StopDate = new DateTime();

                    client.SaveDeviation(dev);
              
                }
           
           
           }
        
        
        }


        protected void SetMissionID()
        {
            if (Session["currMission"] != null)
            {
                int mi = (int)Session["currMission"];
                missionID = mi;
            }
        
        
        }

        protected void CheckCar()
        {
                if (txtlOWnCar.Text != "")
                { 
                    km = int.Parse(txtlOWnCar.Text);
                    car = true;
                }                             
        }

        protected void setEID()
        {
            using (var client = new Service1Client())
            {
                eid = client.GetEmployeeByIdNumber(currentUser);           
            }
        
        }

        protected void cbOwnCar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwnCar.Checked)
                txtlOWnCar.Enabled = true;
            else
                txtlOWnCar.Enabled = false;
        }


    }
}

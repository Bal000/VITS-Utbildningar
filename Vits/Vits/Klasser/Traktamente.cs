/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;



namespace traktamente
{
    public partial class Form1 : Form
    {
        private String              sokvag_traktamente_fil, sokvag_traktamente_adress;
        private Traktamente         traktamente;         
        private List<Traktamente>   lstTraktamente;
        
        public Form1()
        {
            InitializeComponent();

            sokvag_traktamente_fil      = @"trakt.html";
            sokvag_traktamente_adress   = "http://www.skatteverket.se/privat/skatter/arbeteinkomst/traktamente/utlandstraktamente.4.2b543913a42158acf800016035.html";
            textBox1.Text               = sokvag_traktamente_adress;
           
            lstTraktamente              = new List<Traktamente>();
            traktamente                 = new Traktamente("" , 0);
            label2.Visible              = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            rensaTidigareSok();
            lstTraktamente = traktamente.HamtaUtlandstraktamenten(textBox1.Text, sokvag_traktamente_fil); 
            
            for (int i = 0; i < lstTraktamente.Count; i++)
            {
                dataGridView1.Rows.Add(lstTraktamente[i].Land, lstTraktamente[i].Kronor);
            }

            label2.Visible = false;
        }



        private void rensaTidigareSok()
        {
            label2.Visible = true;
            label2.Text = "Hämtar...";
            label2.Refresh();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            lstTraktamente.Clear();
        }
    }
}
*/


/*
 * (c) Johan Svensk 2013
 * 
 * Några länder har inget traktamente på Skatteverkets lista, hänvisar till annat land. Där har jag satt 0 kr som traktamente.
 * Göra ej valbara?
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Vits.Klasser
{
    class Traktamente
    {
        private String _land;
        private int _kronor;

        public Traktamente(String inLand, int inKronor)
        {
            _land = inLand;
            _kronor = inKronor;
        }
        
        public String Land 
        { 
            get { return _land; }
            set { _land = value; }
        }
        public int Kronor
        {
            get { return _kronor; }
            set { _kronor = value; }
        }
        
        
        
        public List<Traktamente> HamtaUtlandstraktamenten(string webbadr, string lokalfil)
        {
            List<string> lstLandTraktamente = new List<string>();
            List<Traktamente> lstTraktTmp = new List<Traktamente>();
            int hopp;

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(webbadr, lokalfil);
                }
                catch
                {
                    Console.WriteLine("ERROR in Traktamente: Fel adress???");
                    Environment.Exit(1);
                }
            }

            using (StreamReader reader = new StreamReader(lokalfil))
            {
                String rad, noHTMLstring;
                bool starta = false;

                while ((rad = reader.ReadLine()) != null)
                {
                    if (rad.Contains("<strong>A</strong>"))
                    {
                        starta = true;
                    }
                    if (starta == true)
                    {
                        noHTMLstring = StripHTML(rad);
                        noHTMLstring = noHTMLstring.Trim();

                        if (rad.Contains("<!-- Page content stops here -->"))
                        {
                            break;
                        }
                        if (noHTMLstring.Length > 1 && noHTMLstring.Contains("&nbsp;") == false)
                        {
                            lstLandTraktamente.Add(noHTMLstring);
                            if (noHTMLstring.Contains(", se"))
                            {
                                lstLandTraktamente.Add("0");
                            }
                        }
                    }
                }
            }

            hopp = 0;
            for (int i = 0; i < (lstLandTraktamente.Count / 2); i++)
            {
                String land = lstLandTraktamente[hopp];
                int kronor = int.Parse(lstLandTraktamente[hopp + 1].Replace(" ", ""));
                
                lstTraktTmp.Add(new Traktamente(land, kronor));
                hopp += 2;
            }

            return lstTraktTmp;
        }



        private String StripHTML(String inString)
        {
            char[] array = new char[inString.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < inString.Length; i++)
            {
                char tecken = inString[i];
                if (tecken == '<')
                {
                    inside = true;
                    continue;
                }
                if (tecken == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = tecken;
                    arrayIndex++;
                }
            }

            return new String(array, 0, arrayIndex);
        }
    }
}

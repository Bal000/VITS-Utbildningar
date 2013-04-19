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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vits.Klasser
{
    public static class Global
    {
        // aktuellt uppdrag
        public static String currentMission;
        
        // sökväg skatteverket traktamenten
        public static String sokvagTraktamenteAdress = "http://www.skatteverket.se/privat/skatter/arbeteinkomst/traktamente/utlandstraktamente.4.2b543913a42158acf800016035.html";
        
        // popup
        public static void PopUp(String meddelande) 
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"text/javascript\">alert(\"" + meddelande + "\")</SCRIPT>");
        }
    }
}
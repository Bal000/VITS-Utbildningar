using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vits.Klasser
{
    public static class Global
    {
        public static String currentMission;

        public static void PopUp(String meddelande) 
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"JavaScript\">alert(\"" + meddelande + "\")</SCRIPT>");
        }
    }
}
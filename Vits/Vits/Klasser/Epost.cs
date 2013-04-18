/*
 * 
 * 
 * Skicka Epost 
 * 
    bool epostSkickat = Epost.Skicka("vitsprojektet@gmail.com", "Hej", "Här är meddelandet");
    if (epostSkickat) 
    { 
        label1.Text = "Success!"; 
    }
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Vits.Klasser
{
    public static class Epost
    {
        public static bool Skicka(string tillAdress, string rubrik, string meddelandeText)
        {
            const String franAdress = "vitsprojektet@gmail.com";
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("vitsprojektet@", "losen0rd");

            MailMessage epostMeddelande = new MailMessage(franAdress, tillAdress, rubrik, meddelandeText);
            
            epostMeddelande.BodyEncoding = UTF8Encoding.UTF8;
            epostMeddelande.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            
            try
            {
                client.Send(epostMeddelande);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n----------------------------------------\n" + 
                                        " > Skicka EPOST: " + ex.Message + 
                                        "\n > Ansluten till Internet?" +
                                    "\n----------------------------------------\n");
                return false;
            }
            
            return true;
        }
    }
}

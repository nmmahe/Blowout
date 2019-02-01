using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        
        //To send an email
        public ActionResult Email(String name, String email)
        {
            if (name != null && email != null)
            {

                ViewBag.Name = name;
                ViewBag.Email = email;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("blowoutrentals88@gmail.com", "byuis2018");
                MailMessage mail = new MailMessage();
                //Setting From , To and CC
                mail.From = new MailAddress("blowoutrentals88@gmail.com", "BlowOut Instrument Rentals Email");
                mail.To.Add(new MailAddress(email));
                mail.CC.Add(new MailAddress("blowoutrentals88@gmail.com"));
                mail.Subject = "Blowout Instrument Rentals Contacted Successfully";
                mail.Body = "Thank you, " + name + ", an email will be sent to " + email + ".";
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                smtpClient.Send(mail);
                ViewBag.Thanks = "Thank you, " + name + ", an email will be sent to " + email + ".";
                return View();
            }

            else
            {
                ViewBag.Thanks = "Thank you, " + name + ", an email will be sent to " + email + ".";
                return View();
            }
            
        }
    }
}
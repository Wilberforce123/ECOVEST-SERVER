using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ECOVEST_SERVER.Controllers
{
    public class SendEmailController : Controller
    {
        // GET: SendEmail
        [HttpPost]
        public ActionResult SendEmail(string reciever, string subject,string message){
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("wilberforce@leptonsmulticoncept.com.ng", "Wilberforce");
                    var recieverEmail = new MailAddress(reciever, "Reciever");
                    var Password = "Your Email Password here";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, Password)
                    };
                    using (var mess = new MailMessage(senderEmail, recieverEmail)
                    {
                        Subject = subject,
                        Body = body,
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            } catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();     
        }
           
        
    }
} 
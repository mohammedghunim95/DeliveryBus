using DeliveryBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DeliveryBus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactUs contactUs, string Message)
        {
            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("khaled.ws.ghanem@gmail.com", "KhaledGhanem123!");
            mail.From = new MailAddress(contactUs.Email);
            mail.To.Add(new MailAddress("khaled.ws.ghanem@gmail.com"));
            mail.Subject = contactUs.Subject;
            mail.IsBodyHtml = true;
            string body = "Name: " + contactUs.FullName + "<br>" +
                "Email: " + contactUs.Email + "<br>" +
                "Subject: " + contactUs.Subject + "<br>" +
                "Message: <b>" + Message + "</b>";
            mail.Body = Message;


            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);

            return RedirectToAction("List", "BusCompanies");
        }
    }
}
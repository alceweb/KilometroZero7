using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KilometroZero7.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace KilometroZero7.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Email1FormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("cesare@cr-consult.eu"));  // replace with valid value 
                message.From = new MailAddress("crconsult@outlook.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "crconsult@outlook.com",  // replace with valid value
                        Password = "1Bassaidai"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Principio()
        {
            ViewBag.Message = "Il principio di tutto";

            return View();
        }
        public ActionResult Comuni()
        {
            ViewBag.Message = "Pagina dei comuni";

            return View();
        }
        public ActionResult Cittadini()
        {
            ViewBag.Message = "Pagina dei cittadini";

            return View();
        }

        public ActionResult CommerciantiFree()
        {
            return View();
        }
        [Authorize]
        public ActionResult Commercianti()
        {
            ViewBag.Message = "Pagina dei commercianti";

            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Commercianti(ApplicationUser model)
        {
            return View();
        }

        public ActionResult Riservata()
        {
            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}
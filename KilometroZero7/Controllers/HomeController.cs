using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using KilometroZero7.Models;

namespace KilometroZero7.Controllers
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
        public ActionResult Principio()
        {
            return View();
        }
        public ActionResult Commercianti()
        {
            return View();
        }
        public ActionResult Comuni()
        {
            return View();
        }

        public async Task<ActionResult> MailCreditComune(MailCreditComune model)
        {
            if (ModelState.IsValid)
            {
                var body = "<h1>Kilometro Zero</h1><h2>Richiesta attivazione comune</h2><p><strong>Ricevuta da:</strong> {0} ({1})</p><p><strong>Indirizzo:</strong> {2}</p><p>{3} - {4} ({5})</p><p><strong>Telefono:</strong> {6}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("cesare@cr-consult.eu"));  // replace with valid value 
                message.Subject = "Richiesta attivazione comune";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.FromIndirizzo, model.FromCap, model.FromComune, model.FromPro, model.FromTel);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);

        }
        public ActionResult SentCreditComune()
        {
            return View();
        }
    }

}
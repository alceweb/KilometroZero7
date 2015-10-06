using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using KilometroZero7.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace KilometroZero7.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var comu = db.Users;
            ViewBag.Email = new SelectList(comu, "Id", "Email", String.Empty);
            var prodottis = db.Prodottis.OrderByDescending(p => p.prodotto_id).Where(p=>p.descrizione_prodotto.Contains("torta")).Include(p => p.nome_categoria);
            return View(prodottis);
        }
        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotti prodotti = db.Prodottis.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
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
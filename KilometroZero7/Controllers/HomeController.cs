﻿using KilometroZero7.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace KilometroZero7.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        private ApplicationDbContext db = new ApplicationDbContext();



        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            if (Request.Cookies["comune"] != null)
            {
                return RedirectToAction("Indexcom");
            }
            else
            {
                var comu = db.Comunis.OrderBy(c=>c.Comune);
                ViewBag.Comune = new SelectList(comu, "Comune", "Comune");
                return View();
            }
        }

        public ActionResult IndexCom()
        {
            var comu = db.Comunis;
            ViewData["comuneid"] = new SelectList(comu);
            if (Request.Cookies["comune"] != null)
            {
                ViewBag.comune = Request.Cookies["comune"].Value;
            }
            return View();
        }

        [HttpPost]
        public ActionResult IndexCom([Bind(Include = "prodotto_id,attivo,nome_prodotto,descrizione_prodotto,prezzo_prodotto,categoria_Id")] Prodotti prodotti)
        {
            ViewBag.Text1 = "gonna";
            var prodottis = db.Prodottis.
                OrderByDescending(p => p.prodotto_id).
                Where(p => p.attivo.Equals(true) &&
                p.descrizione_prodotto.Contains("gonna") &&
                p.nome_categoria.nome_categoria != "var").
                Include(p => p.nome_categoria).
                Include(u => u.utente);
            return View(prodottis);
        }

        public ActionResult ComuniIscritti()
        {
            var Comuni = db.Comunis.OrderBy(c => c.Comune);
            return View(Comuni);
        }

        public ActionResult cookie()
        {
            return View();
        }
        
        public ActionResult DelCookie()
        {
            return View();
        }
        public ActionResult CancellaCookie()
        {
            if (Request.Cookies["comune"] != null)
            {
                HttpCookie myCookie = new HttpCookie("comune");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                return View("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult TestCookie()
        {
                return View();
        }


        //GET: Home/test
        public ActionResult Test()
        {
            if (Request.Cookies["comune"] != null)
            {
                return RedirectToAction("Indexcom");
            }
            else
            {
                var comu = db.Comunis.OrderBy(c => c.Comune);
                ViewBag.Comune = new SelectList(comu, "Comune", "Comune", String.Empty);
                ViewData["comune"] = new SelectList(comu);
                return View(comu);
            }

        }
        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Title = "KilometroZero";
            var comu = db.Comunis;
            ViewData["Uti"] = db.Users;
            ViewBag.Comune = new SelectList(comu, "ComuneId", "Comune", String.Empty);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["Prodotti"] = db.Prodottis;
            Prodotti prodotti = db.Prodottis.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
        }

        //
        // GET: /Home/DetailsComm/5
        public async Task<ActionResult> DetailsComm(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            return PartialView(user);
        }

        //
        // GET: /Home/Cittadini
        public ActionResult Cittadini()
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
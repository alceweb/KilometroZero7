﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KilometroZero7.Models;
using Microsoft.AspNet.Identity;

namespace KilometroZero7.Controllers
{
    public class ProdottisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prodottis
        public ActionResult Index()
        {
            if(User.IsInRole("Commerciante"))
            {
            var ut = User.Identity.GetUserId();
            var prodottis = db.Prodottis.OrderByDescending(p=>p.prodotto_id).Where(p=>p.utente== ut).Include(p => p.nome_categoria);
             return View(prodottis);
           }
            else
            {
                if (User.IsInRole("Admin"))
                {
                    var prodottis = db.Prodottis.OrderByDescending(p => p.prodotto_id).Include(p => p.nome_categoria);
                    return View(prodottis);
                }
            }
                     return View();
       }

        // GET: Prodottis/Details/5
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

        // GET: Prodottis/Create
        public ActionResult Create()
        {
            var ut = User.Identity.GetUserId();
            ViewBag.categoria_Id = new SelectList(db.Categories, "categoria_id", "nome_categoria");
            ViewBag.utente = new SelectList(db.Users.Where(p=> p.Id == ut), "Id", "Email");
            return View();
        }

        // POST: Prodottis/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prodotto_id,utente,attivo,nome_prodotto,descrizione_prodotto,prezzo_prodotto,categoria_Id,UserId")] Prodotti prodotti)
        {
            var utente = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Prodottis.Add(prodotti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria_Id = new SelectList(db.Categories, "categoria_id", "nome_categoria", prodotti.categoria_Id);
            return View(prodotti);
        }

        // GET: Prodottis/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Prodottis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prodotto_id,utente,attivo,nome_prodotto,descrizione_prodotto,prezzo_prodotto,categoria_Id")] Prodotti prodotti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodotti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodotti);
        }

        // GET: Prodottis/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Prodottis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodotti prodotti = db.Prodottis.Find(id);
            db.Prodottis.Remove(prodotti);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

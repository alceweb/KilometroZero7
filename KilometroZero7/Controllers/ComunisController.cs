using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KilometroZero7.Models;

namespace KilometroZero7.Controllers
{
    public class ComunisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comunis
        public ActionResult Index()
        {
            ViewBag.ComuniCount = db.Comunis.Count();
            return View(db.Comunis.ToList());
        }

        // GET: Comunis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuni comuni = db.Comunis.Find(id);
            if (comuni == null)
            {
                return HttpNotFound();
            }
            return View(comuni);
        }

        // GET: Comunis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comunis/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComuneId,NomeRiferimento,TelRiferimento,Comune,Provincia,Regione")] Comuni comuni)
        {
            if (ModelState.IsValid)
            {
                db.Comunis.Add(comuni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comuni);
        }

        // GET: Comunis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuni comuni = db.Comunis.Find(id);
            if (comuni == null)
            {
                return HttpNotFound();
            }
            return View(comuni);
        }

        // POST: Comunis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComuneId,NomeRiferimento,TelRiferimento,Comune,Provincia,Regione")] Comuni comuni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comuni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comuni);
        }

        // GET: Comunis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuni comuni = db.Comunis.Find(id);
            if (comuni == null)
            {
                return HttpNotFound();
            }
            return View(comuni);
        }

        // POST: Comunis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comuni comuni = db.Comunis.Find(id);
            db.Comunis.Remove(comuni);
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

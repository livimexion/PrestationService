using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrestationService.Models;

namespace PrestationService.Controllers
{
    public class PrestationsController : Controller
    {
        private bdServiceContext db = new bdServiceContext();

        // GET: Prestations
        public ActionResult Index()
        {
            var prestations = db.prestations.Include(p => p.Client).Include(p => p.Facture).Include(p => p.Service);
            return View(prestations.ToList());
        }

        // GET: Prestations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestation prestation = db.prestations.Find(id);
            if (prestation == null)
            {
                return HttpNotFound();
            }
            return View(prestation);
        }

        // GET: Prestations/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.clients, "IdClient", "nomComplet");
            ViewBag.IdFacture = new SelectList(db.factures, "idFacture", "numero");
            ViewBag.idService = new SelectList(db.services, "idService", "libelle");
            return View();
        }

        // POST: Prestations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPrestation,adresse,IdClient,idService,IdFacture")] Prestation prestation)
        {
            if (ModelState.IsValid)
            {
                db.prestations.Add(prestation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.clients, "IdClient", "nomComplet", prestation.IdClient);
            ViewBag.IdFacture = new SelectList(db.factures, "idFacture", "numero", prestation.IdFacture);
            ViewBag.idService = new SelectList(db.services, "idService", "libelle", prestation.idService);
            return View(prestation);
        }

        // GET: Prestations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestation prestation = db.prestations.Find(id);
            if (prestation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.clients, "IdClient", "IdClient", prestation.IdClient);
            ViewBag.IdFacture = new SelectList(db.factures, "idFacture", "idFacture", prestation.IdFacture);
            ViewBag.idService = new SelectList(db.services, "idService", "libelle", prestation.idService);
            return View(prestation);
        }

        // POST: Prestations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPrestation,adresse,IdClient,idService,IdFacture")] Prestation prestation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.clients, "IdClient", "IdClient", prestation.IdClient);
            ViewBag.IdFacture = new SelectList(db.factures, "idFacture", "idFacture", prestation.IdFacture);
            ViewBag.idService = new SelectList(db.services, "idService", "libelle", prestation.idService);
            return View(prestation);
        }

        // GET: Prestations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestation prestation = db.prestations.Find(id);
            if (prestation == null)
            {
                return HttpNotFound();
            }
            return View(prestation);
        }

        // POST: Prestations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestation prestation = db.prestations.Find(id);
            db.prestations.Remove(prestation);
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

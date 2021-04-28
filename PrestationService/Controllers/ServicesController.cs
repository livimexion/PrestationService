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
    public class ServicesController : Controller
    {
        private bdServiceContext db = new bdServiceContext();

        // GET: Services
        public ActionResult Index()
        {
            var services = db.services.Include(s => s.Professionnel).Include(s => s.SousCategorie);
            return View(services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
           
            ViewBag.IdProfessionnel = new SelectList(db.professionnels, "IdProfessionnel", "nomComplet");
            ViewBag.idSouCat = new SelectList(db.SousCategories, "idSouCat", "libSouCat");
            return View();
        }

        // POST: Services/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idService,libelle,description,prix,nbHeure,IdProfessionnel,idSouCat")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.IdProfessionnel = new SelectList(db.professionnels, "IdProfessionnel", "nomComplet", service.IdProfessionnel);
            ViewBag.idSouCat = new SelectList(db.SousCategories, "idSouCat", "libSouCat", service.idSouCat);
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdProfessionnel = new SelectList(db.professionnels, "IdProfessionnel", "nomComplet", service.IdProfessionnel);
            ViewBag.idSouCat = new SelectList(db.SousCategories, "idSouCat", "libSouCat", service.idSouCat);
            return View(service);
        }

        // POST: Services/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idService,libelle,description,prix,nbHeure,IdProfessionnel,idSouCat")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            ViewBag.IdProfessionnel = new SelectList(db.professionnels, "IdProfessionnel", "nomComplet", service.IdProfessionnel);
            ViewBag.idSouCat = new SelectList(db.SousCategories, "idSouCat", "libSouCat", service.idSouCat);
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.services.Find(id);
            db.services.Remove(service);
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

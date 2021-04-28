using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PrestationService.Models;

namespace PrestationService.Controllers
{
    public class ProfessionnelsController : Controller
    {
        private bdServiceContext db = new bdServiceContext();

        // GET: Professionnels
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LastSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";

            page = page.HasValue ? page : 1;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var professionnels = from s in db.professionnels
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                professionnels = professionnels.Where(s => s.nom.Contains(searchString)
                                       || s.prenom.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    professionnels = professionnels.OrderByDescending(s => s.nom);
                    break;
                case "last_name_desc":
                    professionnels = professionnels.OrderByDescending(s => s.prenom);
                    break;
                default:  // Name ascending 
                    professionnels = professionnels.OrderBy(s => s.nom);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(db.professionnels.OrderBy(i => i.nom).ToPagedList(pageNumber, pageSize));

        }

        // GET: Professionnels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professionnel professionnel = db.professionnels.Find(id);
            if (professionnel == null)
            {
                return HttpNotFound();
            }
            return View(professionnel);
        }

        // GET: Professionnels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professionnels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfessionnel,nom,prenom,naissance,adresse,mail,tel,identification,diplome,specialite,ninea,registre,statut,experience,photo")] Professionnel professionnel)
        {
            if (ModelState.IsValid)
            {
                db.professionnels.Add(professionnel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professionnel);
        }

        // GET: Professionnels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professionnel professionnel = db.professionnels.Find(id);
            if (professionnel == null)
            {
                return HttpNotFound();
            }
            return View(professionnel);
        }

        // POST: Professionnels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfessionnel,nom,prenom,naissance,adresse,mail,tel,identification,diplome,specialite,ninea,registre,statut,experience,photo")] Professionnel professionnel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionnel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professionnel);
        }

        // GET: Professionnels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professionnel professionnel = db.professionnels.Find(id);
            if (professionnel == null)
            {
                return HttpNotFound();
            }
            return View(professionnel);
        }

        // POST: Professionnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professionnel professionnel = db.professionnels.Find(id);
            db.professionnels.Remove(professionnel);
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

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
    public class UserConnectsController : Controller
    {
        private bdServiceContext db = new bdServiceContext();

        // GET: UserConnects
        public ActionResult Index()
        {
            var userConnects = db.userConnects.Include(u => u.ChatRoom).Include(u => u.Personne);
            return View(userConnects.ToList());
        }

        // GET: UserConnects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserConnect userConnect = db.userConnects.Find(id);
            if (userConnect == null)
            {
                return HttpNotFound();
            }
            return View(userConnect);
        }

        // GET: UserConnects/Create
        public ActionResult Create()
        {
            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom");
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom");
            return View();
        }

        // POST: UserConnects/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idConnect,idPerson,idRoom")] UserConnect userConnect)
        {
            if (ModelState.IsValid)
            {
                db.userConnects.Add(userConnect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom", userConnect.idRoom);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", userConnect.idPerson);
            return View(userConnect);
        }

        // GET: UserConnects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserConnect userConnect = db.userConnects.Find(id);
            if (userConnect == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom", userConnect.idRoom);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", userConnect.idPerson);
            return View(userConnect);
        }

        // POST: UserConnects/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConnect,idPerson,idRoom")] UserConnect userConnect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userConnect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom", userConnect.idRoom);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", userConnect.idPerson);
            return View(userConnect);
        }

        // GET: UserConnects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserConnect userConnect = db.userConnects.Find(id);
            if (userConnect == null)
            {
                return HttpNotFound();
            }
            return View(userConnect);
        }

        // POST: UserConnects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserConnect userConnect = db.userConnects.Find(id);
            db.userConnects.Remove(userConnect);
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

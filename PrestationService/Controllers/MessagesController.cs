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
    public class MessagesController : Controller
    {
        private bdServiceContext db = new bdServiceContext();

        // GET: Messages
        public ActionResult Index()
        {
            var messages = db.messages.Include(m => m.ChatRoom).Include(m => m.Personne).Include(m => m.PersonneTo);
            return View(messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom");
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom");
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom");
            return View();
        }

        // POST: Messages/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMsg,texte,serviceType,idPerson,idPersonTo,idRoom")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom", message.idRoom);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", message.idPerson);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", message.idPerson);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom", message.idRoom);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", message.idPerson);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", message.idPerson);
            return View(message);
        }

        // POST: Messages/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMsg,texte,serviceType,idPerson,idPersonTo,idRoom")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRoom = new SelectList(db.chatRooms, "idRoom", "libelleRoom", message.idRoom);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", message.idPerson);
            ViewBag.idPerson = new SelectList(db.personnes, "idPerson", "nom", message.idPerson);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.messages.Find(id);
            db.messages.Remove(message);
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

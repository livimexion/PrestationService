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
    public class ChatRoomsController : Controller
    {
        private bdServiceContext db = new bdServiceContext();

        // GET: ChatRooms
        public ActionResult Index()
        {
            return View(db.chatRooms.ToList());
        }

        // GET: ChatRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoom chatRoom = db.chatRooms.Find(id);
            if (chatRoom == null)
            {
                return HttpNotFound();
            }
            return View(chatRoom);
        }

        // GET: ChatRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatRooms/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRoom,libelleRoom")] ChatRoom chatRoom)
        {
            if (ModelState.IsValid)
            {
                db.chatRooms.Add(chatRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatRoom);
        }

        // GET: ChatRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoom chatRoom = db.chatRooms.Find(id);
            if (chatRoom == null)
            {
                return HttpNotFound();
            }
            return View(chatRoom);
        }

        // POST: ChatRooms/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRoom,libelleRoom")] ChatRoom chatRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatRoom);
        }

        // GET: ChatRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoom chatRoom = db.chatRooms.Find(id);
            if (chatRoom == null)
            {
                return HttpNotFound();
            }
            return View(chatRoom);
        }

        // POST: ChatRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatRoom chatRoom = db.chatRooms.Find(id);
            db.chatRooms.Remove(chatRoom);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PISprojekat.Models;

namespace PISprojekat.Controllers
{
    public class Messages1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages1
        public ActionResult Index()
        {
            var message = db.Message.Include(m => m.Incident).Include(m => m.MessageAuthor).Include(m => m.MessageStatus);
            return View(message.ToList());
        }

        // GET: Messages1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            message.StatusId = 2;
            db.SaveChanges();
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages1/Create
        public ActionResult Create()
        {
            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title");
            ViewBag.AuthorId = new SelectList(db.MessageAuthor, "ID", "Author");
            ViewBag.StatusId = new SelectList(db.MessageStatus, "ID", "Status");
            return View();
        }

        // POST: Messages1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MessageText")] Message message)
        {
            if (ModelState.IsValid)
            {
                MessageAuthor messageAuthor = db.MessageAuthor.FirstOrDefault(ma => ma.ID == 1);
                MessageStatus messageStatus = db.MessageStatus.FirstOrDefault(ms => ms.ID == 1);
                DateTime createdAt = DateTime.Now;
                message.MessageAuthor = messageAuthor;
                message.MessageStatus = messageStatus;
                message.CreateDate = createdAt;
                db.Message.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title", message.IncidentId);
            ViewBag.AuthorId = new SelectList(db.MessageAuthor, "ID", "Author", message.AuthorId);
            ViewBag.StatusId = new SelectList(db.MessageStatus, "ID", "Status", message.StatusId);
            return View(message);
        }

        // GET: Messages1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title", message.IncidentId);
            ViewBag.AuthorId = new SelectList(db.MessageAuthor, "ID", "Author", message.AuthorId);
            ViewBag.StatusId = new SelectList(db.MessageStatus, "ID", "Status", message.StatusId);
            return View(message);
        }

        // POST: Messages1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MessageText,CreateDate,IncidentId,AuthorId,StatusId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title", message.IncidentId);
            ViewBag.AuthorId = new SelectList(db.MessageAuthor, "ID", "Author", message.AuthorId);
            ViewBag.StatusId = new SelectList(db.MessageStatus, "ID", "Status", message.StatusId);
            return View(message);
        }

        // GET: Messages1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Message.Find(id);
            db.Message.Remove(message);
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

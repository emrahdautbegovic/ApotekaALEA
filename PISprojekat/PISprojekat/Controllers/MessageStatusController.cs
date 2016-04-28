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
    public class MessageStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageStatus
        public ActionResult Index()
        {
            return View(db.MessageStatus.ToList());
        }

        // GET: MessageStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageStatus messageStatus = db.MessageStatus.Find(id);
            if (messageStatus == null)
            {
                return HttpNotFound();
            }
            return View(messageStatus);
        }

        // GET: MessageStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Status")] MessageStatus messageStatus)
        {
            if (ModelState.IsValid)
            {
                db.MessageStatus.Add(messageStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageStatus);
        }

        // GET: MessageStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageStatus messageStatus = db.MessageStatus.Find(id);
            if (messageStatus == null)
            {
                return HttpNotFound();
            }
            return View(messageStatus);
        }

        // POST: MessageStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status")] MessageStatus messageStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageStatus);
        }

        // GET: MessageStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageStatus messageStatus = db.MessageStatus.Find(id);
            if (messageStatus == null)
            {
                return HttpNotFound();
            }
            return View(messageStatus);
        }

        // POST: MessageStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageStatus messageStatus = db.MessageStatus.Find(id);
            db.MessageStatus.Remove(messageStatus);
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

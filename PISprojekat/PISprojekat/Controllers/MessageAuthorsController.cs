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
    public class MessageAuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageAuthors
        public ActionResult Index()
        {
            return View(db.MessageAuthor.ToList());
        }

        // GET: MessageAuthors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageAuthor messageAuthor = db.MessageAuthor.Find(id);
            if (messageAuthor == null)
            {
                return HttpNotFound();
            }
            return View(messageAuthor);
        }

        // GET: MessageAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageAuthors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Author")] MessageAuthor messageAuthor)
        {
            if (ModelState.IsValid)
            {
                db.MessageAuthor.Add(messageAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageAuthor);
        }

        // GET: MessageAuthors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageAuthor messageAuthor = db.MessageAuthor.Find(id);
            if (messageAuthor == null)
            {
                return HttpNotFound();
            }
            return View(messageAuthor);
        }

        // POST: MessageAuthors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Author")] MessageAuthor messageAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageAuthor);
        }

        // GET: MessageAuthors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageAuthor messageAuthor = db.MessageAuthor.Find(id);
            if (messageAuthor == null)
            {
                return HttpNotFound();
            }
            return View(messageAuthor);
        }

        // POST: MessageAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageAuthor messageAuthor = db.MessageAuthor.Find(id);
            db.MessageAuthor.Remove(messageAuthor);
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

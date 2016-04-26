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
    public class IncidentAdministratorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IncidentAdministrators
        public ActionResult Index()
        {
            var incidentAdministrator = db.IncidentAdministrator.Include(i => i.Incident).Include(i => i.IncidentCategory);
            return View(incidentAdministrator.ToList());
        }

        // GET: IncidentAdministrators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentAdministrator incidentAdministrator = db.IncidentAdministrator.Find(id);
            if (incidentAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(incidentAdministrator);
        }

        // GET: IncidentAdministrators/Create
        public ActionResult Create()
        {
            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title");
            ViewBag.IncidentCategoryId = new SelectList(db.IncidentCategory, "ID", "Category");
            return View();
        }

        // POST: IncidentAdministrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IncidentId,IncidentCategoryId")] IncidentAdministrator incidentAdministrator)
        {
            if (ModelState.IsValid)
            {
                db.IncidentAdministrator.Add(incidentAdministrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title", incidentAdministrator.IncidentId);
            ViewBag.IncidentCategoryId = new SelectList(db.IncidentCategory, "ID", "Category", incidentAdministrator.IncidentCategoryId);
            return View(incidentAdministrator);
        }

        // GET: IncidentAdministrators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentAdministrator incidentAdministrator = db.IncidentAdministrator.Find(id);
            if (incidentAdministrator == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title", incidentAdministrator.IncidentId);
            ViewBag.IncidentCategoryId = new SelectList(db.IncidentCategory, "ID", "Category", incidentAdministrator.IncidentCategoryId);
            return View(incidentAdministrator);
        }

        // POST: IncidentAdministrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IncidentId,IncidentCategoryId")] IncidentAdministrator incidentAdministrator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidentAdministrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IncidentId = new SelectList(db.Incident, "ID", "Title", incidentAdministrator.IncidentId);
            ViewBag.IncidentCategoryId = new SelectList(db.IncidentCategory, "ID", "Category", incidentAdministrator.IncidentCategoryId);
            return View(incidentAdministrator);
        }

        // GET: IncidentAdministrators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentAdministrator incidentAdministrator = db.IncidentAdministrator.Find(id);
            if (incidentAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(incidentAdministrator);
        }

        // POST: IncidentAdministrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncidentAdministrator incidentAdministrator = db.IncidentAdministrator.Find(id);
            db.IncidentAdministrator.Remove(incidentAdministrator);
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

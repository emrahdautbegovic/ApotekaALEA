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
    public class IncidentStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IncidentStatus
        public ActionResult Index()
        {
            return View(db.IncidentStatus.ToList());
        }

        // GET: IncidentStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentStatus incidentStatus = db.IncidentStatus.Find(id);
            if (incidentStatus == null)
            {
                return HttpNotFound();
            }
            return View(incidentStatus);
        }

        // GET: IncidentStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncidentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Status")] IncidentStatus incidentStatus)
        {
            if (ModelState.IsValid)
            {
                db.IncidentStatus.Add(incidentStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incidentStatus);
        }

        // GET: IncidentStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentStatus incidentStatus = db.IncidentStatus.Find(id);
            if (incidentStatus == null)
            {
                return HttpNotFound();
            }
            return View(incidentStatus);
        }

        // POST: IncidentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status")] IncidentStatus incidentStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidentStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incidentStatus);
        }

        // GET: IncidentStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentStatus incidentStatus = db.IncidentStatus.Find(id);
            if (incidentStatus == null)
            {
                return HttpNotFound();
            }
            return View(incidentStatus);
        }

        // POST: IncidentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncidentStatus incidentStatus = db.IncidentStatus.Find(id);
            db.IncidentStatus.Remove(incidentStatus);
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

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
    public class IncidentManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IncidentManager
        public ActionResult Index()
        {
            var incident = db.Incident.Include(i => i.IncidentStatus).Include(i => i.Priority);
            return View(incident.ToList());
        }

        // GET: IncidentManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: IncidentManager/Create
        public ActionResult Create()
        {
            ViewBag.IncidentStatusId = new SelectList(db.IncidentStatus, "ID", "Status");
            ViewBag.PriorityId = new SelectList(db.Priority, "ID", "PriorityType");
            return View();
        }

        // POST: IncidentManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Describe,CreateTime,PriorityId,IncidentStatusId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Incident.Add(incident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IncidentStatusId = new SelectList(db.IncidentStatus, "ID", "Status", incident.IncidentStatusId);
            ViewBag.PriorityId = new SelectList(db.Priority, "ID", "PriorityType", incident.PriorityId);
            return View(incident);
        }

        // GET: IncidentManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncidentStatusId = new SelectList(db.IncidentStatus, "ID", "Status", incident.IncidentStatusId);
            ViewBag.PriorityId = new SelectList(db.Priority, "ID", "PriorityType", incident.PriorityId);
            return View(incident);
        }

        // POST: IncidentManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Describe,CreateTime,PriorityId,IncidentStatusId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IncidentStatusId = new SelectList(db.IncidentStatus, "ID", "Status", incident.IncidentStatusId);
            ViewBag.PriorityId = new SelectList(db.Priority, "ID", "PriorityType", incident.PriorityId);
            return View(incident);
        }

        // GET: IncidentManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // POST: IncidentManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incident incident = db.Incident.Find(id);
            db.Incident.Remove(incident);
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

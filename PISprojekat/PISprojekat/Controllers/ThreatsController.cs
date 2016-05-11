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
    public class ThreatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Threats
        public ActionResult Index()
        {
            var threat = db.Threat.Include(t => t.ProjectPlan);
            return View(threat.ToList());
        }

        // GET: Threats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Threat threat = db.Threat.Find(id);
            if (threat == null)
            {
                return HttpNotFound();
            }
            return View(threat);
        }

        // GET: Threats/Create
        public ActionResult Create()
        {
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title");
            return View();
        }

        // POST: Threats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Describe,ProjectPlanId")] Threat threat)
        {
            if (ModelState.IsValid)
            {
                db.Threat.Add(threat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", threat.ProjectPlanId);
            return View(threat);
        }

        // GET: Threats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Threat threat = db.Threat.Find(id);
            if (threat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", threat.ProjectPlanId);
            return View(threat);
        }

        // POST: Threats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Describe,ProjectPlanId")] Threat threat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(threat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", threat.ProjectPlanId);
            return View(threat);
        }

        // GET: Threats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Threat threat = db.Threat.Find(id);
            if (threat == null)
            {
                return HttpNotFound();
            }
            return View(threat);
        }

        // POST: Threats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Threat threat = db.Threat.Find(id);
            db.Threat.Remove(threat);
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

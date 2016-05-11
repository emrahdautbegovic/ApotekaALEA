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
    public class RisksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Risks
        public ActionResult Index()
        {
            var risk = db.Risk.Include(r => r.ProjectPlan).Include(r => r.Threat).Include(r => r.Vulnerability);
            return View(risk.ToList());
        }

        // GET: Risks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risk risk = db.Risk.Find(id);
            if (risk == null)
            {
                return HttpNotFound();
            }
            return View(risk);
        }

        // GET: Risks/Create
        public ActionResult Create()
        {
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title");
            ViewBag.ThreatId = new SelectList(db.Threat, "ID", "Title");
            ViewBag.VulnerabilityId = new SelectList(db.Vulnerability, "ID", "Title");
            return View();
        }

        // POST: Risks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,RiskLevel,ProjectPlanId,ThreatId,VulnerabilityId")] Risk risk)
        {
            if (ModelState.IsValid)
            {
                db.Risk.Add(risk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", risk.ProjectPlanId);
            ViewBag.ThreatId = new SelectList(db.Threat, "ID", "Title", risk.ThreatId);
            ViewBag.VulnerabilityId = new SelectList(db.Vulnerability, "ID", "Title", risk.VulnerabilityId);
            return View(risk);
        }

        // GET: Risks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risk risk = db.Risk.Find(id);
            if (risk == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", risk.ProjectPlanId);
            ViewBag.ThreatId = new SelectList(db.Threat, "ID", "Title", risk.ThreatId);
            ViewBag.VulnerabilityId = new SelectList(db.Vulnerability, "ID", "Title", risk.VulnerabilityId);
            return View(risk);
        }

        // POST: Risks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,RiskLevel,ProjectPlanId,ThreatId,VulnerabilityId")] Risk risk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(risk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", risk.ProjectPlanId);
            ViewBag.ThreatId = new SelectList(db.Threat, "ID", "Title", risk.ThreatId);
            ViewBag.VulnerabilityId = new SelectList(db.Vulnerability, "ID", "Title", risk.VulnerabilityId);
            return View(risk);
        }

        // GET: Risks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risk risk = db.Risk.Find(id);
            if (risk == null)
            {
                return HttpNotFound();
            }
            return View(risk);
        }

        // POST: Risks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Risk risk = db.Risk.Find(id);
            db.Risk.Remove(risk);
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

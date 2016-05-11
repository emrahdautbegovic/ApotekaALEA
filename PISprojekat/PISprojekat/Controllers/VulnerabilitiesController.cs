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
    public class VulnerabilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vulnerabilities
        public ActionResult Index()
        {
            var vulnerability = db.Vulnerability.Include(v => v.ProjectPlan);
            return View(vulnerability.ToList());
        }

        // GET: Vulnerabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vulnerability vulnerability = db.Vulnerability.Find(id);
            if (vulnerability == null)
            {
                return HttpNotFound();
            }
            return View(vulnerability);
        }

        // GET: Vulnerabilities/Create
        public ActionResult Create()
        {
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title");
            return View();
        }

        // POST: Vulnerabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Describe,ProjectPlanId")] Vulnerability vulnerability)
        {
            if (ModelState.IsValid)
            {
                db.Vulnerability.Add(vulnerability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", vulnerability.ProjectPlanId);
            return View(vulnerability);
        }

        // GET: Vulnerabilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vulnerability vulnerability = db.Vulnerability.Find(id);
            if (vulnerability == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", vulnerability.ProjectPlanId);
            return View(vulnerability);
        }

        // POST: Vulnerabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Describe,ProjectPlanId")] Vulnerability vulnerability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vulnerability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectPlanId = new SelectList(db.ProjectPlan, "ID", "Title", vulnerability.ProjectPlanId);
            return View(vulnerability);
        }

        // GET: Vulnerabilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vulnerability vulnerability = db.Vulnerability.Find(id);
            if (vulnerability == null)
            {
                return HttpNotFound();
            }
            return View(vulnerability);
        }

        // POST: Vulnerabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vulnerability vulnerability = db.Vulnerability.Find(id);
            db.Vulnerability.Remove(vulnerability);
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

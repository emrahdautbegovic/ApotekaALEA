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
    public class ProjectPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProjectPlans
        public ActionResult Index()
        {
            return View(db.ProjectPlan.ToList());
        }

        // GET: ProjectPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPlan projectPlan = db.ProjectPlan.Find(id);
            if (projectPlan == null)
            {
                return HttpNotFound();
            }
            return View(projectPlan);
        }

        // GET: ProjectPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Describe,PlanDescription")] ProjectPlan projectPlan)
        {
            if (ModelState.IsValid)
            {
                db.ProjectPlan.Add(projectPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectPlan);
        }

        // GET: ProjectPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPlan projectPlan = db.ProjectPlan.Find(id);
            if (projectPlan == null)
            {
                return HttpNotFound();
            }
            return View(projectPlan);
        }

        // POST: ProjectPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Describe,PlanDescription")] ProjectPlan projectPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectPlan);
        }

        // GET: ProjectPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPlan projectPlan = db.ProjectPlan.Find(id);
            if (projectPlan == null)
            {
                return HttpNotFound();
            }
            return View(projectPlan);
        }

        // POST: ProjectPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectPlan projectPlan = db.ProjectPlan.Find(id);
            db.ProjectPlan.Remove(projectPlan);
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

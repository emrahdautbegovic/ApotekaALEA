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
    public class IncidentCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IncidentCategories
        public ActionResult Index()
        {
            return View(db.IncidentCategory.ToList());
        }

        // GET: IncidentCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentCategory incidentCategory = db.IncidentCategory.Find(id);
            if (incidentCategory == null)
            {
                return HttpNotFound();
            }
            return View(incidentCategory);
        }

        // GET: IncidentCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncidentCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category")] IncidentCategory incidentCategory)
        {
            if (ModelState.IsValid)
            {
                db.IncidentCategory.Add(incidentCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incidentCategory);
        }

        // GET: IncidentCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentCategory incidentCategory = db.IncidentCategory.Find(id);
            if (incidentCategory == null)
            {
                return HttpNotFound();
            }
            return View(incidentCategory);
        }

        // POST: IncidentCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category")] IncidentCategory incidentCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidentCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incidentCategory);
        }

        // GET: IncidentCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidentCategory incidentCategory = db.IncidentCategory.Find(id);
            if (incidentCategory == null)
            {
                return HttpNotFound();
            }
            return View(incidentCategory);
        }

        // POST: IncidentCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncidentCategory incidentCategory = db.IncidentCategory.Find(id);
            db.IncidentCategory.Remove(incidentCategory);
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

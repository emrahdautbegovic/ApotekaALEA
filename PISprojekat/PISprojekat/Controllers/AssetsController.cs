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
    public class AssetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Assets
        public ActionResult Index()
        {
            var asset = db.Asset.Include(a => a.AssetType).Include(a => a.Category).Include(a => a.Department).Include(a => a.Status);
            return View(asset.ToList());
        }

        // GET: Assets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeId = new SelectList(db.AssetType, "ID", "Name");
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name");
            ViewBag.DepartmentId = new SelectList(db.Department, "ID", "Name");
            ViewBag.StatusId = new SelectList(db.Status, "ID", "Name");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Model,Vendor,SerialNumber,Price,PurchaseDate,NextMaintenanceDate,DepreciationValue,Owner,Parrent,AssetTypeId,CategoryId,StatusId,DepartmentId")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                
                db.Asset.Add(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetTypeId = new SelectList(db.AssetType, "ID", "Name", asset.AssetTypeId);
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name", asset.CategoryId);
            ViewBag.DepartmentId = new SelectList(db.Department, "ID", "Name", asset.DepartmentId);
            ViewBag.StatusId = new SelectList(db.Status, "ID", "Name", asset.StatusId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetTypeId = new SelectList(db.AssetType, "ID", "Name", asset.AssetTypeId);
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name", asset.CategoryId);
            ViewBag.DepartmentId = new SelectList(db.Department, "ID", "Name", asset.DepartmentId);
            ViewBag.StatusId = new SelectList(db.Status, "ID", "Name", asset.StatusId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Model,Vendor,SerialNumber,Price,PurchaseDate,NextMaintenanceDate,DepreciationValue,Owner,Parrent,AssetTypeId,CategoryId,StatusId,DepartmentId")] Asset asset)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                List<Asset> assets = (from c in db.Asset where c.Parrent == asset.Name select c).ToList();
                foreach (Asset a in assets)
                {
                    a.StatusId = asset.StatusId;
                    db.Entry(a).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetTypeId = new SelectList(db.AssetType, "ID", "Name", asset.AssetTypeId);
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name", asset.CategoryId);
            ViewBag.DepartmentId = new SelectList(db.Department, "ID", "Name", asset.DepartmentId);
            ViewBag.StatusId = new SelectList(db.Status, "ID", "Name", asset.StatusId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asset asset = db.Asset.Find(id);
            db.Asset.Remove(asset);
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

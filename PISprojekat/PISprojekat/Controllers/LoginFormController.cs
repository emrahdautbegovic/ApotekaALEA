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
    public class LoginFormController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoginForm
        public ActionResult Index()
        {
            var employee = db.Employee.Include(e => e.EmployeeType);
            return View(employee.ToList());
        }

        // GET: LoginForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: LoginForm/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeType, "ID", "Type");
            return View();
        }

        // POST: LoginForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Lastname,BirthDate,Email,Username,Password,EmployeeTypeId")] Employee employee)
        {
              Employee emp = db.Employee.SingleOrDefault(e => e.Username == employee.Username && e.Password == employee.Password);
                if(emp != null)
                {
                    if(emp.EmployeeTypeId == 1)
                    {
                        return RedirectToAction("Index","Assets");
                    }
                    else if(emp.EmployeeTypeId == 2)
                    {
                        return RedirectToAction("Index", "IncidentManager");
                    }
                    else if(emp.EmployeeTypeId == 3)
                    {
                        return RedirectToAction("About","Home");
                    }
                    else if(emp.EmployeeTypeId == 4)
                    {
                        return RedirectToAction("Index","Incidents");
                    }
                    else if(emp.EmployeeTypeId == 5)
                    {
                        return RedirectToAction("Index", "ProjectPlans");
                    }
            }
                else
                return RedirectToAction("Contact", "Home");


            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeType, "ID", "Type", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: LoginForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeType, "ID", "Type", employee.EmployeeTypeId);
            return View(employee);
        }

        // POST: LoginForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Lastname,BirthDate,Email,Username,Password,EmployeeTypeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeType, "ID", "Type", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: LoginForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: LoginForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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

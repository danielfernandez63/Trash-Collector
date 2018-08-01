using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trash_Collector.Models;

namespace Trash_Collector.Controllers
{
    public class EmployeesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Employee"))
            {
                var user = User.Identity.GetUserId();
                //ViewBag.Name = user.Name;

                ViewBag.displaymenu = "Yes";

                var loggedInUser = db.Employees.Where(e => e.ApplicationUserId == user).Single();
                var localCustomers = db.Customers.Include(c =>  c.ZipCode).Include(b=> b.PickUpDay).Where(d => d.ZipCodeId == loggedInUser.ZipCodeId);

                return View(localCustomers.ToList());
            }
            else
            {
                ViewBag.Name = "Not Logged In";
                return RedirectToAction("InvalidRedirect", "Home");
            }
            
        }
        //get
        public ActionResult DailyPickUps(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Employee"))
            {
                var user = User.Identity.GetUserId();
                

                ViewBag.displaymenu = "Yes";

                var loggedInUser = db.Employees.Where(e => e.ApplicationUserId == user).Single();
                var localCustomers = db.Customers.Include(c => c.ZipCode).Include(b => b.PickUpDay).Where(d => d.PickUpDay.PickUpId == loggedInUser.PickUpDay && d.ZipCodeId == loggedInUser.ZipCodeId);
                return View(localCustomers.ToList());
            }
            else
            {
                ViewBag.Name = "Not Logged In";
                return RedirectToAction("InvalidRedirect", "Home");
            }

        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            var user = User.Identity.GetUserId();
            
    
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeArea");
            return View();
                  
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,LastName,ZipCodeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeId", employee.ZipCodeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = User.Identity.GetUserId();
            var loggedInEmployee = db.Employees.Where(e => e.ApplicationUserId == user).Single();

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = loggedInEmployee;
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PickUpId = new SelectList(db.PickUpDays, "PickUpId", "PickUpWeekday",employee.PickUpDay);
            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeId", employee.ZipCodeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                var loggedInEmployee = db.Employees.Where(e => e.ApplicationUserId == user).Single();

                loggedInEmployee.PickUpDay = employee.PickUpDay;
                employee.ApplicationUserId = loggedInEmployee.ApplicationUserId;

                db.Entry(loggedInEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DailyPickUps");
            }
            ViewBag.PickUpId = new SelectList(db.PickUpDays, "PickUpId", "PickUpWeekday");
            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeId", employee.ZipCodeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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

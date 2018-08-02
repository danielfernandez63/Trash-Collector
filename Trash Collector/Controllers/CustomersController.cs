﻿using Microsoft.AspNet.Identity;
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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Customer"))
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displaymenu = "Yes";
                return View();
        
            }
            else
            {
                ViewBag.Name = "Not Logged In";
                return RedirectToAction("InvalidRedirect", "Home");
            }
          
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            var user = User.Identity.GetUserId();

            var loggedInUser = db.Customers.Include(g=> g.ZipCode).Include(v=> v.PickUpDay).Where(c => c.ApplicationUserId == user).Single();

            if (loggedInUser == null)
            {
                return HttpNotFound();
            }
            return View(loggedInUser);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeArea");
            ViewBag.PickUpId = new SelectList(db.PickUpDays, "PickUpId", "PickUpWeekday");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,StreetAddress,Balance,ZipCodeId,PickUpId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationUserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeId", customer.ZipCodeId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeArea", customer.ZipCodeId);
            ViewBag.PickUpId = new SelectList(db.PickUpDays, "PickUpId", "PickUpWeekday");
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,StreetAddress,ZipCodeId,PickUpId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                var loggedInCustomer = db.Customers.Where(e => e.ApplicationUserId == user).Single();

                loggedInCustomer.FirstName = customer.FirstName;
                loggedInCustomer.LastName = customer.LastName;
                loggedInCustomer.StreetAddress = customer.StreetAddress;
                loggedInCustomer.ZipCodeId = customer.ZipCodeId;
                loggedInCustomer.PickUpId = customer.PickUpId;
    
                db.Entry(loggedInCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeArea");
            ViewBag.PickUpId = new SelectList(db.PickUpDays, "PickUpId", "PickUpWeekday");
            return View(customer);
        }
        //// GET: Customers/Edit/5
        //public ActionResult EditCheckOff(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeArea", customer.ZipCodeId);
        //    ViewBag.PickUpId = new SelectList(db.PickUpDays, "PickUpId", "PickUpWeekday");
        //    return View(customer);
        //}

        //// POST: Customers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditCheckOff([Bind(Include = "CompletePickUp")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = User.Identity.GetUserId();
        //        var loggedInCustomer = db.Customers.Where(e => e.ApplicationUserId == user).Single();

        //        loggedInCustomer.CompletePickUp = customer.CompletePickUp;
               

        //        db.Entry(loggedInCustomer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Details");
        //    }
        //    ViewBag.ZipCodeId = new SelectList(db.ZipCodes, "ZipCodeId", "ZipCodeArea");
        //    ViewBag.PickUpId = new SelectList(db.PickUpDays, "PickUpId", "PickUpWeekday");
        //    return View(customer);
        //}

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CleaningSupplies.Database.Models;

namespace Cleaningsupplies.Web.Controllers
{
    public class MastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Masters
        public ActionResult Index()
        {
            return View(db.Master.ToList());
        }

        // GET: Masters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // GET: Masters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,QuantityInStock,IsDeleted,CreatedByDateTime,ModifiedByDatetime")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Master.Add(master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(master);
        }

        // GET: Masters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: Masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,QuantityInStock,IsDeleted,CreatedByDateTime,ModifiedByDatetime")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(master);
        }

        // GET: Masters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: Masters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Master master = db.Master.Find(id);
            db.Master.Remove(master);
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

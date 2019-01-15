using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;

namespace Inventory.Controllers
{
    public class LocationController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Location
        public ActionResult Index()
        {
            return View(db.Tbl_Location.ToList());
        }

        // GET: Location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Location tbl_Location = db.Tbl_Location.Find(id);
            if (tbl_Location == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Location);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lo_ID,Lo_Name")] Tbl_Location tbl_Location)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Location.Add(tbl_Location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Location);
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Location tbl_Location = db.Tbl_Location.Find(id);
            if (tbl_Location == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Location);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lo_ID,Lo_Name")] Tbl_Location tbl_Location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Location);
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Location tbl_Location = db.Tbl_Location.Find(id);
            if (tbl_Location == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Location);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Location tbl_Location = db.Tbl_Location.Find(id);
            db.Tbl_Location.Remove(tbl_Location);
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

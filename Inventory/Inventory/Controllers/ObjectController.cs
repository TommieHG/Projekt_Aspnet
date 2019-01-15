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
    [Authorize(Roles = "Admin, User")]
    public class ObjectController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Object
        public ActionResult Index()
        {
            var tbl_Object = db.Tbl_Object.Include(t => t.Tbl_Category);
            return View(tbl_Object.ToList());
        }

        // GET: Object/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Object tbl_Object = db.Tbl_Object.Find(id);
            if (tbl_Object == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Object);
        }

        // GET: Object/Create
        public ActionResult Create()
        {
            ViewBag.FK_Ca_ID = new SelectList(db.Tbl_Category, "Ca_ID", "Ca_Name");
            return View();
        }

        // POST: Object/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ob_ID,FK_Ca_ID,Ob_Name,Ob_Purchase_Date,Ob_Est_Value,Ob_Description")] Tbl_Object tbl_Object)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Object.Add(tbl_Object);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Ca_ID = new SelectList(db.Tbl_Category, "Ca_ID", "Ca_Name", tbl_Object.FK_Ca_ID);
            return View(tbl_Object);
        }

        // GET: Object/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Object tbl_Object = db.Tbl_Object.Find(id);
            if (tbl_Object == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Ca_ID = new SelectList(db.Tbl_Category, "Ca_ID", "Ca_Name", tbl_Object.FK_Ca_ID);
            return View(tbl_Object);
        }

        // POST: Object/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ob_ID,FK_Ca_ID,Ob_Name,Ob_Purchase_Date,Ob_Est_Value,Ob_Description")] Tbl_Object tbl_Object)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Object).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Ca_ID = new SelectList(db.Tbl_Category, "Ca_ID", "Ca_Name", tbl_Object.FK_Ca_ID);
            return View(tbl_Object);
        }

        // GET: Object/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Object tbl_Object = db.Tbl_Object.Find(id);
            if (tbl_Object == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Object);
        }

        // POST: Object/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Object tbl_Object = db.Tbl_Object.Find(id);
            db.Tbl_Object.Remove(tbl_Object);
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

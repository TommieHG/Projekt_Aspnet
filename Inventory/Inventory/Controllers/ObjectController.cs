using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using Rotativa;

namespace Inventory.Controllers
{
    
    public class ObjectController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        //GET: Object
        [Authorize(Roles = "Admin, Viewer")]
        public ActionResult Index()
        {
            
            var tbl_Object = db.Tbl_Object.Include(t => t.Tbl_Category);
            ViewBag.Total = tbl_Object.Sum(x => x.Ob_Est_Value);
            return View(tbl_Object.ToList());
        }

        // GET: Object/Details/5
        [Authorize(Roles = "Admin, Viewer")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.FK_Ca_ID = new SelectList(db.Tbl_Category, "Ca_ID", "Ca_Name");
            ViewBag.FK_Lo_ID = new SelectList(db.Tbl_Location, "Lo_ID", "Lo_Name");
            return View();
        }

        // POST: Object/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Ob_ID,FK_Ca_ID,Ob_Name,Ob_Purchase_Date,Ob_Est_Value,Ob_Description,,Ob_Quantity,FK_Lo_ID")] Tbl_Object tbl_Object)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Object.Add(tbl_Object);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Ca_ID = new SelectList(db.Tbl_Category, "Ca_ID", "Ca_Name", tbl_Object.FK_Ca_ID);
            ViewBag.FK_Lo_ID = new SelectList(db.Tbl_Location, "Lo_ID", "Lo_Name");
            return View(tbl_Object);
        }

        // GET: Object/Edit/5
        [Authorize(Roles = "Admin")]
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
            ViewBag.FK_Lo_ID = new SelectList(db.Tbl_Location, "Lo_ID", "Lo_Name");
            return View(tbl_Object);
        }

        // POST: Object/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ob_ID,FK_Ca_ID,Ob_Name,Ob_Purchase_Date,Ob_Est_Value,Ob_Description,Ob_Quantity,FK_Lo_ID")] Tbl_Object tbl_Object)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Object).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.FK_Ca_ID = new SelectList(db.Tbl_Category, "Ca_ID", "Ca_Name", tbl_Object.FK_Ca_ID);
                ViewBag.FK_Lo_ID = new SelectList(db.Tbl_Location, "Lo_ID", "Lo_Name", tbl_Object.FK_Lo_ID);
                return View(tbl_Object);
            }

        }

        // GET: Object/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Object tbl_Object = db.Tbl_Object.Find(id);
            db.Tbl_Object.Remove(tbl_Object);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GeneratePDF()
        {
                Dictionary<string, string> cookieCollection = new Dictionary<string, string>();
                foreach (var key in Request.Cookies.AllKeys)
                {
                    cookieCollection.Add(key, Request.Cookies.Get(key).Value);
                }
                return new ActionAsPdf("Index")
                {
                    FileName = "InventoryList.pdf",
                    Cookies = cookieCollection
                };
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

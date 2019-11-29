using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBiciShop.Models;

namespace MyBiciShop.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Staffs
        public ActionResult Index()
        {
            var staffs = db.Staffs.Include(s => s.Stores);
            return View(staffs.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staffs staffs = db.Staffs.Find(id);
            if (staffs == null)
            {
                return HttpNotFound();
            }
            return View(staffs);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            ViewBag.store_id = new SelectList(db.Stores, "store_id", "store_name");
            return View();
        }

        // POST: Staffs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "staff_id,first_name,last_name,phone,email,active,store_id")] Staffs staffs)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staffs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.store_id = new SelectList(db.Stores, "store_id", "store_name", staffs.store_id);
            return View(staffs);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staffs staffs = db.Staffs.Find(id);
            if (staffs == null)
            {
                return HttpNotFound();
            }
            ViewBag.store_id = new SelectList(db.Stores, "store_id", "store_name", staffs.store_id);
            return View(staffs);
        }

        // POST: Staffs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staff_id,first_name,last_name,phone,email,active,store_id")] Staffs staffs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.store_id = new SelectList(db.Stores, "store_id", "store_name", staffs.store_id);
            return View(staffs);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staffs staffs = db.Staffs.Find(id);
            if (staffs == null)
            {
                return HttpNotFound();
            }
            return View(staffs);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staffs staffs = db.Staffs.Find(id);
            db.Staffs.Remove(staffs);
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

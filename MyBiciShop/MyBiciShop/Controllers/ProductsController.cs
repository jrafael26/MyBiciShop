using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBiciShop.Models;
using MyBiciShop.ViewModels;

namespace MyBiciShop.Controllers
{


    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brands).Include(p => p.Categories);
            return View(products.ToList());
        }

        // GET: Products/Details/5

        [Authorize(Roles = RoleName.Vendedor)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Include(p => p.Brands)
                .Include(p => p.Categories)
                .Include(p => p.Stocks)
                .SingleOrDefault(p => p.product_id==id);
            if (products == null)
            {
                return HttpNotFound();
            }

            var stock = db.Stocks.ToList().Find(s => s.product_id == id);
            products.Stocks = stock;
            return View(products);
        }

        // GET: Products/Create
        [Authorize(Roles = RoleName.Vendedor)]
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name");
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = RoleName.Vendedor)]
        public ActionResult Create([Bind(Include = "product_id,product_name,brand_id,category_id,model_year,list_price,description")] Products products)
        {
            if (ModelState.IsValid)
            {
                if (products.brand_id==0 || products.category_id==0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", products.brand_id);
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", products.category_id);
            return View(products);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = RoleName.Vendedor)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", products.brand_id);
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", products.category_id);
            return View(products);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = RoleName.Vendedor)]
        public ActionResult Edit([Bind(Include = "product_id,product_name,brand_id,category_id,model_year,list_price,description")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.Brands, "brand_id", "brand_name", products.brand_id);
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", products.category_id);
            return View(products);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = RoleName.Vendedor)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = RoleName.Vendedor)]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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

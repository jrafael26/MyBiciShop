using MyBiciShop.Models;
using MyBiciShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBiciShop.Controllers
{
    
    [Authorize(Roles = RoleName.Vendedor)]
    [Authorize(Roles = RoleName.Administrador)]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Orders
        public ActionResult Index()
        {
            var order = db.Orders.Include(dt => dt.OrderItems)
                .Include(c => c.Customers).ToList();
 
            return View(order);
        }
        private string ErrorSmS { get; set; }
        public ActionResult NewOrder()
        {
            var orderView = new OrderView();
            orderView.Customers = new Customers();
            orderView.Products =new List<ProductOrderViewModel>();

            Session["orderView"] = orderView;
            LlenarCustomers();
            return View(orderView);
        }



        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {

            orderView = Session["orderView"] as OrderView;

            //Validamos que selecionen un customer
            var customerID = int.Parse(Request["customer_id"]);
            var usuario = Request["AUTH_USER"];
            if (customerID == 0)
            {
                ErrorSmS = "Debes seleccionar un cliente.";
                LlenarCustomers();
                return View(orderView);
            }
            var customer = db.Customers.Find(customerID);

            if (customer == null)
            {
                ErrorSmS = "El cliente no existe.";
                LlenarCustomers();
                return View(orderView);
            }

            if (orderView.Products.Count == 0)
            {
                ErrorSmS = "Debe ingresar detalles para esta orden.";
                LlenarCustomers();
                return View(orderView);
            }

            int orderID = 0;

            using (var trans = db.Database.BeginTransaction())
            {


                try
                {
                    //Vamos a enviar la orden a la BD

                    var storeID = db.Staffs.ToList().Find(x => x.email == usuario);
                    var order = new Orders
                    {
                        customer_id = customerID,
                        order_date = DateTime.Now,
                        order_status = OrderStatus.Created,
                        required_date = DateTime.Now,
                        shipped_date = DateTime.Now.AddDays(7),
                        store_id = storeID.store_id,
                        staff_id = storeID.staff_id

                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    orderID = db.Orders.ToList().Select(o => o.order_id).Max();

                    foreach (var item in orderView.Products)
                    {
                        var orderDetails = new OrderItems
                        {
                            product_id = item.product_id,
                            list_price = item.list_price,
                            quantity = item.quantity,
                            order_id = orderID

                        };
                        db.OrderItems.Add(orderDetails);
                        db.SaveChanges();
                        var stock = db.Stocks.ToList().Find(s => s.product_id == item.product_id);
                        stock.quantity = (stock.quantity - item.quantity);
                        db.Entry(stock).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    trans.Commit();
                    ErrorSmS = string.Format("La orden: {0}, fue grabada correctamente!", orderID);
                    LlenarCustomers();
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    ErrorSmS = ex.Message;
                    return View(orderView);
                }
            }
        

         return   RedirectToAction("NewOrder");
        }

        public ActionResult AddProduct()
        {
            LlenarProducts();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrderViewModel productOrderView)
        {
            //Validamos que selecionen un customer

            var orderView = Session["orderView"] as OrderView;
            var productID = int.Parse(Request["product_id"]);
            if (productID==0)
            {
                ErrorSmS = "Debes seleccionar un producto";
                LlenarProducts();
                return View(productOrderView);
            }

            var product = db.Products.Find(productID);

            if (product ==null)
            {
                ErrorSmS = "El producto no existe.";
                LlenarProducts();
                return View(productOrderView);
            }

            //Buscamos el producto en la lista para aumentar la cantidad a pedir
            productOrderView = orderView.Products.Find(p => p.product_id==productID);

            
            //Si no aparece lo creamos y si aparece le sumamo a la cantidad la que me enviaron en el form
            if (productOrderView == null)
            {

                productOrderView = new ProductOrderViewModel
                {
                    description = product.description,
                    list_price = product.list_price,
                    product_id = product.product_id,
                    quantity = int.Parse(Request["quantity"]),
                    product_name = product.product_name

                };
            }
            else 
            {
                productOrderView.quantity += int.Parse(Request["quantity"]);
                LlenarCustomers();
                return View("NewOrder", orderView);
            }
            orderView.Products.Add(productOrderView);

            LlenarCustomers();
            return View("NewOrder", orderView);
        }

        public ActionResult Details(int? id)
        {
            //var order = db.OrderItems.Include(o => o.Orders).Include(p => p.Products).ToList().Find(dt => dt.order_id==id);
            var order = db.OrderItems.Include(o => o.Orders).Include(p => p.Products).ToList().Find(dt => dt.order_id == id);

            return View(order);
        }
        private void LlenarCustomers()
        {
            var list = db.Customers.ToList();
            list.Add(new Customers { customer_id = 0, first_name = "[Select a customer...]" });
            list.OrderBy(c => c.full_name).ToList();
            ViewBag.customer_id = new SelectList(list, "customer_id", "full_name");

        }

        private void LlenarProducts()
        {
            //var list = db.Products.ToList();
            //list.Add(new Products { product_id = 0, product_name = "[Select a product...]" });
            //list.OrderBy(p => p.product_name).ToList();
            //ViewBag.product_id = new SelectList(list, "product_id", "product_name");

            var list = db.Products.ToList();
            list.Add(new ProductOrderViewModel { product_id = 0, product_name = "[Select a product...]" });
            list.OrderBy(p => p.product_name).ToList();
            ViewBag.product_id = new SelectList(list, "product_id", "product_name");
            ViewBag.Error = ErrorSmS;

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
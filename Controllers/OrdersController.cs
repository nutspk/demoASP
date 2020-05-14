using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demoASP.Data;
using demoASP.Models;

namespace demoASP.Controllers
{
    public class OrdersController : Controller
    {
        private AppDb db = new AppDb();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Shipper);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var order = db.Orders.Include(o => o.OrderItem).Include(o => o.Customer)
                .FirstOrDefault(o => o.OrderId == id);

            ViewBag.Products = new SelectList(db.Products, "ProductID", "ProductName", "-- Please select --");
            ViewBag.Product = db.Products.ToList();

            if (order == null) return HttpNotFound();

            return View(order);
        }

        [HttpGet]
        public ActionResult GetOrderDetail(int id) {

            var o = db.Orders.Find(id);

            if (o == null) return HttpNotFound();

            return PartialView(o);
        }

        [HttpPost]
        public ActionResult AddOrderDetail(int id, OrderDetail item)
        {
            var o = db.Orders.Find(id);
            if (o == null) return HttpNotFound();

            var p = db.Products.Find(item.ProductId);
            if (p == null) return HttpNotFound();

            OrderDetail itm = o.OrderItem.FirstOrDefault(r => r.Product == p);
            var od = new OrderDetail();

            if (itm != null)
            {
                od = itm;
                od.Quantity += item.Quantity;
                od.UnitPrice = p.UnitPrice;
            }
            else {
                od = new OrderDetail();
                od.Product = p;
                od.UnitPrice = p.UnitPrice;
                od.Quantity = item.Quantity;
            }

            
            
            o.OrderItem.Add(od);

            db.SaveChanges();

            var res = new
            {
                success = "success"
            };

            return Json(res);
        }

        // GET: Orders/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var c = db.Customers.Find(id);
            ViewBag.Customer = c;
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeID", "FullName", "-- Select Employee --");
            ViewBag.ShipperId = new SelectList(db.Shipper, "ShipperId", "CompanyName", "-- Select Shipper --");
            return View();
        }

        [HttpPost]
        [Route("{controller}/create/{customerId}")] //1
        public ActionResult Create(int id, Order order )
        {
            if (ModelState.IsValid) {
                var c = db.Customers.Find(id);
                c.Orders.Add(order);

                db.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = order.OrderId });
            }

            return RedirectToAction(nameof(Index), "Customers");

        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CompanyName", order.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeId);
            ViewBag.ShipperId = new SelectList(db.Shipper, "ShipperId", "CompanyName", order.ShipperId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,EmployeeId,OrderDate,RequiredDate,ShippedDate,ShipperId,freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CompanyName", order.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeId);
            ViewBag.ShipperId = new SelectList(db.Shipper, "ShipperId", "CompanyName", order.ShipperId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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

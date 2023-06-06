using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_09_Mid_Term_.Models;

namespace Project_09_Mid_Term_.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
         ComputerDbContext db = new ComputerDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.ToList());
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "OrderId,OrderDate,DelivaryDate,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
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
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "OrderId,OrderDate,DelivaryDate,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            var existing = db.Orders.FirstOrDefault(c => c.OrderId == id);
            if (existing != null)
            {
                db.Orders.Remove(existing);
                db.SaveChanges();
                return Json(existing.OrderId);
            }
            else
            {
                return HttpNotFound();
            }
        }

        
    }
}

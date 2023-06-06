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
    public class OrderItemsController : Controller
    {
         ComputerDbContext db = new ComputerDbContext();

        // GET: OrderItems
        public ActionResult Index()
        {
            var ordersItem = db.OrdersItem.Include(o => o.Computer).Include(o => o.Order);
            return View(ordersItem.ToList());
        }
        public ActionResult Delete(int id)
        {
            var existing = db.OrdersItem.FirstOrDefault(c => c.OrderItemId == id);
            if (existing != null)
            {
                db.OrdersItem.Remove(existing);
                db.SaveChanges();
                return Json(existing.OrderItemId);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Create()
        {
            ViewBag.ComputerId = new SelectList(db.Computers, "ComputerId", "ComputerName");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            return View();
        }

        
        [HttpPost]
        public ActionResult Create([Bind(Include = "OrderItemId,OrderId,ComputerId,Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.OrdersItem.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComputerId = new SelectList(db.Computers, "ComputerId", "ComputerName", orderItem.ComputerId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderItem.OrderId);
            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrdersItem.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputerId = new SelectList(db.Computers, "ComputerId", "ComputerName", orderItem.ComputerId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderItem.OrderId);
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderItemId,OrderId,ComputerId,Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComputerId = new SelectList(db.Computers, "ComputerId", "ComputerName", orderItem.ComputerId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderItem.OrderId);
            return View(orderItem);
        }

    }
}

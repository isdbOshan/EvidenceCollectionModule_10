using Project_09_Mid_Term_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_09_Mid_Term_.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        ComputerDbContext db=new ComputerDbContext();
        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult Delete(int id)
        {
            var existing = db.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (existing != null)
            {
                db.Customers.Remove(existing);
                db.SaveChanges();
                return Json(existing.CustomerId);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return Json(customer.CustomerId);
            }
            return Json(null);
        }
        public ActionResult Edit(int id)
        {
            var i = db.Customers.FirstOrDefault(x => x.CustomerId == id);
            return View(i);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(customer.CustomerId);
        }
    }
}

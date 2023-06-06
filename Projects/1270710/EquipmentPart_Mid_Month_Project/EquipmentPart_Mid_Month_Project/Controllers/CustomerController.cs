using EquipmentPart_Mid_Month_Project.Models;
using EquipmentPart_Mid_Month_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipmentPart_Mid_Month_Project.Controllers
{
    public class CustomerController : Controller
    {
        EquipmentDbContext db = new EquipmentDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CustomerNameList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Company", Value="", Selected=true},
                new SelectListItem{Text="Pavel Islam", Value="Pavel Islam"},
                new SelectListItem{Text="Abdur Rahib", Value="Abdur Rahib"},
                new SelectListItem{Text="Rahib Howlader", Value="Rahib Howlader"},
                new SelectListItem{Text="Sazu", Value="Sazu"},
                new SelectListItem{Text="Arif", Value="Arif"}
            };
            ViewBag.EquipmentNames = db.Equipments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.CustomerNameList = new List<SelectListItem>
            { new SelectListItem{Text="Select Company", Value="", Selected=true},
                new SelectListItem{Text="Pavel Islam", Value="Pavel Islam"},
                new SelectListItem{Text="Abdur Rahib", Value="Abdur Rahib"},
                new SelectListItem{Text="Rahib Howlader", Value="Rahib Howlader"},
                new SelectListItem{Text="Sazu", Value="Sazu"},
                new SelectListItem{Text="Arif", Value="Arif"}
            };
            ViewBag.EquipmentNames = db.Equipments.ToList();
            var Cus = db.Customers.FirstOrDefault(d => d.CustomerId == id);
            return View(new CustomerEditModel
            {
               CustomerId = Cus.CustomerId,
               CustomerName = Cus.CustomerName,
               Age = Cus.Age,
               City = Cus.City,
               Country = Cus.Country,
               Phone = Cus.Phone,
               Email = Cus.Email,
               EquipmentId = Cus.EquipmentId
            });
        }
        [HttpPost]
        public ActionResult Edit(CustomerEditModel c)
        {
            Customer Cust = db.Customers.First(x => x.CustomerId ==  c.CustomerId);
            if (ModelState.IsValid)
            {
                Cust.CustomerName = c.CustomerName;
                Cust.Age = c.Age;
                Cust.City = c.City;
                Cust.Country = c.Country;
                Cust.Phone = c.Phone;
                Cust.Email = c.Email;
                Cust.EquipmentId = c.EquipmentId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerNameList = new List<SelectListItem>
            { new SelectListItem{Text="Select Company", Value="", Selected=true},
                new SelectListItem{Text="Pavel Islam", Value="Pavel Islam"},
                new SelectListItem{Text="Abdur Rahim", Value="Abdur Rahim"},
                new SelectListItem{Text="Rahib Howlader", Value="Rahib Howlader"},
                new SelectListItem{Text="Sazu", Value="sazu"},
                new SelectListItem{Text="Arif", Value="Arif"}
            };
            ViewBag.EquipmentNames = db.Equipments.ToList();
            return View(c);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Customers.FirstOrDefault(d => d.CustomerId == id);
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
    }
}
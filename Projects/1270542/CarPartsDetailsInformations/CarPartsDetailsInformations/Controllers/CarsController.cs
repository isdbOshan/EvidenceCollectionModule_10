using CarPartsDetailsInformations.Models;
using CarPartsDetailsInformations.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarPartsDetailsInformations.Controllers
{
    public class CarsController : Controller
    {
        VehicleInformationDbContext db = new VehicleInformationDbContext();
        public ActionResult Index()
        {
            return View(db.Vehicles.Include(x => x.Customer).ToList()); ;
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(InputViewModel data)
        {
            if (ModelState.IsValid)
            {
                Vehicle c = new Vehicle
                {
                    VehicleName = data.VehicleName,
                    Price = data.Price,
                    MakeYear= data.MakeYear,    
                    IsStock= data.IsStock,
                    Picture= data.Picture,

                };
                foreach (var q in data.Customer)
                {
                    c.Customer.Add(q);
                }
                db.Vehicles.Add(c);
                db.SaveChanges();
                return Json(new { id = c.VehicleId });
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToForm(InputViewModel c = null, int? index = null)
        {
            if (c == null) c = new InputViewModel();
            if (index.HasValue)
            {
                if (index < c.Customer.Count)
                {
                    c.Customer.RemoveAt(index.Value);
                }
            }
            else
            {
                c.Customer.Add(new Customer());
            }

            return PartialView("_VehicleListInfo", c);
        }
        public ActionResult UploadImage(int id, UploadImage pic)
        {
            if (ModelState.IsValid)
            {
                if (pic.Picture != null)
                {
                    Vehicle c = db.Vehicles.First(x => x.VehicleId == id);
                    string ext = Path.GetExtension(pic.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    pic.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                    db.SaveChanges();
                    return Json(fileName);
                }
            }
            return Json(null);
        }
 
        public ActionResult Edit(int id)
        {

            var car = db.Vehicles.Include(c => c.Customer).First(c => c.VehicleId == id);

            return View(
                new EditViewModel
                {
                    VehicleId = car.VehicleId,
                    VehicleName = car.VehicleName,
                    Price = car.Price,
                    MakeYear = car.MakeYear,
                    IsStock = car.IsStock,
                    Picture = car.Picture,
                    Customer = car.Customer.ToList()
                }
                );
        }
        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            var existing = db.Vehicles.First(c => c.VehicleId == model.VehicleId);
            if (ModelState.IsValid)
            {
                existing.VehicleName = model.VehicleName;
                existing.Price = model.Price;
                existing.MakeYear = model.MakeYear;
                existing.IsStock = model.IsStock;
                //existing.Picture = model.Picture;
              db.Customers.RemoveRange(existing.Customer.ToList());
                foreach (var q in model.Customer)
                {
                    q.CustomerId = existing.VehicleId;
                    db.Customers.Add(q);
                }
                db.SaveChanges();
                return Json(existing.VehicleId);
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToEditForm(EditViewModel c, int? index = null)
        {

            if (index.HasValue)
            {
                if (index < c.Customer.Count)
                {
                    c.Customer.RemoveAt(index.Value);
                }
            }


            return PartialView("_VehicleEditInfo", c);
        }
        public PartialViewResult AddMore(EditViewModel c, int? index = null)
        {
            if (c == null) c = new EditViewModel();
            if (index.HasValue)
            {
                if (index < c.Customer.Count)
                {
                    c.Customer.RemoveAt(index.Value);
                }
            }
            else
            {
                c.Customer.Add(new Customer());
            }

            return PartialView("_VehicleEditInfo", c);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Vehicles.FirstOrDefault(c => c.VehicleId == id);
            if (existing != null)
            {
                db.Vehicles.Remove(existing);
                db.SaveChanges();
                return Json(existing.VehicleId);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //end section
    }
}
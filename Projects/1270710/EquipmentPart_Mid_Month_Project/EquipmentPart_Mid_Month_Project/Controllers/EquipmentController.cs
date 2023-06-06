using EquipmentPart_Mid_Month_Project.Models;
using EquipmentPart_Mid_Month_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipmentPart_Mid_Month_Project.Controllers
{
    public class EquipmentController : Controller
    {
        EquipmentDbContext db = new EquipmentDbContext();
        // GET: Equipment
        public ActionResult Index()
        {
            //return View(db.Equipments.ToList());
            return View(db.Equipments.Include(x => x.Part).ToList());
        }
        ////Create
        ///
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EquipmentInputModel data)
        {
            if (ModelState.IsValid)
            {
                Equipment e = new Equipment
                {
                    EquipmentName = data.EquipmentName,
                    DeliveryDate = data.DeliveryDate,
                    Price = data.Price,
                    Available = data.Available,
                    Picture = data.Picture
                };
                foreach (var p in data.Parts)
                {
                    e.Part.Add(p);
                }
                db.Equipments.Add(e);
                db.SaveChanges();
                return Json(new { id = e.EquipmentId });
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToForm(EquipmentInputModel e = null, int? index = null)
        {
            if (e == null) e = new EquipmentInputModel();
            if (index.HasValue)
            {
                if (index < e.Parts.Count)
                {
                    e.Parts.RemoveAt(index.Value);
                }
            }
            else
            {
                e.Parts.Add(new Part());
            }
            return PartialView("_PartForm", e);
        }
        public ActionResult ImageUpload(int id, ImageUpload pic)
        {
            if (ModelState.IsValid)
            {
                if (pic.Picture != null)
                {
                    Equipment e = db.Equipments.First(x => x.EquipmentId == id);
                    string ext = Path.GetExtension(pic.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    pic.Picture.SaveAs(savePath);
                    e.Picture = fileName;
                    db.SaveChanges();
                    return Json(fileName);

                }
            }
            return Json(null);
        }
        public ActionResult Edit(int id)
        {

            var equipment = db.Equipments.Include(c => c.Part).First(c => c.EquipmentId == id);

            return View(
                new EquipmentEditModel
                {
                    EquipmentId = equipment.EquipmentId,
                    EquipmentName = equipment.EquipmentName,
                    DeliveryDate = equipment.DeliveryDate,
                    Price = equipment.Price,
                    Available = equipment.Available,
                    Picture = equipment.Picture,
                    Parts = equipment.Part.ToList()
                }
                );
        }
        [HttpPost]
        public ActionResult Edit(EquipmentEditModel model)
        {
            var existing = db.Equipments.First(c => c.EquipmentId == model.EquipmentId);
            if (ModelState.IsValid)
            {

                existing.EquipmentName = model.EquipmentName;
                existing.DeliveryDate = model.DeliveryDate;
                existing.Price = model.Price;
                existing.Available = model.Available;

                db.Parts.RemoveRange(existing.Part.ToList());
                foreach (var q in model.Parts)
                {
                    q.EquipmentId = existing.EquipmentId;
                    db.Parts.Add(q);
                }
                db.SaveChanges();
                return Json(existing.EquipmentId);
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToEditForm(EquipmentEditModel c, int? index = null)
        {

            if (index.HasValue)
            {
                if (index < c.Parts.Count)
                {
                    c.Parts.RemoveAt(index.Value);
                }
            }


            return PartialView("_PartEditForm", c);
        }
        public PartialViewResult AddMore(EquipmentEditModel c, int? index = null)
        {
            if (c == null) c = new EquipmentEditModel();
            if (index.HasValue)
            {
                if (index < c.Parts.Count)
                {
                    c.Parts.RemoveAt(index.Value);
                }
            }
            else
            {
                c.Parts.Add(new Part());
            }

            return PartialView("_QualificationEditForm", c);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Equipments.FirstOrDefault(c => c.EquipmentId == id);
            if (existing != null)
            {
                db.Equipments.Remove(existing);
                db.SaveChanges();
                return Json(existing.EquipmentId);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
using Project_09_Mid_Term_.Models;
using Project_09_Mid_Term_.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_09_Mid_Term_.Controllers
{
    [Authorize]
    public class ComputersController : Controller
    {
        ComputerDbContext db = new ComputerDbContext();
        // GET: Computers
        public ActionResult Index()
        {
            return View(db.Computers.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Computer computer)
        {
            if (ModelState.IsValid)
            {
                db.Computers.Add(computer);
                db.SaveChanges();
                return Json(new { id = computer.ComputerId });
            }
            return Json(null);
        }
        public ActionResult Image(int id, ImageUp img)
        {
            if (ModelState.IsValid)
            {
                if (img.Picture != null)
                {
                    Computer b = db.Computers.FirstOrDefault(x => x.ComputerId == id);
                    string ext = Path.GetExtension(img.Picture.FileName);
                    string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savepath = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    img.Picture.SaveAs(savepath);
                    b.Picture = filename;
                    db.SaveChanges();
                    return Json(filename);
                }
            }
            return Json(null);
        }
        public ActionResult Delete(int id)
        {
            var existing = db.Computers.FirstOrDefault(c => c.ComputerId == id);
            if (existing != null)
            {
                db.Computers.Remove(existing);
                db.SaveChanges();
                return Json(existing.ComputerId);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Edit(int id)
        {
            var i = db.Computers.FirstOrDefault(x => x.ComputerId == id);
            ViewBag.Picture = i.Picture;
            return View(i);
        }
        [HttpPost]
        public ActionResult Edit(Computer computer)
        {

            db.Entry(computer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(computer.ComputerId);
        }
    }
}
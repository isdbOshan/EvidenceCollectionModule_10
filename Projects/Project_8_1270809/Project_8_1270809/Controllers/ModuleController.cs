using Project_8_1270809.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_8_1270809.Controllers
{
    public class ModuleController : Controller
    {
        TraineesDbContext db= new TraineesDbContext();
        // GET: Module
        public ActionResult Index()
        {
            return View(db.Modules.ToList());
        }
        public ActionResult Delete(int id)
        {
            var existing = db.Modules.FirstOrDefault(x => x.ModuleId == id);
            if (existing != null)
            {
                db.Modules.Remove(existing);
                db.SaveChanges();
                return Json(existing.ModuleId);
            }
            return Json(null);
        }
    }
}
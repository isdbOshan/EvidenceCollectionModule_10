using Project_8_1270809.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_8_1270809.Controllers
{
    public class TraineeController : Controller
    {
        TraineesDbContext db = new TraineesDbContext();
        // GET: Trainee
        public ActionResult Index()
        {
            return View(db.Trainees.Include(x=>x.Modules).ToList());
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Trainees.FirstOrDefault(x => x.TraineeId == id);
            if (existing != null)
           {
                db.Trainees.Remove(existing);
                db.SaveChanges();
                return Json(existing.TraineeId);
            }
            return Json(null);
        }
    }
}
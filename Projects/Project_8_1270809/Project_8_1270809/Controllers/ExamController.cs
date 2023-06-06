using Project_8_1270809.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_8_1270809.Controllers
{
    public class ExamController : Controller
    {
        TraineesDbContext db =new TraineesDbContext();
        // GET: Exam
        public ActionResult Index()
        {
            return View(db.Exams.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Module = db.Modules.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Exam E)
        {
            if(ModelState.IsValid)
            {
                db.Exams.Add(E);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Module = db.Modules.ToList();
            return View(E) ;
        }
        public ActionResult Edit(int id)
        {
            var exam = db.Exams.FirstOrDefault(x => x.ExamId == id);
            ViewBag.Module = db.Modules.ToList();
            return View(exam);
        }
        [HttpPost]
        public ActionResult Edit( Exam E)
        {
            if (ModelState.IsValid)
            {
                db.Entry(E).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Module = db.Modules.ToList();
            return View(E);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Exams.FirstOrDefault(x => x.ExamId == id);
            if (existing != null)
            {
                db.Exams.Remove(existing);
                db.SaveChanges();
                return Json(existing.ExamId);
            }
            return Json(null);
        }
    }
}
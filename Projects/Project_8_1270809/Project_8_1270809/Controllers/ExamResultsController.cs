using Project_8_1270809.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_8_1270809.Controllers
{
    public class ExamResultsController : Controller
    {
        TraineesDbContext db = new TraineesDbContext();
        // GET: ExamResults
        public ActionResult Index()
        {
            return View(db.ExamResults.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Exam = db.Exams.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ExamResult ER)
        {
            if(ModelState.IsValid)
            {
                db.ExamResults.Add(ER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Exam = db.Exams.ToList();
            return View(ER);
        }
        public ActionResult Edit (int id)
        {
            var ExamResults = db.ExamResults.FirstOrDefault(x => x.ResutlId == id);
            ViewBag.Exam = db.Exams.ToList();
            return View(ExamResults);
        }
        [HttpPost]
        public ActionResult Edit (ExamResult ER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ER).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Exam = db.Exams.ToList();
            return View(ER);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.ExamResults.FirstOrDefault(x => x.ResutlId == id);
            if (existing != null)
            {
                db.ExamResults.Remove(existing);
                db.SaveChanges();
                return Json(existing.ResutlId);
            }
            return Json(null);
        }
    }
}
using project.Models;
using project.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        TutorDbContext db = new TutorDbContext();
        // GET: Students
        [AllowAnonymous]
        public ActionResult Index()
        {
            var students = db.Students.Include(t => t.Areas);
            return View(students.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Area = db.Areas.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Student s = new Student
                {
                    StudentName = student.StudentName,
                    StudentClass = student.StudentClass,
                    Studentdob = student.Studentdob,
                    StudentEmail = student.StudentEmail,
                    StudentPhone = student.StudentPhone,
                    AreaId = student.AreaId
                };
                
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Students.FirstOrDefault(x => x.StudentId == id);

            ViewBag.Area = db.Areas.ToList();

            return View(
                new Student {
                    StudentId = data.StudentId,
                     Studentdob = data.Studentdob,
                     StudentClass = data.StudentClass,
                     StudentPhone= data.StudentPhone,
                     StudentEmail= data.StudentEmail,
                     StudentName = data.StudentName,
                     AreaId = data.AreaId
        });
        }
        [HttpPost]

        public ActionResult Edit(Student student)
        {
            var data = db.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
            if (ModelState.IsValid)
            {
                data.StudentId = student.StudentId;
                data.Studentdob = student.Studentdob;
                data.StudentEmail = student.StudentEmail;
                data.StudentPhone = student.StudentPhone;
                data.AreaId = student.AreaId;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
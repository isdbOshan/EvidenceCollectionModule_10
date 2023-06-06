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
using System.Web.UI;

namespace project.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        TutorDbContext db = new TutorDbContext();
        // GET: Teachers
        [AllowAnonymous]
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.Areas);
            return View(teachers.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Area = db.Areas.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeacherInputModel teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher t = new Teacher
                {
                    TeacherName = teacher.TeacherName,
                    Teacherdob = teacher.Teacherdob,
                    TeacherEmail = teacher.TeacherEmail,
                    TeacherPhone = teacher.TeacherPhone,
                    ExpectedAmount = teacher.ExpectedAmount,
                    IsAvailable = teacher.IsAvailable,
                    Picture = teacher.Picture,
                    AreaId = teacher.AreaId 
                };
                foreach (var q in teacher.TeacherQualifications)
                {
                    t.TeacherQualifications.Add(q);
                }

                db.Teachers.Add(t);
                db.SaveChanges();
                return Json(new {id=t.TeacherId});
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToForm(TeacherInputModel t = null, int? index = null)
        {
            if (t == null) t = new TeacherInputModel();
            if (index.HasValue)
            {
                if (index < t.TeacherQualifications.Count)
                {
                    t.TeacherQualifications.RemoveAt(index.Value);
                }
            }
            else
            {
                t.TeacherQualifications.Add(new TeacherQualification());
            }

            return PartialView("_QualificationForm", t);
        }
        public ActionResult UploadImage(int id, UploadImage pic)
        {
            if (ModelState.IsValid)
            {
                if (pic.Picture != null)
                {
                    Teacher t = db.Teachers.First(x => x.TeacherId == id);
                    string ext = Path.GetExtension(pic.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    pic.Picture.SaveAs(savePath);
                    t.Picture = fileName;
                    db.SaveChanges();
                    return Json(fileName);
                }
            }
            return Json(null);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Area = db.Areas.ToList();
            var data = db.Teachers.Include(t=> t.TeacherQualifications).First(x => x.TeacherId == id);

            return View(
               new TeacherEditModel
               {
                   TeacherId = data.TeacherId,
                   TeacherName = data.TeacherName,
                   Teacherdob = data.Teacherdob,
                   TeacherEmail = data.TeacherEmail,
                   TeacherPhone = data.TeacherPhone,
                   ExpectedAmount = data.ExpectedAmount,
                   IsAvailable = data.IsAvailable,
                   AreaId = data.AreaId,    
                   Picture = data.Picture
               });
        }
        [HttpPost]

        public ActionResult Edit(TeacherEditModel teacher)
        {
            var data = db.Teachers.First(x => x.TeacherId == teacher.TeacherId);
            if (ModelState.IsValid)
            {
                data.TeacherId = teacher.TeacherId;
                data.TeacherName = teacher.TeacherName;
                data.TeacherPhone = teacher.TeacherPhone;
                data.TeacherEmail = teacher.TeacherEmail;
                data.Teacherdob = teacher.Teacherdob;
                data.IsAvailable = teacher.IsAvailable;
                data.AreaId = teacher.AreaId;
                db.TeacherQualifications.RemoveRange(data.TeacherQualifications.ToList());
                foreach(var q in teacher.TeacherQualifications)
                {
                    q.TeacherId = data.TeacherId;
                    db.TeacherQualifications.Add(q);
                }
                db.SaveChanges();
                return Json(data.TeacherId);
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToEditForm(TeacherEditModel t, int? index = null)
        {
            
            if (index.HasValue)
            {
                if (index < t.TeacherQualifications.Count)
                {
                    t.TeacherQualifications.RemoveAt(index.Value);
                }
            }
            

            return PartialView("_QualificationEditForm", t);
        }
        public PartialViewResult AddMore(TeacherEditModel t, int? index = null)
        {

            if (t == null) t = new TeacherEditModel();
            if (index.HasValue)
            {
                if (index < t.TeacherQualifications.Count)
                {
                    t.TeacherQualifications.RemoveAt(index.Value);
                }
            }
            else
            {
                t.TeacherQualifications.Add(new TeacherQualification());
            }

            return PartialView("_QualificationEditForm", t);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (existing != null)
            {
                db.Teachers.Remove(existing);
                db.SaveChanges();
                return Json(existing.TeacherId);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        
    }

}

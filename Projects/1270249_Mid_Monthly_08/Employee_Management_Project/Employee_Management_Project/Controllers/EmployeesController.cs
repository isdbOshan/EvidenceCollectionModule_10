using Employee_Management_Project.Models;
using Employee_Management_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_Project.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        EmployeeExperienceDbContext db = new EmployeeExperienceDbContext();
        public ActionResult Index()
        {
            return View(db.Employees.Include(x => x.Experiences).ToList());
        }
        //Create Employee and Experiences
        public ActionResult Create()
        {
            ViewBag.BranchList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Branch", Value="", Selected=true},
                new SelectListItem{Text="Sydney, New South Wales, Australia", Value="Sydney, New South Wales, Australia"},
                new SelectListItem{Text="Newcastle, New South Wales, Australia", Value="Newcastle, New South Wales, Australia"},
                new SelectListItem{Text="Toowoomba, Queensland, Australia", Value="Toowoomba, Queensland, Australia"},
                new SelectListItem{Text="Flinders Street, Adelaide, South Australia", Value="Flinders Street, Adelaide, South Australia"}
            };
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeInputModel data)
        {
            if (ModelState.IsValid)
            {
                Employee e = new Employee
                {
                    EmployeeName = data.EmployeeName,
                    BranchName = data.BranchName,
                    JoiningDate = data.JoiningDate,
                    ActivityStatus = data.ActivityStatus,
                    Salary = data.Salary,
                    Phone = data.Phone,
                    Picture = data.Picture
                };
                foreach (var ex in data.Experiences)
                {
                    e.Experiences.Add(ex);
                }
                db.Employees.Add(e);
                db.SaveChanges();
                return Json(new { id = e.EmployeeID });
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToForm(EmployeeInputModel e = null, int? index = null)
        {
            if (e == null) e = new EmployeeInputModel();
            if (index.HasValue)
            {
                if (index < e.Experiences.Count)
                {
                    e.Experiences.RemoveAt(index.Value);
                }
            }
            else
            {
                e.Experiences.Add(new Experience());
            }
            return PartialView("_ExperiencePartial", e);
        }
        public ActionResult UploadImage(int id, ImageUpload img)
        {
            if (ModelState.IsValid)
            {
                if (img.Picture != null)
                {
                    Employee e = db.Employees.First(x => x.EmployeeID == id);
                    string ext = Path.GetExtension(img.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    img.Picture.SaveAs(savePath);
                    e.Picture = fileName;
                    db.SaveChanges();
                    return Json(fileName);
                }
            }
            return Json(null);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.BranchList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Branch", Value="", Selected=true},
                new SelectListItem{Text="Sydney, New South Wales, Australia", Value="Sydney, New South Wales, Australia"},
                new SelectListItem{Text="Newcastle, New South Wales, Australia", Value="Newcastle, New South Wales, Australia"},
                new SelectListItem{Text="Toowoomba, Queensland, Australia", Value="Toowoomba, Queensland, Australia"},
                new SelectListItem{Text="Flinders Street, Adelaide, South Australia", Value="Flinders Street, Adelaide, South Australia"}
            };
            var d = db.Employees.Include(x => x.Experiences).First(x => x.EmployeeID == id);
            return View(new EmployeeEditModel
            {
                EmployeeID = d.EmployeeID,
                EmployeeName = d.EmployeeName,
                BranchName = d.BranchName,
                JoiningDate = d.JoiningDate,
                ActivityStatus = d.ActivityStatus,
                Salary = d.Salary,
                Phone = d.Phone,
                Picture = d.Picture,
                Experiences = d.Experiences.ToList()
            });
        }
        [HttpPost]
        public ActionResult Edit(EmployeeEditModel model)
        {
            var existing = db.Employees.First(x => x.EmployeeID == model.EmployeeID);
            if (ModelState.IsValid)
            {
                existing.EmployeeName = model.EmployeeName;
                existing.BranchName = model.BranchName;
                existing.JoiningDate = model.JoiningDate;
                existing.ActivityStatus = model.ActivityStatus;
                existing.Salary = model.Salary;
                existing.Phone = model.Phone;
                db.Experiences.RemoveRange(existing.Experiences.ToList());
                foreach (var p in model.Experiences)
                {
                    p.EmployeeID = existing.EmployeeID;
                    db.Experiences.Add(p);
                }
                db.SaveChanges();
                return Json(existing.EmployeeID);
            }
            return Json(null);
        }
        public PartialViewResult AddExperiencesToEditForm(EmployeeEditModel d, int? index = null)
        {
            if (index.HasValue)
            {
                if (index < d.Experiences.Count)
                {
                    d.Experiences.RemoveAt(index.Value);
                }
            }
            return PartialView("_ExperienceEditPartial", d);
        }
        public PartialViewResult AddMore(EmployeeEditModel d, int? index = null)
        {
            if (d == null) d = new EmployeeEditModel();
            if (index.HasValue)
            {
                if (index < d.Experiences.Count)
                {
                    d.Experiences.RemoveAt(index.Value);
                }
            }
            else
            {
                d.Experiences.Add(new Experience());
            }
            return PartialView("_ExperienceEditPartial", d);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (existing != null)
            {
                db.Employees.Remove(existing);
                db.SaveChanges();
                return Json(existing.EmployeeID);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
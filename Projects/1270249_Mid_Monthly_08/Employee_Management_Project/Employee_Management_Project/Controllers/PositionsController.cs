using Employee_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Employee_Management_Project.ViewModels;

namespace Employee_Management_Project.Controllers
{
    [Authorize]
    public class PositionsController : Controller
    {
        EmployeeExperienceDbContext db = new EmployeeExperienceDbContext();
        // GET: Positions
        public ActionResult Index()
        {
           
            return View(db.Positions.Include(x => x.Employee).ToList());
        }
        public ActionResult Create()
        {
            ViewBag.DailyRateList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Daily Rate",Value="", Selected=true},
                new SelectListItem{Text="1000", Value="1000"},
                new SelectListItem{Text="2000", Value="2000"},
                new SelectListItem{Text="3000", Value="3000"},
                new SelectListItem{Text="4000", Value="4000"},
                new SelectListItem{Text="5000", Value="5000"}
            };
            ViewBag.Employees = db.Employees.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Position p)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.DailyRateList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Daily Rate",Value="", Selected=true},
                new SelectListItem{Text="1000", Value="1000"},
                new SelectListItem{Text="2000", Value="2000"},
                new SelectListItem{Text="3000", Value="3000"},
                new SelectListItem{Text="4000", Value="4000"},
                new SelectListItem{Text="5000", Value="5000"}
            };
            ViewBag.Employees = db.Employees.ToList();
            var posi = db.Positions.FirstOrDefault(p => p.PositionID == id);
            return View(new PositionEditModel
            {
                PositionID= posi.PositionID,
                DailyRate=posi.DailyRate,
                WorkingDaysPerMonth=posi.WorkingDaysPerMonth,
                EmployeeID=posi.EmployeeID
            });
        }
        [HttpPost]
        public ActionResult Edit(PositionEditModel p)
        {
            Position pos = db.Positions.First(x=>x.PositionID == p.PositionID);
            if(ModelState.IsValid)
            {
                pos.DailyRate= p.DailyRate;
                pos.WorkingDaysPerMonth= p.WorkingDaysPerMonth;
                pos.EmployeeID= p.EmployeeID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DailyRateList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Daily Rate",Value="", Selected=true},
                new SelectListItem{Text="1000", Value="1000"},
                new SelectListItem{Text="2000", Value="2000"},
                new SelectListItem{Text="3000", Value="3000"},
                new SelectListItem{Text="4000", Value="4000"},
                new SelectListItem{Text="5000", Value="5000"}
            };
            ViewBag.Employees = db.Employees.ToList();
            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Positions.FirstOrDefault(p => p.PositionID== id);
            if (existing != null)
            {
                db.Positions.Remove(existing);
                db.SaveChanges();
                return Json(existing.PositionID);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
using EquipmentPart_Mid_Month_Project.Models;
using EquipmentPart_Mid_Month_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipmentPart_Mid_Month_Project.Controllers
{
    public class PartDetailController : Controller
    {
        EquipmentDbContext db = new EquipmentDbContext();
        // GET: PartDetail
        public ActionResult Index()
        {
            return View(db.PartDetails.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CompanyList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Company", Value="", Selected=true},
                new SelectListItem{Text="WALTON HI-TECH INDUSTRIES Ltd", Value="WALTON HI-TECH INDUSTRIES Ltd"},
                new SelectListItem{Text="S.S. MOTORS LTD", Value="S.S. MOTORS LTD"},
                new SelectListItem{Text="ENERGYPAC ENGINEERING LTD", Value="ENERGYPAC ENGINEERING LTD"},
                new SelectListItem{Text="ADEX CORPORATION LTD", Value="ADEX CORPORATION LTD"},
                new SelectListItem{Text="A.K Machinery & Parts Ltd", Value="A.K Machinery & Parts Ltd"}
            };
            ViewBag.PartName = db.Parts.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PartDetail d)
        {
            if(ModelState.IsValid)
            {
                db.PartDetails.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartName = db.Parts.ToList();
            return View(d);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.CompanyList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Company", Value="", Selected=true},
                new SelectListItem{Text="WALTON HI-TECH INDUSTRIES Ltd", Value="WALTON HI-TECH INDUSTRIES Ltd"},
                new SelectListItem{Text="S.S. MOTORS LTD", Value="S.S. MOTORS LTD"},
                new SelectListItem{Text="ENERGYPAC ENGINEERING LTD", Value="ENERGYPAC ENGINEERING LTD"},
                new SelectListItem{Text="ADEX CORPORATION LTD", Value="ADEX CORPORATION LTD"},
                new SelectListItem{Text="A.K Machinery & Parts Ltd", Value="A.K Machinery & Parts Ltd"}
            };
            ViewBag.PartName = db.Parts.ToList();
            var PartDe = db.PartDetails.FirstOrDefault(d=> d.PartDetailId ==id);
            return View(new PartDetailEditModel
            {
                PartDetailId = PartDe.PartDetailId,
                Description = PartDe.Description,
                Expiredate = PartDe.Expiredate,
                Material = PartDe.Material,
                Company = PartDe.Company,
                PartId = PartDe.PartId
            });
        }
        [HttpPost]
        public ActionResult Edit(PartDetailEditModel d)
        {
            PartDetail PartD = db.PartDetails.First(x=>x.PartDetailId == d.PartDetailId);
            if(ModelState.IsValid)
            {
                PartD.Company = d.Company;
                PartD.Description = d.Description;
                PartD.Expiredate = d.Expiredate;
                PartD.Material = d.Material;
                PartD.PartId = PartD.PartId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanayList = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Company", Value="", Selected=true},
                new SelectListItem{Text="WALTON HI-TECH INDUSTRIES Ltd", Value="WALTON HI-TECH INDUSTRIES Ltd"},
                new SelectListItem{Text="S.S. MOTORS LTD", Value="S.S. MOTORS LTD"},
                new SelectListItem{Text="ENERGYPAC ENGINEERING LTD", Value="ENERGYPAC ENGINEERING LTD"},
                new SelectListItem{Text="ADEX CORPORATION LTD", Value="ADEX CORPORATION LTD"},
                new SelectListItem{Text="A.K Machinery & Parts Ltd", Value="A.K Machinery & Parts Ltd"}
            };
            ViewBag.PartName = db.Parts.ToList();
            return View(d);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.PartDetails.FirstOrDefault(d=> d.PartDetailId ==id);
            if(existing != null)
            {
                db.PartDetails.Remove(existing);
                db.SaveChanges();
                return Json(existing.PartDetailId);
            }
            else
            {
                return HttpNotFound();
            }
            
        }
    }
}
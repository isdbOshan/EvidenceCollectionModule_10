using project.Models;
using project.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    [Authorize]
    public class AreasController : Controller
    {
        TutorDbContext db = new TutorDbContext();
        // GET: Areas
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            ViewBag.current = page;
            ViewBag.TotalPage = Math.Ceiling((double)db.Areas.Count() / 5);
            return View(db.Areas.OrderBy(x => x.AreaId).Skip(page - 1).Take(5).ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Area area)
        {
            if (ModelState.IsValid)
            {
                db.Areas.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(area);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        [HttpPost]
        public ActionResult Edit(Area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(area);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

         
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Area area = db.Areas.Find(id);
            db.Areas.Remove(area);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
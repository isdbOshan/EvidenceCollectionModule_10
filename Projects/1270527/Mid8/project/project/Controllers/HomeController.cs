using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        TutorDbContext db = new TutorDbContext();
        // GET: Areas
        public ActionResult Index(int page = 1)
        {
            ViewBag.current = page;
            ViewBag.TotalPage = Math.Ceiling((double)db.Areas.Count() / 5);
            return View(db.Areas.OrderBy(x => x.AreaId).Skip(page - 1).Take(5).ToList());
        }
    }
}
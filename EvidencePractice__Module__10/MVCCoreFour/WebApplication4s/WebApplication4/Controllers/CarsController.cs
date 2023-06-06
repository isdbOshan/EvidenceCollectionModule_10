using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarPartsDetailDbContext db;
        private readonly IWebHostEnvironment env;
        public CarsController(CarPartsDetailDbContext db, IWebHostEnvironment env)
        {

            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(db.CarDetails.Include(c=>c.PartsDetail.ToList()));
        }
    }
}

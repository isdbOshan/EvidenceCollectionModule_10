using Microsoft.AspNetCore.Mvc;

namespace R52_M9_Class_08_Work_02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

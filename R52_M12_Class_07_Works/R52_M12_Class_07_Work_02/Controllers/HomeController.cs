using Microsoft.AspNetCore.Mvc;

namespace R52_M12_Class_07_Work_02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Project_09_Mid_Term_.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace Project_09_Mid_Term_.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = await userManager.FindAsync(model.Username, model.Password);

                if (user != null)
                {

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed. Check username & password.");
                }
            }
            return View(model);
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser { UserName = model.Username };
                var result = await manager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Registration failed");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var am=HttpContext.GetOwinContext().Authentication;
            am.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
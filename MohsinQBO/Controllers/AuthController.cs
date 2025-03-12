using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            string loggedIn = HttpContext?.Session?.GetString("LoggedIn");
            if (string.IsNullOrEmpty(loggedIn))
                return View();
            else
                return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if(login == null)
            {
                ViewBag.Error = "Email and password are required!";
;                return View(login);
            }

            if (login.Email!="mohsin@yopmail.com"&& login.Email != "Admin@123")
            {
                ViewBag.Error = "Authentication Failed!";
                return View(login);
            }
            HttpContext.Session.SetString("LoggedIn", "true");
            
            return RedirectToAction("Index","Home");
        }
    }
}

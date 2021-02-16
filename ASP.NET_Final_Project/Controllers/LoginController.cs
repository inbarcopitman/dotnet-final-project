using ASP.NET_Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Final_Project.Controllers
{
    public class LoginController : Controller
    {
        public object Session { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostLogin()
        {
            var userObj = new User();
            userObj.UserName = Request.Form["username"];
            userObj.Password = Request.Form["password"];

            var user = Auth.CheckCredentials(userObj);
            if (user != null)
            {
                HttpContext.Session.SetString("FullName", user.FullName);
                HttpContext.Session.SetInt32("LoggedIn", 1);
                HttpContext.Session.SetInt32("Id", user.Id);
                HttpContext.Session.SetInt32("NumOfActionAllowed", user.NumOfActions);
            }
            else
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home");
        }

        public RedirectToActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
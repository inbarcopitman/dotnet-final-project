using System;
using System.Linq;
using ASP.NET_Final_Project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Final_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostLogin(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                var date = DateTime.Today;

                if (user.LoggedInDate < date)
                {
                    user.NumOfActions = 10;
                    user.LoggedInDate = date;
                    _db.SaveChanges();
                }
                else
                {
                    if (user.NumOfActions < 1) return RedirectToAction("Index");
                }

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
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
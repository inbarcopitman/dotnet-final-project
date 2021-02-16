using System.Linq;
using ASP.NET_Final_Project.Data;
using ASP.NET_Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Final_Project.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("Id");
            ViewBag.departments = _db.Departments.Where(x => x.UserId == userId).ToList();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department dep)
        {
            dep.UserId = HttpContext.Session.GetInt32("Id");
            _db.Departments.Add(dep);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var dep = _db.Departments.First(x => x.Id == Id && x.UserId == userId);

            return View("Edit", dep);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department dep)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var department = _db.Departments.FirstOrDefault(x => x.Id == dep.Id && x.UserId == userId);
            if (department != null) department.Name = dep.Name;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var department = _db.Departments.First(x => x.Id == Id && x.UserId == userId);
            if (department != null) _db.Departments.Remove(department);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
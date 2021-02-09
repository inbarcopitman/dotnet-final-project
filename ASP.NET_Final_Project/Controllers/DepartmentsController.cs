using System.Linq;
using ASP.NET_Final_Project.Data;
using ASP.NET_Final_Project.Models;
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
            ViewBag.departments = _db.Departments.ToList(); // TODO get relative to user id

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department dep)
        {
            dep.UserId = 1; // TODO change to user id from session.
            _db.Departments.Add(dep);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var dep = _db.Departments.First(x => x.Id == Id);

            return View("Edit", dep);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department dep)
        {
            var department = _db.Departments.FirstOrDefault(x => x.Id == dep.Id);
            if (department != null) department.Name = dep.Name;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var department = _db.Departments.First(x => x.Id == Id);
            if (department != null) _db.Departments.Remove(department);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
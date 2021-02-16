using System.Linq;
using ASP.NET_Final_Project.Data;
using ASP.NET_Final_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_Final_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("Id");
            ViewBag.employees = _db.Employees.Where(x => x.Department.UserId == userId).ToList();

            return View();
        }

        public IActionResult Add()
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var departments = _db.Departments.Where(x => x.UserId == userId).ToArray();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var employee = _db.Employees.First(x => x.Id == Id && x.Department.UserId == userId);
            ViewBag.Departments = new SelectList(_db.Departments.ToArray(), "Id", "Name");

            return View("Edit", employee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var emp = _db.Employees.FirstOrDefault(x => x.Id == employee.Id && x.Department.UserId == userId);
            if (emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.StartWorkYear = employee.StartWorkYear;
                emp.DepartmentId = employee.DepartmentId;
            }

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var employee = _db.Employees.First(x => x.Id == Id && x.Department.UserId == userId);
            if (employee != null) _db.Employees.Remove(employee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
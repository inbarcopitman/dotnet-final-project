using System.Linq;
using ASP.NET_Final_Project.Data;
using ASP.NET_Final_Project.Models;
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
            ViewBag.employees = _db.Employees.ToList(); // TODO get relative to user id

            return View();
        }

        public IActionResult Add()
        {
            ViewBag.Departments = new SelectList(_db.Departments.ToArray(), "Id", "Name");
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
            var employee = _db.Employees.First(x => x.Id == Id);
            ViewBag.Departments = new SelectList(_db.Departments.ToArray(), "Id", "Name");

            return View("Edit", employee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == employee.Id);
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
            var employee = _db.Employees.First(x => x.Id == Id);
            if (employee != null) _db.Employees.Remove(employee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
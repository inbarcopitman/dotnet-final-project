using System;
using System.Linq;
using ASP.NET_Final_Project.Data;
using ASP.NET_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Final_Project.Controllers
{
    public class ShiftsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ShiftsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var result = _db.Employees
                .Join(_db.EmployeeShifts, // join Model1s and Model2s
                    employee => employee.Id, // from every Model1 take the foreign key Model2Id
                    employeeshift => employeeshift.EmployeeId, // from every Model2 take the primary key Id
                    (employee, employeeshift) => new MyClass // when they match use the matching models to create
                    {
                        // a new object with the following properties
                        SomeProperty = employeeshift.Id,
                        SomeOtherProperty = employee.Id
                    });

            ViewBag.data = result;
            return View();
        }

        public IActionResult AddShift(int Id)
        {
            ViewBag.Employee = _db.Employees.First(x => x.Id == Id);
            return View("AddShift");
        }

        [HttpPost]
        public IActionResult SaveShift(Shift shift)
        {
            var employeeId = Request.Form["EmployeeId"];
            shift.Date = DateTime.Now;
            _db.Shifts.Add(shift);
            _db.SaveChanges();

            var es = new EmployeeShift();
            es.EmployeeId = int.Parse(employeeId);
            es.ShiftId = shift.Id;
            _db.EmployeeShifts.Add(es);
            _db.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }
    }
}
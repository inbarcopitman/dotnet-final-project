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

        public IActionResult AddShift(int Id)
        {
            ViewBag.Employee = _db.Employees.First(x => x.Id == Id);
            return View("AddShift");
        }

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
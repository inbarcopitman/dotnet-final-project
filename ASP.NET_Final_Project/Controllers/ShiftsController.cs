using System.Linq;
using ASP.NET_Final_Project.Data;
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

        //
        // public IActionResult SaveShift(Shift shift)
        // {
        //     // ViewBag.EmployeeId = Id;
        //     // return View("Index");
        // }
    }
}
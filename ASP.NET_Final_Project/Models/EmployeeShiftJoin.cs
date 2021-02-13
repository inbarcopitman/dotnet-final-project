using System;

namespace ASP.NET_Final_Project.Models
{
    public class EmployeeShiftJoin
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
    }
}
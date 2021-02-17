using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Final_Project.Models
{
    public class EmployeeShiftJoin
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiftEnd { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Final_Project.Models
{
    public class Employee
    {
        [Key] [ForeignKey("Employee")] public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StartWorkYear { get; set; }

        [Required] public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
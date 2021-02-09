using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Final_Project.Models
{
    public class Department
    {
        [Key] [ForeignKey("Department")] public int Id { get; set; }
        public string Name { get; set; }

        [Required] public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
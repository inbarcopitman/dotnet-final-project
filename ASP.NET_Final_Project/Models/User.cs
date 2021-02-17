using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Final_Project.Models
{
    public class User
    {
        [Key] [ForeignKey("User")] public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int NumOfActions { get; set; }

        public DateTime? LoggedInDate { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
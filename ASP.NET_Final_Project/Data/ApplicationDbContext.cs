using System;
using ASP.NET_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Final_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "John Doe",
                    UserName = "JohnDoe",
                    Password = "123456",
                    NumOfActions = 20,
                    LoggedInDate = DateTime.Today
                }
            );
        }
    }
}
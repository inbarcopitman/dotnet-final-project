﻿// <auto-generated />

using System;
using ASP.NET_Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ASP.NET_Final_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    internal class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ASP.NET_Final_Project.Models.Department", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .UseIdentityColumn();

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("UserId")
                    .IsRequired()
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Departments");
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.Employee", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .UseIdentityColumn();

                b.Property<int>("DepartmentId")
                    .HasColumnType("int");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("StartWorkYear")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("DepartmentId");

                b.ToTable("Employees");
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.EmployeeShift", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .UseIdentityColumn();

                b.Property<int>("EmployeeId")
                    .HasColumnType("int");

                b.Property<int>("ShiftId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("EmployeeId");

                b.HasIndex("ShiftId");

                b.ToTable("EmployeeShifts");
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.Shift", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .UseIdentityColumn();

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("EndTime")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("StartTime")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.ToTable("Shifts");
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .UseIdentityColumn();

                b.Property<string>("FullName")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime?>("LoggedInDate")
                    .HasColumnType("datetime2");

                b.Property<int>("NumOfActions")
                    .HasColumnType("int");

                b.Property<string>("Password")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserName")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Users");

                b.HasData(
                    new
                    {
                        Id = 1,
                        FullName = "John Doe",
                        LoggedInDate = new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Local),
                        NumOfActions = 20,
                        Password = "123456",
                        UserName = "JohnDoe"
                    });
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.Department", b =>
            {
                b.HasOne("ASP.NET_Final_Project.Models.User", "User")
                    .WithMany("Departments")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.Employee", b =>
            {
                b.HasOne("ASP.NET_Final_Project.Models.Department", "Department")
                    .WithMany("Employees")
                    .HasForeignKey("DepartmentId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Department");
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.EmployeeShift", b =>
            {
                b.HasOne("ASP.NET_Final_Project.Models.Employee", "Employee")
                    .WithMany()
                    .HasForeignKey("EmployeeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ASP.NET_Final_Project.Models.Shift", "Shift")
                    .WithMany()
                    .HasForeignKey("ShiftId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Employee");

                b.Navigation("Shift");
            });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.Department", b => { b.Navigation("Employees"); });

            modelBuilder.Entity("ASP.NET_Final_Project.Models.User", b => { b.Navigation("Departments"); });
#pragma warning restore 612, 618
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Final_Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Shifts",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>("datetime2", nullable: false),
                    StartTime = table.Column<DateTime>("datetime2", nullable: false),
                    EndTime = table.Column<DateTime>("datetime2", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Shifts", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>("nvarchar(max)", nullable: true),
                    UserName = table.Column<string>("nvarchar(max)", nullable: true),
                    Password = table.Column<string>("nvarchar(max)", nullable: true),
                    NumOfActions = table.Column<int>("int", nullable: false),
                    LoggedInDate = table.Column<DateTime>("datetime2", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Departments",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    UserId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        "FK_Departments_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>("nvarchar(max)", nullable: true),
                    LastName = table.Column<string>("nvarchar(max)", nullable: true),
                    StartWorkYear = table.Column<string>("nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        "FK_Employees_Departments_DepartmentId",
                        x => x.DepartmentId,
                        "Departments",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "EmployeeShifts",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>("int", nullable: false),
                    ShiftId = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShifts", x => x.Id);
                    table.ForeignKey(
                        "FK_EmployeeShifts_Employees_EmployeeId",
                        x => x.EmployeeId,
                        "Employees",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_EmployeeShifts_Shifts_ShiftId",
                        x => x.ShiftId,
                        "Shifts",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Users",
                new[] {"Id", "FullName", "LoggedInDate", "NumOfActions", "Password", "UserName"},
                new object[]
                {
                    1, "John Doe", new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Local), 20, "123456", "JohnDoe"
                });

            migrationBuilder.CreateIndex(
                "IX_Departments_UserId",
                "Departments",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_Employees_DepartmentId",
                "Employees",
                "DepartmentId");

            migrationBuilder.CreateIndex(
                "IX_EmployeeShifts_EmployeeId",
                "EmployeeShifts",
                "EmployeeId");

            migrationBuilder.CreateIndex(
                "IX_EmployeeShifts_ShiftId",
                "EmployeeShifts",
                "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "EmployeeShifts");

            migrationBuilder.DropTable(
                "Employees");

            migrationBuilder.DropTable(
                "Shifts");

            migrationBuilder.DropTable(
                "Departments");

            migrationBuilder.DropTable(
                "Users");
        }
    }
}
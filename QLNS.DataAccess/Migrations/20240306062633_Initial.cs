﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QLNS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allowance",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Money = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Labour Hour",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Factor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labour Hour", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    IDposition = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.IDposition);
                });

            migrationBuilder.CreateTable(
                name: "Rank Role",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DayOfHoliday",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDLB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfHoliday", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DayOfHoliday_Labour Hour_IDLB",
                        column: x => x.IDLB,
                        principalTable: "Labour Hour",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Description Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankRoleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description Role", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Description Role_Rank Role_RankRoleID",
                        column: x => x.RankRoleID,
                        principalTable: "Rank Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    IDrank = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RankRoleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.IDrank);
                    table.ForeignKey(
                        name: "FK_Rank_Rank Role_RankRoleID",
                        column: x => x.RankRoleID,
                        principalTable: "Rank Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RankID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PositionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Salary_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "IDposition",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salary_Rank_RankID",
                        column: x => x.RankID,
                        principalTable: "Rank",
                        principalColumn: "IDrank",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 3, 6, 13, 26, 32, 959, DateTimeKind.Local).AddTicks(2641)),
                    Sex = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CIC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SalaryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    URLImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Salary_SalaryID",
                        column: x => x.SalaryID,
                        principalTable: "Salary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllowanceRules",
                columns: table => new
                {
                    AllowanceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowanceRules", x => new { x.AllowanceID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_AllowanceRules_Allowance_AllowanceID",
                        column: x => x.AllowanceID,
                        principalTable: "Allowance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllowanceRules_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee With Allowance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AllowanceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee With Allowance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee With Allowance_Allowance_AllowanceID",
                        column: x => x.AllowanceID,
                        principalTable: "Allowance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee With Allowance_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Labour Contract",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContractSigninDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractTerm = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labour Contract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Labour Contract_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reward_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work Hour",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeesID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LBDID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    HourCheckin = table.Column<int>(type: "int", nullable: false),
                    MinuteCheckin = table.Column<int>(type: "int", nullable: false),
                    HourCheckout = table.Column<int>(type: "int", nullable: false),
                    MinuteCheckout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work Hour", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Work Hour_Employees_EmployeesID",
                        column: x => x.EmployeesID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work Hour_Labour Hour_LBDID",
                        column: x => x.LBDID,
                        principalTable: "Labour Hour",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allowance",
                columns: new[] { "ID", "Money", "Name" },
                values: new object[,]
                {
                    { "1", 300000, "Tiền ăn" },
                    { "2", 500000, "Tiền xăng" }
                });

            migrationBuilder.InsertData(
                table: "Labour Hour",
                columns: new[] { "ID", "Factor", "Name" },
                values: new object[,]
                {
                    { "1", 1, "Ngày Thường" },
                    { "2", 2, "Ngày Lễ Nhỏ" },
                    { "3", 4, "Ngày Lễ " }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "IDposition", "Name" },
                values: new object[,]
                {
                    { "1", "IT" },
                    { "2", "Kế toán" },
                    { "3", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Rank Role",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "1", "Nhan Vien Binh Thuong" },
                    { "2", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "DayOfHoliday",
                columns: new[] { "ID", "Days", "IDLB", "Months", "Name" },
                values: new object[,]
                {
                    { "1", 30, "3", 4, "30/4" },
                    { "2", 1, "3", 5, "1/5" },
                    { "3", 20, "2", 11, "20/11" },
                    { "4", 2, "3", 9, "2/9" },
                    { "5", 1, "3", 1, "1/1" }
                });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "IDrank", "Name", "RankRoleID" },
                values: new object[,]
                {
                    { "1", "Nhân viên", "1" },
                    { "2", "Trưởng phòng", "2" },
                    { "3", "Phó phòng", "2" },
                    { "4", "Tổ trưởng", "2" }
                });

            migrationBuilder.InsertData(
                table: "Salary",
                columns: new[] { "ID", "Money", "PositionID", "RankID" },
                values: new object[,]
                {
                    { "1", 80000m, "1", "1" },
                    { "10", 100000m, "3", "2" },
                    { "11", 950000m, "3", "3" },
                    { "12", 700000m, "3", "4" },
                    { "2", 100000m, "1", "2" },
                    { "3", 70000m, "1", "3" },
                    { "4", 75000m, "1", "4" },
                    { "5", 50000m, "2", "1" },
                    { "6", 110000m, "2", "2" },
                    { "7", 80000m, "2", "3" },
                    { "8", 70000m, "2", "4" },
                    { "9", 60000m, "3", "1" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Active", "Address", "CIC", "DOB", "FirstName", "LastName", "MiddleName", "NumberPhone", "Password", "SalaryID", "Sex", "URLImage" },
                values: new object[,]
                {
                    { "1", "admin", 1, "Texas", "000001", new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", "Dang", "Jonny", "111", "123456", "1", 1, "" },
                    { "2", "admin", 1, "New York", "000002", new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", "Pug", "Khoa", "222", "admin", "2", 1, "" },
                    { "3", "admin", 1, "Thailand", "000002", new DateTime(2002, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", "Thanh", "Tri", "222", "admin", "2", 1, "" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Account", "Active", "Address", "CIC", "DOB", "FirstName", "LastName", "MiddleName", "NumberPhone", "Password", "SalaryID", "URLImage" },
                values: new object[,]
                {
                    { "4", "admin", 1, "New York", "000002", new DateTime(2002, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tran", "Thien", "Minh", "2211232", "admin", "2", "" },
                    { "5", "admin", 1, "Dubai", "000002", new DateTime(2002, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui", "Tgabg", "Manh", "212322", "admin", "2", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceRules_EmployeeID",
                table: "AllowanceRules",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfHoliday_IDLB",
                table: "DayOfHoliday",
                column: "IDLB");

            migrationBuilder.CreateIndex(
                name: "IX_Description Role_RankRoleID",
                table: "Description Role",
                column: "RankRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee With Allowance_AllowanceID",
                table: "Employee With Allowance",
                column: "AllowanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee With Allowance_EmployeeID",
                table: "Employee With Allowance",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SalaryID",
                table: "Employees",
                column: "SalaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Labour Contract_EmployeeID",
                table: "Labour Contract",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rank_RankRoleID",
                table: "Rank",
                column: "RankRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_EmployeeID",
                table: "Reward",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_PositionID",
                table: "Salary",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_RankID",
                table: "Salary",
                column: "RankID");

            migrationBuilder.CreateIndex(
                name: "IX_Work Hour_EmployeesID",
                table: "Work Hour",
                column: "EmployeesID");

            migrationBuilder.CreateIndex(
                name: "IX_Work Hour_LBDID",
                table: "Work Hour",
                column: "LBDID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowanceRules");

            migrationBuilder.DropTable(
                name: "DayOfHoliday");

            migrationBuilder.DropTable(
                name: "Description Role");

            migrationBuilder.DropTable(
                name: "Employee With Allowance");

            migrationBuilder.DropTable(
                name: "Labour Contract");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Work Hour");

            migrationBuilder.DropTable(
                name: "Allowance");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Labour Hour");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "Rank Role");
        }
    }
}

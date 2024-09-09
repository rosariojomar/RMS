using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class PeopleTableAdditionalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateHired",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeContractStatus",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLocation",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeProjects",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeSkills",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeStatus",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeTitle",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfEmployment",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FJLevel",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade_Level",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsBench",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JLPTLevel",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonTitle",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegularizationDate",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ResignationDate",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ZinzaiId",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateHired",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmployeeContractStatus",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmployeeLocation",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmployeeProjects",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmployeeSkills",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmployeeStatus",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmployeeTitle",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EndOfEmployment",
                table: "People");

            migrationBuilder.DropColumn(
                name: "FJLevel",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Grade_Level",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IsBench",
                table: "People");

            migrationBuilder.DropColumn(
                name: "JLPTLevel",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonTitle",
                table: "People");

            migrationBuilder.DropColumn(
                name: "RegularizationDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ResignationDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ZinzaiId",
                table: "People");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdjustIserAcccountModelAndPersonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReference",
                table: "UserAccounts");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsReference",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RBUId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IsReference",
                table: "People");

            migrationBuilder.DropColumn(
                name: "RBUId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "People");

            migrationBuilder.AddColumn<bool>(
                name: "IsReference",
                table: "UserAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

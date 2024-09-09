using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeEmailToPersonClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "People");
        }
    }
}

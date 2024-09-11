using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsTrainerAndIsHR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPolicyCode",
                table: "UserPolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserPolicyDescription",
                table: "UserPolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserPolicyName",
                table: "UserPolicies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsHR",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrainer",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPolicyCode",
                table: "UserPolicies");

            migrationBuilder.DropColumn(
                name: "UserPolicyDescription",
                table: "UserPolicies");

            migrationBuilder.DropColumn(
                name: "UserPolicyName",
                table: "UserPolicies");

            migrationBuilder.DropColumn(
                name: "IsHR",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IsTrainer",
                table: "People");
        }
    }
}

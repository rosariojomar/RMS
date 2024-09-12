using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class TrainingIdToTrainingTransact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "TrainingTransacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "TrainingTransacts");
        }
    }
}

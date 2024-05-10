using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWorkWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Disease_Id",
                table: "Symptoms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Medicine_Id",
                table: "Substances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disease_Id",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "Medicine_Id",
                table: "Substances");
        }
    }
}

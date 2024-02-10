using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjecIntegration.Api.Migrations
{
    /// <inheritdoc />
    public partial class modelUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceCurrent",
                table: "SalleDeTheatres");

            migrationBuilder.AddColumn<int>(
                name: "PlaceMaximum",
                table: "Representations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "placeCurrent",
                table: "Representations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceMaximum",
                table: "Representations");

            migrationBuilder.DropColumn(
                name: "placeCurrent",
                table: "Representations");

            migrationBuilder.AddColumn<int>(
                name: "PlaceCurrent",
                table: "SalleDeTheatres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

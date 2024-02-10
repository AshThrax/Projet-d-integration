using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjecIntegration.Api.Migrations
{
    /// <inheritdoc />
    public partial class Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSalle",
                table: "Pieces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalleDeTheatreId",
                table: "Pieces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_SalleDeTheatreId",
                table: "Pieces",
                column: "SalleDeTheatreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_SalleDeTheatres_SalleDeTheatreId",
                table: "Pieces",
                column: "SalleDeTheatreId",
                principalTable: "SalleDeTheatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_SalleDeTheatres_SalleDeTheatreId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_SalleDeTheatreId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "IdSalle",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "SalleDeTheatreId",
                table: "Pieces");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjecIntegration.Api.Migrations
{
    /// <inheritdoc />
    public partial class Correctionv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_SalleDeTheatres_SalleDeTheatreId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_SalleDeTheatreId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "SalleDeTheatreId",
                table: "Pieces");

            migrationBuilder.AlterColumn<int>(
                name: "Prix",
                table: "Representations",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_IdSalle",
                table: "Pieces",
                column: "IdSalle");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_SalleDeTheatres_IdSalle",
                table: "Pieces",
                column: "IdSalle",
                principalTable: "SalleDeTheatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_SalleDeTheatres_IdSalle",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_IdSalle",
                table: "Pieces");

            migrationBuilder.AlterColumn<decimal>(
                name: "Prix",
                table: "Representations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}

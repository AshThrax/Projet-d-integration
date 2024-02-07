using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjecIntegration.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complexe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complexe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duree = table.Column<TimeSpan>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalleDeTheatres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceMax = table.Column<int>(type: "int", nullable: false),
                    PlaceCurrent = table.Column<int>(type: "int", nullable: false),
                    complexeId = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalleDeTheatres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalleDeTheatres_Complexe_complexeId",
                        column: x => x.complexeId,
                        principalTable: "Complexe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Representations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSalledeTheatre = table.Column<int>(type: "int", nullable: false),
                    IdPiece = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representations_Pieces_IdPiece",
                        column: x => x.IdPiece,
                        principalTable: "Pieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Representations_SalleDeTheatres_IdSalledeTheatre",
                        column: x => x.IdSalledeTheatre,
                        principalTable: "SalleDeTheatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreDePlace = table.Column<int>(type: "int", nullable: false),
                    IdRepresentation = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_Representations_IdRepresentation",
                        column: x => x.IdRepresentation,
                        principalTable: "Representations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_IdRepresentation",
                table: "Commands",
                column: "IdRepresentation");

            migrationBuilder.CreateIndex(
                name: "IX_Representations_IdPiece",
                table: "Representations",
                column: "IdPiece");

            migrationBuilder.CreateIndex(
                name: "IX_Representations_IdSalledeTheatre",
                table: "Representations",
                column: "IdSalledeTheatre");

            migrationBuilder.CreateIndex(
                name: "IX_SalleDeTheatres_complexeId",
                table: "SalleDeTheatres",
                column: "complexeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Representations");

            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "SalleDeTheatres");

            migrationBuilder.DropTable(
                name: "Complexe");
        }
    }
}

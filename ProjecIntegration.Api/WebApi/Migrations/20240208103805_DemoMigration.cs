using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class DemoMigration : Migration
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
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complexe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalleDeTheatres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceMax = table.Column<int>(type: "int", nullable: false),
                    complexeId = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "Pieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSalle = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pieces_SalleDeTheatres_IdSalle",
                        column: x => x.IdSalle,
                        principalTable: "SalleDeTheatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Representations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prix = table.Column<int>(type: "int", nullable: false),
                    Seance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceMaximum = table.Column<int>(type: "int", nullable: false),
                    placeCurrent = table.Column<int>(type: "int", nullable: false),
                    IdSalledeTheatre = table.Column<int>(type: "int", nullable: false),
                    IdPiece = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Representation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Piecetitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Commands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "Commands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_IdRepresentation",
                table: "Commands",
                column: "IdRepresentation");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_IdSalle",
                table: "Pieces",
                column: "IdSalle");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CommandId",
                table: "Tickets",
                column: "CommandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

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

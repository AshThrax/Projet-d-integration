using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class favorisMigration : Migration
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complexe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageRessource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplexeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogue_Complexe_ComplexeId",
                        column: x => x.ComplexeId,
                        principalTable: "Complexe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalleDeTheatres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceMax = table.Column<int>(type: "int", nullable: false),
                    ComplexeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalleDeTheatres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalleDeTheatres_Complexe_ComplexeId",
                        column: x => x.ComplexeId,
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
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: false),
                    FavorisId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pieces_Favoris_FavorisId",
                        column: x => x.FavorisId,
                        principalTable: "Favoris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pieces_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pieces_Theme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siege_SalleDeTheatres_SalleId",
                        column: x => x.SalleId,
                        principalTable: "SalleDeTheatres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CataloguePiece",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogueId = table.Column<int>(type: "int", nullable: false),
                    PieceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataloguePiece", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CataloguePiece_Catalogue_CatalogueId",
                        column: x => x.CatalogueId,
                        principalTable: "Catalogue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CataloguePiece_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
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
                    PlaceCurrent = table.Column<int>(type: "int", nullable: false),
                    SalledeTheatreId = table.Column<int>(type: "int", nullable: false),
                    PieceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representations_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Representations_SalleDeTheatres_SalledeTheatreId",
                        column: x => x.SalledeTheatreId,
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
                    AuthId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreDePlace = table.Column<int>(type: "int", nullable: false),
                    IdRepresentation = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "SiegeCommand",
                columns: table => new
                {
                    SiegeId = table.Column<int>(type: "int", nullable: false),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiegeCommand", x => new { x.SiegeId, x.CommandId });
                    table.ForeignKey(
                        name: "FK_SiegeCommand_Commands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "Commands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiegeCommand_Siege_SiegeId",
                        column: x => x.SiegeId,
                        principalTable: "Siege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogue_ComplexeId",
                table: "Catalogue",
                column: "ComplexeId");

            migrationBuilder.CreateIndex(
                name: "IX_CataloguePiece_CatalogueId",
                table: "CataloguePiece",
                column: "CatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_CataloguePiece_PieceId",
                table: "CataloguePiece",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Commands_IdRepresentation",
                table: "Commands",
                column: "IdRepresentation");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_FavorisId",
                table: "Pieces",
                column: "FavorisId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_ImageId",
                table: "Pieces",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_ThemeId",
                table: "Pieces",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Representations_PieceId",
                table: "Representations",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Representations_SalledeTheatreId",
                table: "Representations",
                column: "SalledeTheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_SalleDeTheatres_ComplexeId",
                table: "SalleDeTheatres",
                column: "ComplexeId");

            migrationBuilder.CreateIndex(
                name: "IX_Siege_SalleId",
                table: "Siege",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_SiegeCommand_CommandId",
                table: "SiegeCommand",
                column: "CommandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CataloguePiece");

            migrationBuilder.DropTable(
                name: "SiegeCommand");

            migrationBuilder.DropTable(
                name: "Catalogue");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Siege");

            migrationBuilder.DropTable(
                name: "Representations");

            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "SalleDeTheatres");

            migrationBuilder.DropTable(
                name: "Favoris");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropTable(
                name: "Complexe");
        }
    }
}

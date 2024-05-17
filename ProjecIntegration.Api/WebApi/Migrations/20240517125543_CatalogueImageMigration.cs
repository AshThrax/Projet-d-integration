using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CatalogueImageMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Catalogue_CatalogueId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_CatalogueId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "EThemePiece",
                table: "Theme");

            migrationBuilder.DropColumn(
                name: "CatalogueId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Pieces");

            migrationBuilder.AddColumn<string>(
                name: "Libelle",
                table: "Theme",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CataloguePiece",
                columns: table => new
                {
                    CatalogueId = table.Column<int>(type: "int", nullable: false),
                    PieceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataloguePiece", x => new { x.PieceId, x.CatalogueId });
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

            migrationBuilder.CreateIndex(
                name: "IX_CataloguePiece_CatalogueId",
                table: "CataloguePiece",
                column: "CatalogueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CataloguePiece");

            migrationBuilder.DropColumn(
                name: "Libelle",
                table: "Theme");

            migrationBuilder.AddColumn<int>(
                name: "EThemePiece",
                table: "Theme",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatalogueId",
                table: "Pieces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Pieces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_CatalogueId",
                table: "Pieces",
                column: "CatalogueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Catalogue_CatalogueId",
                table: "Pieces",
                column: "CatalogueId",
                principalTable: "Catalogue",
                principalColumn: "Id");
        }
    }
}

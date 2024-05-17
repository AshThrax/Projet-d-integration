using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CatalogueImageMigrationv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CataloguePiece_Catalogue_CatalogueId",
                table: "CataloguePiece");

            migrationBuilder.DropForeignKey(
                name: "FK_CataloguePiece_Pieces_PieceId",
                table: "CataloguePiece");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CataloguePiece",
                table: "CataloguePiece");

            migrationBuilder.RenameTable(
                name: "CataloguePiece",
                newName: "cataloguePieces");

            migrationBuilder.RenameIndex(
                name: "IX_CataloguePiece_CatalogueId",
                table: "cataloguePieces",
                newName: "IX_cataloguePieces_CatalogueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cataloguePieces",
                table: "cataloguePieces",
                columns: new[] { "PieceId", "CatalogueId" });

            migrationBuilder.AddForeignKey(
                name: "FK_cataloguePieces_Catalogue_CatalogueId",
                table: "cataloguePieces",
                column: "CatalogueId",
                principalTable: "Catalogue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cataloguePieces_Pieces_PieceId",
                table: "cataloguePieces",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cataloguePieces_Catalogue_CatalogueId",
                table: "cataloguePieces");

            migrationBuilder.DropForeignKey(
                name: "FK_cataloguePieces_Pieces_PieceId",
                table: "cataloguePieces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cataloguePieces",
                table: "cataloguePieces");

            migrationBuilder.RenameTable(
                name: "cataloguePieces",
                newName: "CataloguePiece");

            migrationBuilder.RenameIndex(
                name: "IX_cataloguePieces_CatalogueId",
                table: "CataloguePiece",
                newName: "IX_CataloguePiece_CatalogueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CataloguePiece",
                table: "CataloguePiece",
                columns: new[] { "PieceId", "CatalogueId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CataloguePiece_Catalogue_CatalogueId",
                table: "CataloguePiece",
                column: "CatalogueId",
                principalTable: "Catalogue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CataloguePiece_Pieces_PieceId",
                table: "CataloguePiece",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

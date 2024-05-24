using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SiegeCommandCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiegeCommand");

            migrationBuilder.AddColumn<int>(
                name: "CommandId",
                table: "Siege",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siege_CommandId",
                table: "Siege",
                column: "CommandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siege_Commands_CommandId",
                table: "Siege",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siege_Commands_CommandId",
                table: "Siege");

            migrationBuilder.DropIndex(
                name: "IX_Siege_CommandId",
                table: "Siege");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "Siege");

            migrationBuilder.CreateTable(
                name: "SiegeCommand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    SiegeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiegeCommand", x => x.Id);
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
                name: "IX_SiegeCommand_CommandId",
                table: "SiegeCommand",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_SiegeCommand_SiegeId",
                table: "SiegeCommand",
                column: "SiegeId");
        }
    }
}

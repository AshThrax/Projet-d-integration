using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjecIntegration.Api.Migrations
{
    /// <inheritdoc />
    public partial class pieceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duree",
                table: "Pieces",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duree",
                table: "Pieces",
                type: "time",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class editrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Users",
                type: "decimal(5, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Rates",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Rates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Rates");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Rates",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

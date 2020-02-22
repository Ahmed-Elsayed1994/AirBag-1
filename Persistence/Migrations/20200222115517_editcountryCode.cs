using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class editcountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MobileCountryCodes_MobileCountryCodeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MobileCountryCodeId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "MobileCountryCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryCodeId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MobileCountryCodes_CountryId",
                table: "MobileCountryCodes",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileCountryCodes_Countries_CountryId",
                table: "MobileCountryCodes",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileCountryCodes_Countries_CountryId",
                table: "MobileCountryCodes");

            migrationBuilder.DropIndex(
                name: "IX_MobileCountryCodes_CountryId",
                table: "MobileCountryCodes");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "MobileCountryCodes");

            migrationBuilder.DropColumn(
                name: "CountryCodeId",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MobileCountryCodeId",
                table: "Users",
                column: "MobileCountryCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MobileCountryCodes_MobileCountryCodeId",
                table: "Users",
                column: "MobileCountryCodeId",
                principalTable: "MobileCountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

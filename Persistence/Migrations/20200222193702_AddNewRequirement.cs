using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddNewRequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CountryCodeId",
                table: "Countries");

            migrationBuilder.AddColumn<bool>(
                name: "CarrierMore",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverPictureFileId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RemeberMe",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SenderMore",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByUserId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDateTime",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ApprovedUserId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Boost",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeTakeOff",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Dscription",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ManagementApprovedStatusId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestApprovedStatusId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByUserId",
                table: "Bags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedUserId",
                table: "Bags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagementApprovedStatusId",
                table: "Bags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestApprovedStatusId",
                table: "Bags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalityId",
                table: "Users",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ApprovedUserId",
                table: "Items",
                column: "ApprovedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ManagementApprovedStatusId",
                table: "Items",
                column: "ManagementApprovedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RequestApprovedStatusId",
                table: "Items",
                column: "RequestApprovedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bags_ApprovedUserId",
                table: "Bags",
                column: "ApprovedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bags_ManagementApprovedStatusId",
                table: "Bags",
                column: "ManagementApprovedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bags_RequestApprovedStatusId",
                table: "Bags",
                column: "RequestApprovedStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_Users_ApprovedUserId",
                table: "Bags",
                column: "ApprovedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_Status_ManagementApprovedStatusId",
                table: "Bags",
                column: "ManagementApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_Status_RequestApprovedStatusId",
                table: "Bags",
                column: "RequestApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_ApprovedUserId",
                table: "Items",
                column: "ApprovedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Status_ManagementApprovedStatusId",
                table: "Items",
                column: "ManagementApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Status_RequestApprovedStatusId",
                table: "Items",
                column: "RequestApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Nationality_NationalityId",
                table: "Users",
                column: "NationalityId",
                principalTable: "Nationality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bags_Users_ApprovedUserId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Bags_Status_ManagementApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Bags_Status_RequestApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_ApprovedUserId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Status_ManagementApprovedStatusId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Status_RequestApprovedStatusId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Nationality_NationalityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NationalityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Items_ApprovedUserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ManagementApprovedStatusId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_RequestApprovedStatusId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Bags_ApprovedUserId",
                table: "Bags");

            migrationBuilder.DropIndex(
                name: "IX_Bags_ManagementApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropIndex(
                name: "IX_Bags_RequestApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "CarrierMore",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CoverPictureFileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RemeberMe",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SenderMore",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ApprovedDateTime",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ApprovedUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ArrivalDateTime",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Boost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DateTimeTakeOff",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Dscription",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ManagementApprovedStatusId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RequestApprovedStatusId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "ApprovedUserId",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "ManagementApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropColumn(
                name: "RequestApprovedStatusId",
                table: "Bags");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryCodeId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

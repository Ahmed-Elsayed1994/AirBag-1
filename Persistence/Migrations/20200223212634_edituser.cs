using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class edituser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bags_AirPortCompanies_AirPortCompanyId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Bags_Status_ManagementApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Bags_Status_RequestApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Status_ManagementApprovedStatusId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Status_RequestApprovedStatusId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Actions_ActionId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "MobileCountryCodeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ActionId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestApprovedStatusId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ManagementApprovedStatusId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemCategoryId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByUserId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestApprovedStatusId",
                table: "Bags",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ManagementApprovedStatusId",
                table: "Bags",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByUserId",
                table: "Bags",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AirPortCompanyId",
                table: "Bags",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_AirPortCompanies_AirPortCompanyId",
                table: "Bags",
                column: "AirPortCompanyId",
                principalTable: "AirPortCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_Status_ManagementApprovedStatusId",
                table: "Bags",
                column: "ManagementApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_Status_RequestApprovedStatusId",
                table: "Bags",
                column: "RequestApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Status_ManagementApprovedStatusId",
                table: "Items",
                column: "ManagementApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Status_RequestApprovedStatusId",
                table: "Items",
                column: "RequestApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Actions_ActionId",
                table: "Requests",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bags_AirPortCompanies_AirPortCompanyId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Bags_Status_ManagementApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Bags_Status_RequestApprovedStatusId",
                table: "Bags");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Status_ManagementApprovedStatusId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Status_RequestApprovedStatusId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Actions_ActionId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "MobileCountryCodeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ActionId",
                table: "Requests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestApprovedStatusId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManagementApprovedStatusId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemCategoryId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByUserId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestApprovedStatusId",
                table: "Bags",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManagementApprovedStatusId",
                table: "Bags",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByUserId",
                table: "Bags",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AirPortCompanyId",
                table: "Bags",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_AirPortCompanies_AirPortCompanyId",
                table: "Bags",
                column: "AirPortCompanyId",
                principalTable: "AirPortCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_Status_ManagementApprovedStatusId",
                table: "Bags",
                column: "ManagementApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bags_Status_RequestApprovedStatusId",
                table: "Bags",
                column: "RequestApprovedStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Actions_ActionId",
                table: "Requests",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

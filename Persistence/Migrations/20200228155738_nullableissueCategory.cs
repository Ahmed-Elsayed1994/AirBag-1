using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class nullableissueCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueCategories_IssueCategoryId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "IssueCategoryId",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueCategories_IssueCategoryId",
                table: "Issues",
                column: "IssueCategoryId",
                principalTable: "IssueCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueCategories_IssueCategoryId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "IssueCategoryId",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueCategories_IssueCategoryId",
                table: "Issues",
                column: "IssueCategoryId",
                principalTable: "IssueCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

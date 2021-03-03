using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ExamTextReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "ExamImage",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Alignment",
                table: "ExamImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageSize",
                table: "ExamImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ImageTextId",
                table: "ExamImage",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamImage_ImageTextId",
                table: "ExamImage",
                column: "ImageTextId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamImage_ExamText_ImageTextId",
                table: "ExamImage",
                column: "ImageTextId",
                principalTable: "ExamText",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamImage_ExamText_ImageTextId",
                table: "ExamImage");

            migrationBuilder.DropIndex(
                name: "IX_ExamImage_ImageTextId",
                table: "ExamImage");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "ExamImage");

            migrationBuilder.DropColumn(
                name: "ImageSize",
                table: "ExamImage");

            migrationBuilder.DropColumn(
                name: "ImageTextId",
                table: "ExamImage");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ExamImage",
                newName: "Desctiption");
        }
    }
}

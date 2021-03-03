using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class imageSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamImage_ExamText_ImageTextId",
                table: "ExamImage");

            migrationBuilder.DropIndex(
                name: "IX_ExamImage_ImageTextId",
                table: "ExamImage");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExamImage");

            migrationBuilder.DropColumn(
                name: "ImageTextId",
                table: "ExamImage");

            migrationBuilder.AlterColumn<string>(
                name: "ImageSize",
                table: "ExamImage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageSize",
                table: "ExamImage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExamImage",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}

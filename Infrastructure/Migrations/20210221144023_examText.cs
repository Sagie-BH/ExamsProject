using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class examText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "ExamText",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Bold",
                table: "ExamText",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ExamText",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FontSize",
                table: "ExamText",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Italic",
                table: "ExamText",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Underlined",
                table: "ExamText",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "ExamText");

            migrationBuilder.DropColumn(
                name: "Bold",
                table: "ExamText");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ExamText");

            migrationBuilder.DropColumn(
                name: "FontSize",
                table: "ExamText");

            migrationBuilder.DropColumn(
                name: "Italic",
                table: "ExamText");

            migrationBuilder.DropColumn(
                name: "Underlined",
                table: "ExamText");
        }
    }
}

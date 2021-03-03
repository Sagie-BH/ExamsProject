using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class NoQType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");

            migrationBuilder.AddColumn<long>(
                name: "QuestionTextId",
                table: "Questions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTextId",
                table: "Questions",
                column: "QuestionTextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ExamText_QuestionTextId",
                table: "Questions",
                column: "QuestionTextId",
                principalTable: "ExamText",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ExamText_QuestionTextId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionTextId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionTextId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

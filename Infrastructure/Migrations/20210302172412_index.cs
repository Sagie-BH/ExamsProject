using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_QuestionSubjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionSubjectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionSubjectId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "ExamText",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "ExamImage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "ExamText");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "ExamImage");

            migrationBuilder.AddColumn<long>(
                name: "QuestionSubjectId",
                table: "Questions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionSubjectId",
                table: "Questions",
                column: "QuestionSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_QuestionSubjectId",
                table: "Questions",
                column: "QuestionSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

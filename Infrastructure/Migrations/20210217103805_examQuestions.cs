using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class examQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.AddColumn<long>(
                name: "AppExamId",
                table: "Questions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "QuestionSubjectId",
                table: "Questions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AppExamId",
                table: "Questions",
                column: "AppExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionSubjectId",
                table: "Questions",
                column: "QuestionSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_AppExamId",
                table: "Questions",
                column: "AppExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_QuestionSubjectId",
                table: "Questions",
                column: "QuestionSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_AppExamId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_QuestionSubjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AppExamId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionSubjectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AppExamId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionSubjectId",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    ExamId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => new { x.ExamId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId");
        }
    }
}

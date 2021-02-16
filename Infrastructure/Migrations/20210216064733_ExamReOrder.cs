using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ExamReOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamImage_Questions_QuestionObjectId",
                table: "ExamImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Tips",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestionObjectId",
                table: "ExamImage",
                newName: "AppExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamImage_QuestionObjectId",
                table: "ExamImage",
                newName: "IX_ExamImage_AppExamId");

            migrationBuilder.CreateTable(
                name: "ExamText",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppExamId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamText_Exams_AppExamId",
                        column: x => x.AppExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamText_AppExamId",
                table: "ExamText",
                column: "AppExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamImage_Exams_AppExamId",
                table: "ExamImage",
                column: "AppExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamImage_Exams_AppExamId",
                table: "ExamImage");

            migrationBuilder.DropTable(
                name: "ExamText");

            migrationBuilder.RenameColumn(
                name: "AppExamId",
                table: "ExamImage",
                newName: "QuestionObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamImage_AppExamId",
                table: "ExamImage",
                newName: "IX_ExamImage_QuestionObjectId");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubjectId",
                table: "Questions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tips",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamImage_Questions_QuestionObjectId",
                table: "ExamImage",
                column: "QuestionObjectId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

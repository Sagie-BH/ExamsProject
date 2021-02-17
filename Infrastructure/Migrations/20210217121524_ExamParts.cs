using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ExamParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionOption");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Questions",
                newName: "QuestionText");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "QuestionTimeLimit",
                table: "Questions",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AnswerOption",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRightAnswer = table.Column<bool>(type: "bit", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionObjectId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerOption_Questions_QuestionObjectId",
                        column: x => x.QuestionObjectId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOption_QuestionObjectId",
                table: "AnswerOption",
                column: "QuestionObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerOption");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestionText",
                table: "Questions",
                newName: "Question");

            migrationBuilder.AlterColumn<DateTime>(
                name: "QuestionTimeLimit",
                table: "Questions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionOption",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRightAnswer = table.Column<bool>(type: "bit", nullable: false),
                    QuestionObjectId = table.Column<long>(type: "bigint", nullable: true),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOption_Questions_QuestionObjectId",
                        column: x => x.QuestionObjectId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOption_QuestionObjectId",
                table: "QuestionOption",
                column: "QuestionObjectId");
        }
    }
}

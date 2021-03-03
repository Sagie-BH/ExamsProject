using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class QObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionCompleted",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SuccessRate",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "QuestionCompleted",
                table: "Questions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SuccessRate",
                table: "Questions",
                type: "float",
                nullable: true);
        }
    }
}

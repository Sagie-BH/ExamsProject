using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class @try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClassRoomId",
                table: "Subjects",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassRoomId",
                table: "Subjects",
                column: "ClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_ClassRooms_ClassRoomId",
                table: "Subjects",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_ClassRooms_ClassRoomId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ClassRoomId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Subjects");
        }
    }
}

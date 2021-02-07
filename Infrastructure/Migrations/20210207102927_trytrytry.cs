using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class trytrytry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ClassRoomSubject",
                columns: table => new
                {
                    ClassRoomsId = table.Column<long>(type: "bigint", nullable: false),
                    SubjectsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomSubject", x => new { x.ClassRoomsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_ClassRoomSubject_ClassRooms_ClassRoomsId",
                        column: x => x.ClassRoomsId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomSubject_SubjectsId",
                table: "ClassRoomSubject",
                column: "SubjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRoomSubject");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Concepts.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    C_Cost = table.Column<int>(type: "int", nullable: false),
                    studentS_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.C_Id);
                    table.ForeignKey(
                        name: "FK_Courses_Students_studentS_ID",
                        column: x => x.studentS_ID,
                        principalTable: "Students",
                        principalColumn: "S_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_studentS_ID",
                table: "Courses",
                column: "studentS_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}

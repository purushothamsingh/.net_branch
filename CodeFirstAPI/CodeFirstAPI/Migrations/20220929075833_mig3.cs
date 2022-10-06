using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstAPI.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Studen_s",
                table: "Studen_s");

            migrationBuilder.RenameTable(
                name: "Studen_s",
                newName: "Studen_Ts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studen_Ts",
                table: "Studen_Ts",
                column: "Studen_tId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Studen_Ts",
                table: "Studen_Ts");

            migrationBuilder.RenameTable(
                name: "Studen_Ts",
                newName: "Studen_s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studen_s",
                table: "Studen_s",
                column: "Studen_tId");
        }
    }
}

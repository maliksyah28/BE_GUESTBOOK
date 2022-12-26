using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class ChangeKehadiran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kehadiaran",
                table: "Guest_Books",
                newName: "Kehadiran");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kehadiran",
                table: "Guest_Books",
                newName: "Kehadiaran");
        }
    }
}

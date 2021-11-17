using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Archives.Data.Migrations
{
    public partial class alterschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Storage");

            migrationBuilder.RenameTable(
                name: "Archive",
                schema: "Archive",
                newName: "Archive",
                newSchema: "Storage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Archive");

            migrationBuilder.RenameTable(
                name: "Archive",
                schema: "Storage",
                newName: "Archive",
                newSchema: "Archive");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Archives.Data.Migrations
{
    public partial class alteraçãodocampoentityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EntityId",
                schema: "Archive",
                table: "Archive",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EntityId",
                schema: "Archive",
                table: "Archive",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

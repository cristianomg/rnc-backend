using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class InsertHistoric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 21, 53, 26, 195, DateTimeKind.Local).AddTicks(8478),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 870, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 21, 53, 26, 200, DateTimeKind.Local).AddTicks(1761),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 875, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.CreateTable(
                name: "Historic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Entity = table.Column<string>(type: "text", nullable: false),
                    Values = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historic", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 53, 26, 203, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 53, 26, 203, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 53, 26, 203, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 53, 26, 203, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 53, 26, 203, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 53, 26, 203, DateTimeKind.Local).AddTicks(3402));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historic");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 870, DateTimeKind.Local).AddTicks(2806),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 21, 53, 26, 195, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 875, DateTimeKind.Local).AddTicks(143),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 21, 53, 26, 200, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 42, 17, 878, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 42, 17, 878, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 42, 17, 878, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 42, 17, 878, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 42, 17, 878, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 21, 42, 17, 878, DateTimeKind.Local).AddTicks(2205));
        }
    }
}

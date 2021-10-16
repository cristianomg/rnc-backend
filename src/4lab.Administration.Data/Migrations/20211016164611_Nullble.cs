using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4lab.Administration.Data.Migrations
{
    public partial class Nullble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 13, 46, 10, 84, DateTimeKind.Local).AddTicks(7543),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 789, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 13, 46, 10, 131, DateTimeKind.Local).AddTicks(9420),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 798, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 13, 46, 10, 160, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 13, 46, 10, 161, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 13, 46, 10, 161, DateTimeKind.Local).AddTicks(251));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 13, 46, 10, 161, DateTimeKind.Local).AddTicks(257));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 789, DateTimeKind.Local).AddTicks(7732),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 16, 13, 46, 10, 84, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 798, DateTimeKind.Local).AddTicks(1401),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 16, 13, 46, 10, 131, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 55, 45, 814, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 55, 45, 814, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 55, 45, 814, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 55, 45, 814, DateTimeKind.Local).AddTicks(9300));
        }
    }
}

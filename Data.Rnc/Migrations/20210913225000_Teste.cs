using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Rnc.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 19, 49, 59, 908, DateTimeKind.Local).AddTicks(8104),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 803, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 19, 49, 59, 918, DateTimeKind.Local).AddTicks(3367),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 810, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 49, 59, 924, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 49, 59, 924, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 49, 59, 924, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 49, 59, 923, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 49, 59, 924, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 49, 59, 924, DateTimeKind.Local).AddTicks(912));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 803, DateTimeKind.Local).AddTicks(6958),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 19, 49, 59, 908, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 810, DateTimeKind.Local).AddTicks(9011),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 19, 49, 59, 918, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 815, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 815, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 815, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 814, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 814, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 814, DateTimeKind.Local).AddTicks(8409));
        }
    }
}

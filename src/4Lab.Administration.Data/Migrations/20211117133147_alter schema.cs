using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4lab.Administration.Data.Migrations
{
    public partial class alterschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 10, 31, 46, 588, DateTimeKind.Local).AddTicks(7689),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 789, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 10, 31, 46, 593, DateTimeKind.Local).AddTicks(9453),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 798, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 31, 46, 602, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 31, 46, 602, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 31, 46, 602, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 31, 46, 602, DateTimeKind.Local).AddTicks(6827));
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
                oldDefaultValue: new DateTime(2021, 11, 17, 10, 31, 46, 588, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 798, DateTimeKind.Local).AddTicks(1401),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 11, 17, 10, 31, 46, 593, DateTimeKind.Local).AddTicks(9453));

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

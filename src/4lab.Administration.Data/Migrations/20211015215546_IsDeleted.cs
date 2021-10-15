using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4lab.Administration.Data.Migrations
{
    public partial class IsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Administration",
                table: "UserPermission",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 789, DateTimeKind.Local).AddTicks(7732),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 634, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Administration",
                table: "UserAuth",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 798, DateTimeKind.Local).AddTicks(1401),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 648, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Administration",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Administration",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Administration",
                table: "UserAuth");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Administration",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 634, DateTimeKind.Local).AddTicks(1752),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 789, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 648, DateTimeKind.Local).AddTicks(9097),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 55, 45, 798, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 20, 29, 31, 668, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 20, 29, 31, 668, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 20, 29, 31, 668, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 20, 29, 31, 668, DateTimeKind.Local).AddTicks(6352));
        }
    }
}

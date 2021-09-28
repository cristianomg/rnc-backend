using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4lab.Administration.Data.Migrations
{
    public partial class alterseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 634, DateTimeKind.Local).AddTicks(1752),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 21, 14, 12, 36, 571, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 648, DateTimeKind.Local).AddTicks(9097),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 21, 14, 12, 36, 579, DateTimeKind.Local).AddTicks(7302));

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
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 9, 28, 20, 29, 31, 668, DateTimeKind.Local).AddTicks(5712), "ResponsibleFS" });

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 9, 28, 20, 29, 31, 668, DateTimeKind.Local).AddTicks(6345), "ResponsibleT" });

            migrationBuilder.InsertData(
                schema: "Administration",
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 4, true, new DateTime(2021, 9, 28, 20, 29, 31, 668, DateTimeKind.Local).AddTicks(6352), null, "QualityAnalist", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 14, 12, 36, 571, DateTimeKind.Local).AddTicks(5763),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 634, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Administration",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 14, 12, 36, 579, DateTimeKind.Local).AddTicks(7302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 28, 20, 29, 31, 648, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 21, 14, 12, 36, 587, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 9, 21, 14, 12, 36, 587, DateTimeKind.Local).AddTicks(8418), "Supervisor" });

            migrationBuilder.UpdateData(
                schema: "Administration",
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 9, 21, 14, 12, 36, 587, DateTimeKind.Local).AddTicks(8927), "QualityBiomedical" });
        }
    }
}

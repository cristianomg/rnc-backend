using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Rnc.Migrations
{
    public partial class InsercaoDaPendenciaDasOcorrencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 8, 20, 10, 12, 826, DateTimeKind.Local).AddTicks(5688),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 382, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 8, 20, 10, 12, 831, DateTimeKind.Local).AddTicks(1488),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 392, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.AddColumn<int>(
                name: "OcurrencePendency",
                table: "NonComplianceRegister",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 20, 10, 12, 835, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 20, 10, 12, 835, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 20, 10, 12, 835, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 20, 10, 12, 834, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 20, 10, 12, 834, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 20, 10, 12, 834, DateTimeKind.Local).AddTicks(6385));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OcurrencePendency",
                table: "NonComplianceRegister");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 382, DateTimeKind.Local).AddTicks(5424),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 8, 20, 10, 12, 826, DateTimeKind.Local).AddTicks(5688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 392, DateTimeKind.Local).AddTicks(1398),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 8, 20, 10, 12, 831, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 397, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(1269));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Rnc.Migrations
{
    public partial class InserindoTabelaDeHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 870, DateTimeKind.Local).AddTicks(2806),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 677, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 875, DateTimeKind.Local).AddTicks(143),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 682, DateTimeKind.Local).AddTicks(205));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 677, DateTimeKind.Local).AddTicks(9078),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 870, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 682, DateTimeKind.Local).AddTicks(205),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 21, 42, 17, 875, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 19, 25, 54, 685, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 19, 25, 54, 685, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 19, 25, 54, 685, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 19, 25, 54, 685, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 19, 25, 54, 685, DateTimeKind.Local).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 25, 19, 25, 54, 685, DateTimeKind.Local).AddTicks(1232));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class altercolumnpeopleEnvolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PeopleInvolved",
                table: "OccurrenceRegister",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 27, 7, 561, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 27, 7, 564, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 27, 7, 565, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 27, 7, 565, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 27, 7, 565, DateTimeKind.Local).AddTicks(1930));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PeopleInvolved",
                table: "OccurrenceRegister",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 15, 38, 15, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 15, 38, 18, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 15, 38, 18, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 15, 38, 18, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 12, 15, 38, 18, DateTimeKind.Local).AddTicks(6328));
        }
    }
}

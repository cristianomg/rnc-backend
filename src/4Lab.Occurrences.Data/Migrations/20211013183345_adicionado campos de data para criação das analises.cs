using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class adicionadocamposdedataparacriaçãodasanalises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOcurrenceRisk",
                table: "OccurrenceRegister",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedRootCauseAnalysis",
                table: "OccurrenceRegister",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedVerificatoinOfEffectiveness",
                table: "OccurrenceRegister",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 526, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(6408));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOcurrenceRisk",
                table: "OccurrenceRegister");

            migrationBuilder.DropColumn(
                name: "CreatedRootCauseAnalysis",
                table: "OccurrenceRegister");

            migrationBuilder.DropColumn(
                name: "CreatedVerificatoinOfEffectiveness",
                table: "OccurrenceRegister");

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 29, 10, 40, 25, 0, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 29, 10, 40, 25, 8, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 29, 10, 40, 25, 8, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 29, 10, 40, 25, 8, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 29, 10, 40, 25, 8, DateTimeKind.Local).AddTicks(2708));
        }
    }
}

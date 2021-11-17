using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class alterschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Occurrences");

            migrationBuilder.RenameTable(
                name: "VerificationOfEffectiveness",
                newName: "VerificationOfEffectiveness",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "TypeOccurrence",
                newName: "TypeOccurrence",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "Setor",
                newName: "Setor",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "RootCauseAnalysis",
                newName: "RootCauseAnalysis",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "OccurrenceRisk",
                newName: "OccurrenceRisk",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "OccurrenceRegister",
                newName: "OccurrenceRegister",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "OccurrenceOccurrenceRegister",
                newName: "OccurrenceOccurrenceRegister",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "OccurrenceClassification",
                newName: "OccurrenceClassification",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "Occurrence",
                newName: "Occurrence",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "FiveWhat",
                newName: "FiveWhat",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "ActionPlainResponse",
                newName: "ActionPlainResponse",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "ActionPlainQuestion",
                newName: "ActionPlainQuestion",
                newSchema: "Occurrences");

            migrationBuilder.RenameTable(
                name: "ActionPlain",
                newName: "ActionPlain",
                newSchema: "Occurrences");

            migrationBuilder.UpdateData(
                schema: "Occurrences",
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 26, 8, 898, DateTimeKind.Local).AddTicks(8735));

            migrationBuilder.UpdateData(
                schema: "Occurrences",
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 26, 8, 902, DateTimeKind.Local).AddTicks(1236));

            migrationBuilder.UpdateData(
                schema: "Occurrences",
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 26, 8, 902, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                schema: "Occurrences",
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 26, 8, 902, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                schema: "Occurrences",
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 17, 10, 26, 8, 902, DateTimeKind.Local).AddTicks(8950));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "VerificationOfEffectiveness",
                schema: "Occurrences",
                newName: "VerificationOfEffectiveness");

            migrationBuilder.RenameTable(
                name: "TypeOccurrence",
                schema: "Occurrences",
                newName: "TypeOccurrence");

            migrationBuilder.RenameTable(
                name: "Setor",
                schema: "Occurrences",
                newName: "Setor");

            migrationBuilder.RenameTable(
                name: "RootCauseAnalysis",
                schema: "Occurrences",
                newName: "RootCauseAnalysis");

            migrationBuilder.RenameTable(
                name: "OccurrenceRisk",
                schema: "Occurrences",
                newName: "OccurrenceRisk");

            migrationBuilder.RenameTable(
                name: "OccurrenceRegister",
                schema: "Occurrences",
                newName: "OccurrenceRegister");

            migrationBuilder.RenameTable(
                name: "OccurrenceOccurrenceRegister",
                schema: "Occurrences",
                newName: "OccurrenceOccurrenceRegister");

            migrationBuilder.RenameTable(
                name: "OccurrenceClassification",
                schema: "Occurrences",
                newName: "OccurrenceClassification");

            migrationBuilder.RenameTable(
                name: "Occurrence",
                schema: "Occurrences",
                newName: "Occurrence");

            migrationBuilder.RenameTable(
                name: "FiveWhat",
                schema: "Occurrences",
                newName: "FiveWhat");

            migrationBuilder.RenameTable(
                name: "ActionPlainResponse",
                schema: "Occurrences",
                newName: "ActionPlainResponse");

            migrationBuilder.RenameTable(
                name: "ActionPlainQuestion",
                schema: "Occurrences",
                newName: "ActionPlainQuestion");

            migrationBuilder.RenameTable(
                name: "ActionPlain",
                schema: "Occurrences",
                newName: "ActionPlain");

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
    }
}

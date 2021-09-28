using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class alteraçãodotipodeocorrencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occurrence_TypeOccurrence_OccurrenceTypeId",
                table: "Occurrence");

            migrationBuilder.DropIndex(
                name: "IX_Occurrence_OccurrenceTypeId",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "OccurrenceTypeId",
                table: "Occurrence");

            migrationBuilder.AddColumn<int>(
                name: "OccurrenceTypeId",
                table: "OccurrenceRegister",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OccurrenceTypeName" },
                values: new object[] { new DateTime(2021, 9, 28, 11, 1, 26, 597, DateTimeKind.Local).AddTicks(5831), "De Processo" });

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OccurrenceTypeName" },
                values: new object[] { new DateTime(2021, 9, 28, 11, 1, 26, 603, DateTimeKind.Local).AddTicks(8632), "De Auditoria" });

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OccurrenceTypeName" },
                values: new object[] { new DateTime(2021, 9, 28, 11, 1, 26, 603, DateTimeKind.Local).AddTicks(9824), "Reclamação de cliente" });

            migrationBuilder.InsertData(
                table: "TypeOccurrence",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "OccurrenceTypeName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, true, new DateTime(2021, 9, 28, 11, 1, 26, 604, DateTimeKind.Local).AddTicks(578), null, "De Indicador", null, null },
                    { 5, true, new DateTime(2021, 9, 28, 11, 1, 26, 604, DateTimeKind.Local).AddTicks(1231), null, "Análise de Risco", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceRegister_OccurrenceTypeId",
                table: "OccurrenceRegister",
                column: "OccurrenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_TypeOccurrence_OccurrenceTypeId",
                table: "OccurrenceRegister",
                column: "OccurrenceTypeId",
                principalTable: "TypeOccurrence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_TypeOccurrence_OccurrenceTypeId",
                table: "OccurrenceRegister");

            migrationBuilder.DropIndex(
                name: "IX_OccurrenceRegister_OccurrenceTypeId",
                table: "OccurrenceRegister");

            migrationBuilder.DeleteData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "OccurrenceTypeId",
                table: "OccurrenceRegister");

            migrationBuilder.AddColumn<int>(
                name: "OccurrenceTypeId",
                table: "Occurrence",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OccurrenceTypeName" },
                values: new object[] { new DateTime(2021, 9, 23, 18, 21, 56, 75, DateTimeKind.Local).AddTicks(1592), "Pre-Analítica" });

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OccurrenceTypeName" },
                values: new object[] { new DateTime(2021, 9, 23, 18, 21, 56, 87, DateTimeKind.Local).AddTicks(522), "Analítica" });

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OccurrenceTypeName" },
                values: new object[] { new DateTime(2021, 9, 23, 18, 21, 56, 87, DateTimeKind.Local).AddTicks(4154), "Pos-Analítica" });

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_OccurrenceTypeId",
                table: "Occurrence",
                column: "OccurrenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Occurrence_TypeOccurrence_OccurrenceTypeId",
                table: "Occurrence",
                column: "OccurrenceTypeId",
                principalTable: "TypeOccurrence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

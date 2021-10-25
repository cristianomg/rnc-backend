using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class altercolumnsetorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister");

            migrationBuilder.AlterColumn<int>(
                name: "SetorId",
                table: "OccurrenceRegister",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister");

            migrationBuilder.AlterColumn<int>(
                name: "SetorId",
                table: "OccurrenceRegister",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 542, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

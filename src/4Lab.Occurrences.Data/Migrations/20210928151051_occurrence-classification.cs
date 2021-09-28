using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class occurrenceclassification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OccurrenceClassificationId",
                table: "OccurrenceRegister",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OccurrenceClassification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceClassification", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 12, 10, 50, 748, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 12, 10, 50, 754, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 12, 10, 50, 755, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 12, 10, 50, 755, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 12, 10, 50, 755, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceRegister_OccurrenceClassificationId",
                table: "OccurrenceRegister",
                column: "OccurrenceClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_OccurrenceClassification_OccurrenceClass~",
                table: "OccurrenceRegister",
                column: "OccurrenceClassificationId",
                principalTable: "OccurrenceClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_OccurrenceClassification_OccurrenceClass~",
                table: "OccurrenceRegister");

            migrationBuilder.DropTable(
                name: "OccurrenceClassification");

            migrationBuilder.DropIndex(
                name: "IX_OccurrenceRegister_OccurrenceClassificationId",
                table: "OccurrenceRegister");

            migrationBuilder.DropColumn(
                name: "OccurrenceClassificationId",
                table: "OccurrenceRegister");

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 11, 1, 26, 597, DateTimeKind.Local).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 11, 1, 26, 603, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 11, 1, 26, 603, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 11, 1, 26, 604, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 28, 11, 1, 26, 604, DateTimeKind.Local).AddTicks(1231));
        }
    }
}

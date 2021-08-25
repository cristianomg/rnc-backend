using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Rnc.Migrations
{
    public partial class InserindoCamposDeControle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserPermission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserPermission",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 677, DateTimeKind.Local).AddTicks(9078),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 5, 2, 19, 3, 17, 476, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserAuth",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserAuth",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 682, DateTimeKind.Local).AddTicks(205),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 5, 2, 19, 3, 17, 488, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TypeNonCompliance",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TypeNonCompliance",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Setor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Setor",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RootCauseAnalysis",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "RootCauseAnalysis",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NonComplianceRegister",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "NonComplianceRegister",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NonCompliance",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "NonCompliance",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ActionPlainResponse",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ActionPlainResponse",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ActionPlainQuestion",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ActionPlainQuestion",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ActionPlain",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ActionPlain",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserAuth");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserAuth");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TypeNonCompliance");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TypeNonCompliance");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Setor");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Setor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RootCauseAnalysis");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "RootCauseAnalysis");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NonComplianceRegister");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "NonComplianceRegister");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NonCompliance");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "NonCompliance");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ActionPlainResponse");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ActionPlainResponse");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ActionPlainQuestion");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ActionPlainQuestion");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ActionPlain");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ActionPlain");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 19, 3, 17, 476, DateTimeKind.Local).AddTicks(8063),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 677, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 19, 3, 17, 488, DateTimeKind.Local).AddTicks(1165),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 25, 19, 25, 54, 682, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.InsertData(
                table: "Setor",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "SupervisorId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 5, 2, 19, 3, 17, 498, DateTimeKind.Local).AddTicks(1773), "Coleta", null, null },
                    { 2, true, new DateTime(2021, 5, 2, 19, 3, 17, 498, DateTimeKind.Local).AddTicks(5417), "Microbiologia", null, null },
                    { 3, true, new DateTime(2021, 5, 2, 19, 3, 17, 498, DateTimeKind.Local).AddTicks(5529), "Parasitologia", null, null },
                    { 4, true, new DateTime(2021, 5, 2, 19, 3, 17, 498, DateTimeKind.Local).AddTicks(5537), "Imunologia", null, null },
                    { 5, true, new DateTime(2021, 5, 2, 19, 3, 17, 498, DateTimeKind.Local).AddTicks(5541), "Hematologia", null, null },
                    { 6, true, new DateTime(2021, 5, 2, 19, 3, 17, 498, DateTimeKind.Local).AddTicks(5555), "Triagem", null, null }
                });

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 19, 3, 17, 499, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 19, 3, 17, 499, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 19, 3, 17, 499, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 19, 3, 17, 494, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 19, 3, 17, 494, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 19, 3, 17, 494, DateTimeKind.Local).AddTicks(6890));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class alterarchiveentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Archive",
                table: "Archive");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 634, DateTimeKind.Local).AddTicks(7356),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 18, 5, 56, 956, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 643, DateTimeKind.Local).AddTicks(3813),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 18, 5, 56, 964, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Archive",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Archive",
                table: "Archive",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 26, 28, 648, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 26, 28, 648, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 26, 28, 648, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 26, 28, 648, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 26, 28, 648, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 26, 28, 648, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.CreateIndex(
                name: "IX_Archive_NonComplianceId",
                table: "Archive",
                column: "NonComplianceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Archive",
                table: "Archive");

            migrationBuilder.DropIndex(
                name: "IX_Archive_NonComplianceId",
                table: "Archive");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Archive");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 18, 5, 56, 956, DateTimeKind.Local).AddTicks(4046),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 634, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 18, 5, 56, 964, DateTimeKind.Local).AddTicks(8240),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 643, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Archive",
                table: "Archive",
                columns: new[] { "NonComplianceId", "NonComplianceRegisterId" });

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 5, 56, 968, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(1671));
        }
    }
}

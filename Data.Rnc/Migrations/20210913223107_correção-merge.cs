using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class correçãomerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analyze",
                table: "RootCauseAnalysis");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 803, DateTimeKind.Local).AddTicks(6958),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 634, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 810, DateTimeKind.Local).AddTicks(9011),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 643, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.AlterColumn<string>(
                name: "NameNonCompliance",
                table: "TypeNonCompliance",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FiveWhat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    What = table.Column<string>(type: "text", nullable: true),
                    RootCauseAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiveWhat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiveWhat_RootCauseAnalysis_RootCauseAnalysisId",
                        column: x => x.RootCauseAnalysisId,
                        principalTable: "RootCauseAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 815, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 815, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 815, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 814, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 814, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 13, 19, 31, 6, 814, DateTimeKind.Local).AddTicks(8409));

            migrationBuilder.CreateIndex(
                name: "IX_TypeNonCompliance_NameNonCompliance",
                table: "TypeNonCompliance",
                column: "NameNonCompliance",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiveWhat_RootCauseAnalysisId",
                table: "FiveWhat",
                column: "RootCauseAnalysisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiveWhat");

            migrationBuilder.DropIndex(
                name: "IX_TypeNonCompliance_NameNonCompliance",
                table: "TypeNonCompliance");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 634, DateTimeKind.Local).AddTicks(7356),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 803, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 18, 26, 28, 643, DateTimeKind.Local).AddTicks(3813),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 9, 13, 19, 31, 6, 810, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.AlterColumn<string>(
                name: "NameNonCompliance",
                table: "TypeNonCompliance",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Analyze",
                table: "RootCauseAnalysis",
                type: "text",
                nullable: false,
                defaultValue: "");

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
        }
    }
}

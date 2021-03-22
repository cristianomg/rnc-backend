using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class createRootCauseAnalyi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 22, 20, 23, 21, 516, DateTimeKind.Local).AddTicks(9880),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 11, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 22, 20, 23, 21, 521, DateTimeKind.Local).AddTicks(5876),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 19, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.CreateTable(
                name: "RootCauseAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    NonComplianceRegisterId = table.Column<int>(nullable: false),
                    Analyze = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCauseAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalysis_NonComplianceRegister_NonComplianceRegist~",
                        column: x => x.NonComplianceRegisterId,
                        principalTable: "NonComplianceRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalysis_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 528, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 529, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 528, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 528, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 528, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 528, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 528, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 20, 23, 21, 528, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalysis_NonComplianceRegisterId",
                table: "RootCauseAnalysis",
                column: "NonComplianceRegisterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalysis_UserId",
                table: "RootCauseAnalysis",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RootCauseAnalysis");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 11, DateTimeKind.Local).AddTicks(3614),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 3, 22, 20, 23, 21, 516, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 19, DateTimeKind.Local).AddTicks(8676),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 3, 22, 20, 23, 21, 521, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 28, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 29, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 28, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 28, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 22, 10, 29, 48, 28, DateTimeKind.Local).AddTicks(5967));
        }
    }
}

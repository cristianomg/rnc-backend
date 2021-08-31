using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class addkeyparameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archives");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 382, DateTimeKind.Local).AddTicks(5424),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 30, 15, 52, 13, 442, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 392, DateTimeKind.Local).AddTicks(1398),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 30, 15, 52, 13, 444, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.CreateTable(
                name: "Archive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    IdNonComplimance = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archive_NonComplianceRegister_IdNonComplimance",
                        column: x => x.IdNonComplimance,
                        principalTable: "NonComplianceRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 397, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 21, 26, 38, 398, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.CreateIndex(
                name: "IX_Archive_IdNonComplimance",
                table: "Archive",
                column: "IdNonComplimance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archive");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 30, 15, 52, 13, 442, DateTimeKind.Local).AddTicks(125),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 382, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 30, 15, 52, 13, 444, DateTimeKind.Local).AddTicks(4489),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 8, 30, 21, 26, 38, 392, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.CreateTable(
                name: "Archives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 8, 30, 15, 52, 13, 420, DateTimeKind.Local).AddTicks(3290)),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IdArchive = table.Column<int>(type: "integer", nullable: false),
                    IdNonComplimance = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archives_NonComplianceRegister_IdNonComplimance",
                        column: x => x.IdNonComplimance,
                        principalTable: "NonComplianceRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 15, 52, 13, 449, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 15, 52, 13, 450, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 15, 52, 13, 450, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 15, 52, 13, 449, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 15, 52, 13, 449, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 30, 15, 52, 13, 449, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.CreateIndex(
                name: "IX_Archives_IdNonComplimance",
                table: "Archives",
                column: "IdNonComplimance");
        }
    }
}

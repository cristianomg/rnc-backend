using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class criateNonComplianceRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaoConformidade_TipoNaoConformidade_TipoNaoConformidadeId",
                table: "NaoConformidade");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserAuth_UserAuthId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserPermission_UserPermissionId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoNaoConformidade",
                table: "TipoNaoConformidade");

            migrationBuilder.RenameTable(
                name: "TipoNaoConformidade",
                newName: "TipoNaoConformidades");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 11, DateTimeKind.Local).AddTicks(3614),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 19, 45, 35, 265, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 19, DateTimeKind.Local).AddTicks(8676),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 19, 45, 35, 273, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoNaoConformidades",
                table: "TipoNaoConformidades",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NonComplianceRegister",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    NonComplianceId = table.Column<int>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    RegisterHour = table.Column<string>(nullable: false),
                    Setor = table.Column<string>(maxLength: 50, nullable: false),
                    PeopleInvolved = table.Column<string>(maxLength: 255, nullable: false),
                    MoreInformation = table.Column<string>(maxLength: 255, nullable: true),
                    ImmediateAction = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonComplianceRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonComplianceRegister_NaoConformidade_NonComplianceId",
                        column: x => x.NonComplianceId,
                        principalTable: "NaoConformidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NonComplianceRegister_User_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_NonComplianceId",
                table: "NonComplianceRegister",
                column: "NonComplianceId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_UserId",
                table: "NonComplianceRegister",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NaoConformidade_TipoNaoConformidades_TipoNaoConformidadeId",
                table: "NaoConformidade",
                column: "TipoNaoConformidadeId",
                principalTable: "TipoNaoConformidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserAuth_UserAuthId",
                table: "User",
                column: "UserAuthId",
                principalTable: "UserAuth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserPermission_UserPermissionId",
                table: "User",
                column: "UserPermissionId",
                principalTable: "UserPermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaoConformidade_TipoNaoConformidades_TipoNaoConformidadeId",
                table: "NaoConformidade");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserAuth_UserAuthId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserPermission_UserPermissionId",
                table: "User");

            migrationBuilder.DropTable(
                name: "NonComplianceRegister");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoNaoConformidades",
                table: "TipoNaoConformidades");

            migrationBuilder.RenameTable(
                name: "TipoNaoConformidades",
                newName: "TipoNaoConformidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 19, 45, 35, 265, DateTimeKind.Local).AddTicks(5188),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 11, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 19, 45, 35, 273, DateTimeKind.Local).AddTicks(9920),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 3, 22, 10, 29, 48, 19, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoNaoConformidade",
                table: "TipoNaoConformidade",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(384));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "NaoConformidade",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "TipoNaoConformidade",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.AddForeignKey(
                name: "FK_NaoConformidade_TipoNaoConformidade_TipoNaoConformidadeId",
                table: "NaoConformidade",
                column: "TipoNaoConformidadeId",
                principalTable: "TipoNaoConformidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserAuth_UserAuthId",
                table: "User",
                column: "UserAuthId",
                principalTable: "UserAuth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserPermission_UserPermissionId",
                table: "User",
                column: "UserPermissionId",
                principalTable: "UserPermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

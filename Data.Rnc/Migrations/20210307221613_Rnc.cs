using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Rnc.Migrations
{
    public partial class Rnc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoNaoConformidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeTipoNaoConformidade = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNaoConformidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuth",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 3, 7, 19, 16, 12, 938, DateTimeKind.Local).AddTicks(8426)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaoConformidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoNaoConformidadeId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaoConformidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaoConformidade_TipoNaoConformidade_TipoNaoConformidadeId",
                        column: x => x.TipoNaoConformidadeId,
                        principalTable: "TipoNaoConformidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 3, 7, 19, 16, 12, 946, DateTimeKind.Local).AddTicks(4171)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserAuthId = table.Column<Guid>(nullable: false),
                    Enrollment = table.Column<string>(maxLength: 50, nullable: false),
                    UserPermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserAuth_UserAuthId",
                        column: x => x.UserAuthId,
                        principalTable: "UserAuth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserPermission_UserPermissionId",
                        column: x => x.UserPermissionId,
                        principalTable: "UserPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 1, true, new DateTime(2021, 3, 7, 19, 16, 12, 953, DateTimeKind.Local).AddTicks(3631), "Employee", null });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 2, true, new DateTime(2021, 3, 7, 19, 16, 12, 953, DateTimeKind.Local).AddTicks(6122), "Supervisor", null });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { 3, true, new DateTime(2021, 3, 7, 19, 16, 12, 953, DateTimeKind.Local).AddTicks(6444), "QualityBiomedical", null });

            migrationBuilder.CreateIndex(
                name: "IX_NaoConformidade_TipoNaoConformidadeId",
                table: "NaoConformidade",
                column: "TipoNaoConformidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoNaoConformidade_NomeTipoNaoConformidade",
                table: "TipoNaoConformidade",
                column: "NomeTipoNaoConformidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Enrollment",
                table: "User",
                column: "Enrollment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserAuthId",
                table: "User",
                column: "UserAuthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserPermissionId",
                table: "User",
                column: "UserPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuth_Email",
                table: "UserAuth",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaoConformidade");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TipoNaoConformidade");

            migrationBuilder.DropTable(
                name: "UserAuth");

            migrationBuilder.DropTable(
                name: "UserPermission");
        }
    }
}

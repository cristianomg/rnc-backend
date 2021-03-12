using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoNaoConformidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    NomeTipoNaoConformidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNaoConformidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 3, 11, 19, 45, 35, 265, DateTimeKind.Local).AddTicks(5188)),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TipoNaoConformidadeId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 150, nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 3, 11, 19, 45, 35, 273, DateTimeKind.Local).AddTicks(9920)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserAuthId = table.Column<int>(nullable: false),
                    Enrollment = table.Column<string>(maxLength: 50, nullable: false),
                    Setor = table.Column<string>(maxLength: 50, nullable: false),
                    Crbm = table.Column<string>(maxLength: 15, nullable: false),
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
                table: "TipoNaoConformidade",
                columns: new[] { "Id", "Active", "CreatedAt", "NomeTipoNaoConformidade", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(6418), "Pre-Analitica", null },
                    { 2, true, new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(8377), "Analitica", null },
                    { 3, true, new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(8431), "Pos-Analitica", null }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(1950), "Employee", null },
                    { 2, true, new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(3788), "Supervisor", null },
                    { 3, true, new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(3956), "QualityBiomedical", null }
                });

            migrationBuilder.InsertData(
                table: "NaoConformidade",
                columns: new[] { "Id", "Active", "CreatedAt", "Descricao", "TipoNaoConformidadeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 3, 11, 19, 45, 35, 288, DateTimeKind.Local).AddTicks(9085), "Erros de cadastro do paciente ou médico.", 1, null },
                    { 19, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(495), "Erro de transcrição de resultado na ficha de bancada.", 3, null },
                    { 18, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(477), "Falta da assinatura do Biomédico no laudo.", 3, null },
                    { 17, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(457), "Atraso na liberação do laudo.", 3, null },
                    { 16, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(439), "Laudos entregues trocados.", 3, null },
                    { 15, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(421), "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.", 3, null },
                    { 14, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(403), "Armazenamento errado da amostra.", 2, null },
                    { 13, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(384), "Queda de energia.", 2, null },
                    { 12, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(366), "Centrifugação incorreta.", 2, null },
                    { 20, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(540), "Questionamento do resultado feito pelo médico ou cliente.", 3, null },
                    { 11, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(348), "Material fora da validade.", 2, null },
                    { 9, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(310), "Equipamento em manutenção.", 2, null },
                    { 8, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(292), "Material não tirado da pendência.", 2, null },
                    { 7, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(274), "Amostra com identificação errada ou incompleta.", 1, null },
                    { 6, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(255), "Tubo inadequado.", 1, null },
                    { 5, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(233), "Amostra insuficiente.", 1, null },
                    { 4, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(215), "Incidente com cliente.", 1, null },
                    { 3, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(195), "Paciente com preparo inadequado.", 1, null },
                    { 2, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(149), "Requisições ilegíveis.", 1, null },
                    { 10, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(330), "Perda de amostra.", 2, null },
                    { 21, true, new DateTime(2021, 3, 11, 19, 45, 35, 289, DateTimeKind.Local).AddTicks(559), "Perda do laudo.", 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaoConformidade_TipoNaoConformidadeId",
                table: "NaoConformidade",
                column: "TipoNaoConformidadeId");

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

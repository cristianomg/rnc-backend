using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class Rnc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setor",
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
                    table.PrimaryKey("PK_Setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoNaoConformidades",
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
                    table.PrimaryKey("PK_TipoNaoConformidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 3, 28, 18, 43, 26, 226, DateTimeKind.Local).AddTicks(2372)),
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
                        name: "FK_NaoConformidade_TipoNaoConformidades_TipoNaoConformidadeId",
                        column: x => x.TipoNaoConformidadeId,
                        principalTable: "TipoNaoConformidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 3, 28, 18, 43, 26, 232, DateTimeKind.Local).AddTicks(4215)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserAuthId = table.Column<int>(nullable: false),
                    Enrollment = table.Column<string>(maxLength: 50, nullable: false),
                    SetorId = table.Column<int>(nullable: false),
                    Crbm = table.Column<string>(maxLength: 15, nullable: false),
                    UserPermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserAuth_UserAuthId",
                        column: x => x.UserAuthId,
                        principalTable: "UserAuth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserPermission_UserPermissionId",
                        column: x => x.UserPermissionId,
                        principalTable: "UserPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "Setor",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(4437), "Coleta", null },
                    { 2, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6182), "Microbiologia", null },
                    { 3, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6259), "Parasitologia", null },
                    { 4, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6263), "Imunologia", null },
                    { 5, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6265), "Hematologia", null },
                    { 6, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6270), "Triagem", null }
                });

            migrationBuilder.InsertData(
                table: "TipoNaoConformidades",
                columns: new[] { "Id", "Active", "CreatedAt", "NomeTipoNaoConformidade", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(7900), "Pre-Analitica", null },
                    { 2, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(9790), "Analitica", null },
                    { 3, true, new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(9833), "Pos-Analitica", null }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 3, 28, 18, 43, 26, 236, DateTimeKind.Local).AddTicks(9406), "Employee", null },
                    { 2, true, new DateTime(2021, 3, 28, 18, 43, 26, 237, DateTimeKind.Local).AddTicks(1370), "Supervisor", null },
                    { 3, true, new DateTime(2021, 3, 28, 18, 43, 26, 237, DateTimeKind.Local).AddTicks(1496), "QualityBiomedical", null }
                });

            migrationBuilder.InsertData(
                table: "NaoConformidade",
                columns: new[] { "Id", "Active", "CreatedAt", "Descricao", "TipoNaoConformidadeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(493), "Erros de cadastro do paciente ou médico.", 1, null },
                    { 19, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1922), "Erro de transcrição de resultado na ficha de bancada.", 3, null },
                    { 18, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1905), "Falta da assinatura do Biomédico no laudo.", 3, null },
                    { 17, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1886), "Atraso na liberação do laudo.", 3, null },
                    { 16, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1869), "Laudos entregues trocados.", 3, null },
                    { 15, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1852), "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.", 3, null },
                    { 14, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1833), "Armazenamento errado da amostra.", 2, null },
                    { 13, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1783), "Queda de energia.", 2, null },
                    { 12, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1766), "Centrifugação incorreta.", 2, null },
                    { 20, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1939), "Questionamento do resultado feito pelo médico ou cliente.", 3, null },
                    { 11, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1748), "Material fora da validade.", 2, null },
                    { 9, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1711), "Equipamento em manutenção.", 2, null },
                    { 8, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1694), "Material não tirado da pendência.", 2, null },
                    { 7, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1676), "Amostra com identificação errada ou incompleta.", 1, null },
                    { 6, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1658), "Tubo inadequado.", 1, null },
                    { 5, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1638), "Amostra insuficiente.", 1, null },
                    { 4, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1619), "Incidente com cliente.", 1, null },
                    { 3, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1599), "Paciente com preparo inadequado.", 1, null },
                    { 2, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1542), "Requisições ilegíveis.", 1, null },
                    { 10, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1730), "Perda de amostra.", 2, null },
                    { 21, true, new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1956), "Perda do laudo.", 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaoConformidade_TipoNaoConformidadeId",
                table: "NaoConformidade",
                column: "TipoNaoConformidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_NonComplianceId",
                table: "NonComplianceRegister",
                column: "NonComplianceId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_UserId",
                table: "NonComplianceRegister",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalysis_NonComplianceRegisterId",
                table: "RootCauseAnalysis",
                column: "NonComplianceRegisterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalysis_UserId",
                table: "RootCauseAnalysis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Enrollment",
                table: "User",
                column: "Enrollment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_SetorId",
                table: "User",
                column: "SetorId");

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
                name: "RootCauseAnalysis");

            migrationBuilder.DropTable(
                name: "NonComplianceRegister");

            migrationBuilder.DropTable(
                name: "NaoConformidade");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TipoNaoConformidades");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "UserAuth");

            migrationBuilder.DropTable(
                name: "UserPermission");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class alternoncomplianceregisterda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionPlain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlain", x => x.Id);
                });

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
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 3, 20, 6, 5, 397, DateTimeKind.Local).AddTicks(8128)),
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
                name: "ActionPlainQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Value = table.Column<string>(maxLength: 255, nullable: false),
                    ActionPlainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlainQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionPlainQuestion_ActionPlain_ActionPlainId",
                        column: x => x.ActionPlainId,
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 3, 20, 6, 5, 402, DateTimeKind.Local).AddTicks(3862)),
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
                    SetorId = table.Column<int>(nullable: false),
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
                        name: "FK_NonComplianceRegister_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
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
                    UserId = table.Column<int>(nullable: false),
                    ActionPlainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCauseAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalysis_ActionPlain_ActionPlainId",
                        column: x => x.ActionPlainId,
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "ActionPlainResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Value = table.Column<string>(maxLength: 255, nullable: false),
                    ActionPlainQuestionId = table.Column<int>(nullable: false),
                    RootCauseAnalysisId = table.Column<int>(nullable: false),
                    ActionPlainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlainResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionPlainResponse_ActionPlain_ActionPlainId",
                        column: x => x.ActionPlainId,
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionPlainResponse_ActionPlainQuestion_ActionPlainQuestion~",
                        column: x => x.ActionPlainQuestionId,
                        principalTable: "ActionPlainQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionPlainResponse_RootCauseAnalysis_RootCauseAnalysisId",
                        column: x => x.RootCauseAnalysisId,
                        principalTable: "RootCauseAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Setor",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 3, 20, 6, 5, 407, DateTimeKind.Local).AddTicks(3260), "Coleta", null },
                    { 2, true, new DateTime(2021, 4, 3, 20, 6, 5, 407, DateTimeKind.Local).AddTicks(4797), "Microbiologia", null },
                    { 3, true, new DateTime(2021, 4, 3, 20, 6, 5, 407, DateTimeKind.Local).AddTicks(4848), "Parasitologia", null },
                    { 4, true, new DateTime(2021, 4, 3, 20, 6, 5, 407, DateTimeKind.Local).AddTicks(4852), "Imunologia", null },
                    { 5, true, new DateTime(2021, 4, 3, 20, 6, 5, 407, DateTimeKind.Local).AddTicks(4854), "Hematologia", null },
                    { 6, true, new DateTime(2021, 4, 3, 20, 6, 5, 407, DateTimeKind.Local).AddTicks(4858), "Triagem", null }
                });

            migrationBuilder.InsertData(
                table: "TipoNaoConformidades",
                columns: new[] { "Id", "Active", "CreatedAt", "NomeTipoNaoConformidade", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 3, 20, 6, 5, 407, DateTimeKind.Local).AddTicks(8435), "Pre-Analitica", null },
                    { 2, true, new DateTime(2021, 4, 3, 20, 6, 5, 408, DateTimeKind.Local).AddTicks(34), "Analitica", null },
                    { 3, true, new DateTime(2021, 4, 3, 20, 6, 5, 408, DateTimeKind.Local).AddTicks(74), "Pos-Analitica", null }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 3, 20, 6, 5, 405, DateTimeKind.Local).AddTicks(9064), "Employee", null },
                    { 2, true, new DateTime(2021, 4, 3, 20, 6, 5, 406, DateTimeKind.Local).AddTicks(619), "Supervisor", null },
                    { 3, true, new DateTime(2021, 4, 3, 20, 6, 5, 406, DateTimeKind.Local).AddTicks(686), "QualityBiomedical", null }
                });

            migrationBuilder.InsertData(
                table: "NaoConformidade",
                columns: new[] { "Id", "Active", "CreatedAt", "Descricao", "TipoNaoConformidadeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(2349), "Erros de cadastro do paciente ou médico.", 1, null },
                    { 19, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3908), "Erro de transcrição de resultado na ficha de bancada.", 3, null },
                    { 18, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3894), "Falta da assinatura do Biomédico no laudo.", 3, null },
                    { 17, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3878), "Atraso na liberação do laudo.", 3, null },
                    { 16, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3864), "Laudos entregues trocados.", 3, null },
                    { 15, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3782), "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.", 3, null },
                    { 14, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3768), "Armazenamento errado da amostra.", 2, null },
                    { 13, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3755), "Queda de energia.", 2, null },
                    { 12, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3741), "Centrifugação incorreta.", 2, null },
                    { 20, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3922), "Questionamento do resultado feito pelo médico ou cliente.", 3, null },
                    { 11, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3726), "Material fora da validade.", 2, null },
                    { 9, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3696), "Equipamento em manutenção.", 2, null },
                    { 8, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3682), "Material não tirado da pendência.", 2, null },
                    { 7, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3668), "Amostra com identificação errada ou incompleta.", 1, null },
                    { 6, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3652), "Tubo inadequado.", 1, null },
                    { 5, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3634), "Amostra insuficiente.", 1, null },
                    { 4, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3620), "Incidente com cliente.", 1, null },
                    { 3, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3603), "Paciente com preparo inadequado.", 1, null },
                    { 2, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3547), "Requisições ilegíveis.", 1, null },
                    { 10, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3711), "Perda de amostra.", 2, null },
                    { 21, true, new DateTime(2021, 4, 3, 20, 6, 5, 409, DateTimeKind.Local).AddTicks(3974), "Perda do laudo.", 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain_Name",
                table: "ActionPlain",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainQuestion_ActionPlainId",
                table: "ActionPlainQuestion",
                column: "ActionPlainId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainResponse_ActionPlainId",
                table: "ActionPlainResponse",
                column: "ActionPlainId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainResponse_ActionPlainQuestionId",
                table: "ActionPlainResponse",
                column: "ActionPlainQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainResponse_RootCauseAnalysisId",
                table: "ActionPlainResponse",
                column: "RootCauseAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_NaoConformidade_TipoNaoConformidadeId",
                table: "NaoConformidade",
                column: "TipoNaoConformidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_NonComplianceId",
                table: "NonComplianceRegister",
                column: "NonComplianceId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_SetorId",
                table: "NonComplianceRegister",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_UserId",
                table: "NonComplianceRegister",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalysis_ActionPlainId",
                table: "RootCauseAnalysis",
                column: "ActionPlainId");

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
                name: "ActionPlainResponse");

            migrationBuilder.DropTable(
                name: "ActionPlainQuestion");

            migrationBuilder.DropTable(
                name: "RootCauseAnalysis");

            migrationBuilder.DropTable(
                name: "ActionPlain");

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

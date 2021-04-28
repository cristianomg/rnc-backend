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
                name: "TypeNonCompliance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    NameNonCompliance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNonCompliance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 27, 21, 10, 54, 554, DateTimeKind.Local).AddTicks(8036)),
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
                name: "NonCompliance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TypeNonComplianceId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonCompliance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonCompliance_TypeNonCompliance_TypeNonComplianceId",
                        column: x => x.TypeNonComplianceId,
                        principalTable: "TypeNonCompliance",
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
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 27, 21, 10, 54, 566, DateTimeKind.Local).AddTicks(1482)),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserAuthId = table.Column<int>(nullable: false),
                    Enrollment = table.Column<string>(maxLength: 50, nullable: false),
                    SetorId = table.Column<int>(nullable: false),
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
                        name: "FK_NonComplianceRegister_NonCompliance_NonComplianceId",
                        column: x => x.NonComplianceId,
                        principalTable: "NonCompliance",
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
                    { 1, true, new DateTime(2021, 4, 27, 21, 10, 54, 575, DateTimeKind.Local).AddTicks(8484), "Coleta", null },
                    { 2, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(533), "Microbiologia", null },
                    { 3, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(658), "Parasitologia", null },
                    { 4, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(662), "Imunologia", null },
                    { 5, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(666), "Hematologia", null },
                    { 6, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(673), "Triagem", null }
                });

            migrationBuilder.InsertData(
                table: "TypeNonCompliance",
                columns: new[] { "Id", "Active", "CreatedAt", "NameNonCompliance", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(5613), "Pre-Analitica", null },
                    { 2, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(7593), "Analitica", null },
                    { 3, true, new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(7643), "Pos-Analitica", null }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 27, 21, 10, 54, 573, DateTimeKind.Local).AddTicks(5583), "Employee", null },
                    { 2, true, new DateTime(2021, 4, 27, 21, 10, 54, 573, DateTimeKind.Local).AddTicks(7954), "Supervisor", null },
                    { 3, true, new DateTime(2021, 4, 27, 21, 10, 54, 573, DateTimeKind.Local).AddTicks(8322), "QualityBiomedical", null }
                });

            migrationBuilder.InsertData(
                table: "NonCompliance",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "TypeNonComplianceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(6887), "Erros de cadastro do paciente ou médico.", 1, null },
                    { 19, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9430), "Erro de transcrição de resultado na ficha de bancada.", 3, null },
                    { 18, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9408), "Falta da assinatura do Biomédico no laudo.", 3, null },
                    { 17, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9384), "Atraso na liberação do laudo.", 3, null },
                    { 16, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9361), "Laudos entregues trocados.", 3, null },
                    { 15, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9180), "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.", 3, null },
                    { 14, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9158), "Armazenamento errado da amostra.", 2, null },
                    { 13, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9136), "Queda de energia.", 2, null },
                    { 12, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9114), "Centrifugação incorreta.", 2, null },
                    { 20, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9452), "Questionamento do resultado feito pelo médico ou cliente.", 3, null },
                    { 11, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9091), "Material fora da validade.", 2, null },
                    { 9, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9043), "Equipamento em manutenção.", 2, null },
                    { 8, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9021), "Material não tirado da pendência.", 2, null },
                    { 7, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8998), "Amostra com identificação errada ou incompleta.", 1, null },
                    { 6, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8975), "Tubo inadequado.", 1, null },
                    { 5, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8946), "Amostra insuficiente.", 1, null },
                    { 4, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8857), "Incidente com cliente.", 1, null },
                    { 3, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8830), "Paciente com preparo inadequado.", 1, null },
                    { 2, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8732), "Requisições ilegíveis.", 1, null },
                    { 10, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9069), "Perda de amostra.", 2, null },
                    { 21, true, new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9475), "Perda do laudo.", 3, null }
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
                name: "IX_NonCompliance_TypeNonComplianceId",
                table: "NonCompliance",
                column: "TypeNonComplianceId");

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
                name: "NonCompliance");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TypeNonCompliance");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "UserAuth");

            migrationBuilder.DropTable(
                name: "UserPermission");
        }
    }
}

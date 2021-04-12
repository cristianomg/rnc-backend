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
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 11, 17, 16, 39, 150, DateTimeKind.Local).AddTicks(6154)),
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
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 11, 17, 16, 39, 156, DateTimeKind.Local).AddTicks(2089)),
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
                    { 1, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(845), "Coleta", null },
                    { 2, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2573), "Microbiologia", null },
                    { 3, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2701), "Parasitologia", null },
                    { 4, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2705), "Imunologia", null },
                    { 5, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2707), "Hematologia", null },
                    { 6, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2713), "Triagem", null }
                });

            migrationBuilder.InsertData(
                table: "TypeNonCompliance",
                columns: new[] { "Id", "Active", "CreatedAt", "NameNonCompliance", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(6720), "Pre-Analitica", null },
                    { 2, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(8788), "Analitica", null },
                    { 3, true, new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(8844), "Pos-Analitica", null }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(3558), "Employee", null },
                    { 2, true, new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(5493), "Supervisor", null },
                    { 3, true, new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(5733), "QualityBiomedical", null }
                });

            migrationBuilder.InsertData(
                table: "NonCompliance",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "TypeNonComplianceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(1814), "Erros de cadastro do paciente ou médico.", 1, null },
                    { 19, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3700), "Erro de transcrição de resultado na ficha de bancada.", 3, null },
                    { 18, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3618), "Falta da assinatura do Biomédico no laudo.", 3, null },
                    { 17, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3598), "Atraso na liberação do laudo.", 3, null },
                    { 16, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3580), "Laudos entregues trocados.", 3, null },
                    { 15, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3471), "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.", 3, null },
                    { 14, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3453), "Armazenamento errado da amostra.", 2, null },
                    { 13, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3435), "Queda de energia.", 2, null },
                    { 12, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3418), "Centrifugação incorreta.", 2, null },
                    { 20, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3720), "Questionamento do resultado feito pelo médico ou cliente.", 3, null },
                    { 11, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3400), "Material fora da validade.", 2, null },
                    { 9, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3362), "Equipamento em manutenção.", 2, null },
                    { 8, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3344), "Material não tirado da pendência.", 2, null },
                    { 7, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3325), "Amostra com identificação errada ou incompleta.", 1, null },
                    { 6, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3307), "Tubo inadequado.", 1, null },
                    { 5, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3283), "Amostra insuficiente.", 1, null },
                    { 4, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3264), "Incidente com cliente.", 1, null },
                    { 3, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3242), "Paciente com preparo inadequado.", 1, null },
                    { 2, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3169), "Requisições ilegíveis.", 1, null },
                    { 10, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3382), "Perda de amostra.", 2, null },
                    { 21, true, new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3738), "Perda do laudo.", 3, null }
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

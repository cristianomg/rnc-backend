using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class initialoccurrencemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Occurrences");

            migrationBuilder.CreateTable(
                name: "ActionPlain",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceClassification",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceClassification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SupervisorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOccurrence",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    OccurrenceTypeName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOccurrence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionPlainQuestion",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ActionPlainId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlainQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionPlainQuestion_ActionPlain_ActionPlainId",
                        column: x => x.ActionPlainId,
                        principalSchema: "Occurrences",
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceRegister",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrenceClassificationId = table.Column<int>(type: "integer", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RegisterHour = table.Column<string>(type: "text", nullable: false),
                    SetorId = table.Column<int>(type: "integer", nullable: false),
                    PeopleInvolved = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MoreInformation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ImmediateAction = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    OccurrencePendency = table.Column<int>(type: "integer", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccurrenceRegister_OccurrenceClassification_OccurrenceClass~",
                        column: x => x.OccurrenceClassificationId,
                        principalSchema: "Occurrences",
                        principalTable: "OccurrenceClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OccurrenceRegister_Setor_SetorId",
                        column: x => x.SetorId,
                        principalSchema: "Occurrences",
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Occurrence",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrenceTypeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occurrence_TypeOccurrence_OccurrenceTypeId",
                        column: x => x.OccurrenceTypeId,
                        principalSchema: "Occurrences",
                        principalTable: "TypeOccurrence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RootCauseAnalysis",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrenceRegisterId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionPlainId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCauseAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalysis_ActionPlain_ActionPlainId",
                        column: x => x.ActionPlainId,
                        principalSchema: "Occurrences",
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalysis_OccurrenceRegister_OccurrenceRegisterId",
                        column: x => x.OccurrenceRegisterId,
                        principalSchema: "Occurrences",
                        principalTable: "OccurrenceRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceOccurrenceRegister",
                schema: "Occurrences",
                columns: table => new
                {
                    OccurrenceRegistersId = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrencesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceOccurrenceRegister", x => new { x.OccurrenceRegistersId, x.OccurrencesId });
                    table.ForeignKey(
                        name: "FK_OccurrenceOccurrenceRegister_Occurrence_OccurrencesId",
                        column: x => x.OccurrencesId,
                        principalSchema: "Occurrences",
                        principalTable: "Occurrence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OccurrenceOccurrenceRegister_OccurrenceRegister_OccurrenceR~",
                        column: x => x.OccurrenceRegistersId,
                        principalSchema: "Occurrences",
                        principalTable: "OccurrenceRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionPlainResponse",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ActionPlainQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    RootCauseAnalysisId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionPlainId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlainResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionPlainResponse_ActionPlain_ActionPlainId",
                        column: x => x.ActionPlainId,
                        principalSchema: "Occurrences",
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionPlainResponse_ActionPlainQuestion_ActionPlainQuestion~",
                        column: x => x.ActionPlainQuestionId,
                        principalSchema: "Occurrences",
                        principalTable: "ActionPlainQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionPlainResponse_RootCauseAnalysis_RootCauseAnalysisId",
                        column: x => x.RootCauseAnalysisId,
                        principalSchema: "Occurrences",
                        principalTable: "RootCauseAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FiveWhat",
                schema: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    What = table.Column<string>(type: "text", nullable: true),
                    RootCauseAnalysisId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalSchema: "Occurrences",
                        principalTable: "RootCauseAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Occurrences",
                table: "TypeOccurrence",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "OccurrenceTypeName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 9, 21, 14, 33, 10, 217, DateTimeKind.Local).AddTicks(388), null, "Pre-Analítica", null, null },
                    { 2, true, new DateTime(2021, 9, 21, 14, 33, 10, 226, DateTimeKind.Local).AddTicks(6701), null, "Pre-Analítica", null, null },
                    { 3, true, new DateTime(2021, 9, 21, 14, 33, 10, 226, DateTimeKind.Local).AddTicks(7730), null, "Pre-Analítica", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain_Name",
                schema: "Occurrences",
                table: "ActionPlain",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainQuestion_ActionPlainId",
                schema: "Occurrences",
                table: "ActionPlainQuestion",
                column: "ActionPlainId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainResponse_ActionPlainId",
                schema: "Occurrences",
                table: "ActionPlainResponse",
                column: "ActionPlainId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainResponse_ActionPlainQuestionId",
                schema: "Occurrences",
                table: "ActionPlainResponse",
                column: "ActionPlainQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlainResponse_RootCauseAnalysisId",
                schema: "Occurrences",
                table: "ActionPlainResponse",
                column: "RootCauseAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_FiveWhat_RootCauseAnalysisId",
                schema: "Occurrences",
                table: "FiveWhat",
                column: "RootCauseAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_OccurrenceTypeId",
                schema: "Occurrences",
                table: "Occurrence",
                column: "OccurrenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceOccurrenceRegister_OccurrencesId",
                schema: "Occurrences",
                table: "OccurrenceOccurrenceRegister",
                column: "OccurrencesId");

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceRegister_OccurrenceClassificationId",
                schema: "Occurrences",
                table: "OccurrenceRegister",
                column: "OccurrenceClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceRegister_SetorId",
                schema: "Occurrences",
                table: "OccurrenceRegister",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalysis_ActionPlainId",
                schema: "Occurrences",
                table: "RootCauseAnalysis",
                column: "ActionPlainId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalysis_OccurrenceRegisterId",
                schema: "Occurrences",
                table: "RootCauseAnalysis",
                column: "OccurrenceRegisterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeOccurrence_OccurrenceTypeName",
                schema: "Occurrences",
                table: "TypeOccurrence",
                column: "OccurrenceTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionPlainResponse",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "FiveWhat",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "OccurrenceOccurrenceRegister",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "ActionPlainQuestion",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "RootCauseAnalysis",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "Occurrence",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "ActionPlain",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "OccurrenceRegister",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "TypeOccurrence",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "OccurrenceClassification",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "Setor",
                schema: "Occurrences");
        }
    }
}

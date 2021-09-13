using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionPlain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "Historic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Entity = table.Column<string>(type: "text", nullable: false),
                    Values = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceClassification",
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
                name: "TypeNonCompliance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameNonCompliance = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNonCompliance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 9, 13, 18, 5, 56, 956, DateTimeKind.Local).AddTicks(4046)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
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
                    table.PrimaryKey("PK_UserPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionPlainQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ActionPlainId = table.Column<int>(type: "integer", nullable: false),
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
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NonCompliance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeNonComplianceId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
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
                name: "ActionPlainResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ActionPlainQuestionId = table.Column<int>(type: "integer", nullable: false),
                    RootCauseAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    ActionPlainId = table.Column<int>(type: "integer", nullable: false),
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
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionPlainResponse_ActionPlainQuestion_ActionPlainQuestion~",
                        column: x => x.ActionPlainQuestionId,
                        principalTable: "ActionPlainQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RootCauseAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NonComplianceRegisterId = table.Column<int>(type: "integer", nullable: false),
                    Analyze = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ActionPlainId = table.Column<int>(type: "integer", nullable: false),
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
                        principalTable: "ActionPlain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Archive",
                columns: table => new
                {
                    NonComplianceId = table.Column<int>(type: "integer", nullable: false),
                    NonComplianceRegisterId = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive", x => new { x.NonComplianceId, x.NonComplianceRegisterId });
                    table.ForeignKey(
                        name: "FK_Archive_NonCompliance_NonComplianceId",
                        column: x => x.NonComplianceId,
                        principalTable: "NonCompliance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NonComplianceNonComplianceRegister",
                columns: table => new
                {
                    NonComplianceRegistersId = table.Column<int>(type: "integer", nullable: false),
                    NonCompliancesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonComplianceNonComplianceRegister", x => new { x.NonComplianceRegistersId, x.NonCompliancesId });
                    table.ForeignKey(
                        name: "FK_NonComplianceNonComplianceRegister_NonCompliance_NonComplia~",
                        column: x => x.NonCompliancesId,
                        principalTable: "NonCompliance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NonComplianceRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OccurrenceClassificationId = table.Column<int>(type: "integer", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RegisterHour = table.Column<string>(type: "text", nullable: false),
                    SetorId = table.Column<int>(type: "integer", nullable: false),
                    PeopleInvolved = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MoreInformation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ImmediateAction = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    OcurrencePendency = table.Column<int>(type: "integer", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonComplianceRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonComplianceRegister_OccurrenceClassification_OccurrenceCl~",
                        column: x => x.OccurrenceClassificationId,
                        principalTable: "OccurrenceClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserAuthId = table.Column<int>(type: "integer", nullable: false),
                    Enrollment = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SetorId = table.Column<int>(type: "integer", nullable: false),
                    UserPermissionId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 9, 13, 18, 5, 56, 964, DateTimeKind.Local).AddTicks(8240)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SupervisorId = table.Column<int>(type: "integer", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setor_User_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "TypeNonCompliance",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "NameNonCompliance", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(5654), null, "Pre-Analitica", null, null },
                    { 2, true, new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(7693), null, "Analitica", null, null },
                    { 3, true, new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(7816), null, "Pos-Analitica", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 9, 13, 18, 5, 56, 968, DateTimeKind.Local).AddTicks(9713), null, "Employee", null, null },
                    { 2, true, new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(1593), null, "Supervisor", null, null },
                    { 3, true, new DateTime(2021, 9, 13, 18, 5, 56, 969, DateTimeKind.Local).AddTicks(1671), null, "QualityBiomedical", null, null }
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
                name: "IX_Archive_NonComplianceRegisterId",
                table: "Archive",
                column: "NonComplianceRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_NonCompliance_TypeNonComplianceId",
                table: "NonCompliance",
                column: "TypeNonComplianceId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceNonComplianceRegister_NonCompliancesId",
                table: "NonComplianceNonComplianceRegister",
                column: "NonCompliancesId");

            migrationBuilder.CreateIndex(
                name: "IX_NonComplianceRegister_OccurrenceClassificationId",
                table: "NonComplianceRegister",
                column: "OccurrenceClassificationId");

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
                name: "IX_Setor_SupervisorId",
                table: "Setor",
                column: "SupervisorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainResponse_RootCauseAnalysis_RootCauseAnalysisId",
                table: "ActionPlainResponse",
                column: "RootCauseAnalysisId",
                principalTable: "RootCauseAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RootCauseAnalysis_NonComplianceRegister_NonComplianceRegist~",
                table: "RootCauseAnalysis",
                column: "NonComplianceRegisterId",
                principalTable: "NonComplianceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RootCauseAnalysis_User_UserId",
                table: "RootCauseAnalysis",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Archive_NonComplianceRegister_NonComplianceRegisterId",
                table: "Archive",
                column: "NonComplianceRegisterId",
                principalTable: "NonComplianceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NonComplianceNonComplianceRegister_NonComplianceRegister_No~",
                table: "NonComplianceNonComplianceRegister",
                column: "NonComplianceRegistersId",
                principalTable: "NonComplianceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NonComplianceRegister_Setor_SetorId",
                table: "NonComplianceRegister",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NonComplianceRegister_User_UserId",
                table: "NonComplianceRegister",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Setor_SetorId",
                table: "User",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Setor_SetorId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ActionPlainResponse");

            migrationBuilder.DropTable(
                name: "Archive");

            migrationBuilder.DropTable(
                name: "Historic");

            migrationBuilder.DropTable(
                name: "NonComplianceNonComplianceRegister");

            migrationBuilder.DropTable(
                name: "ActionPlainQuestion");

            migrationBuilder.DropTable(
                name: "RootCauseAnalysis");

            migrationBuilder.DropTable(
                name: "NonCompliance");

            migrationBuilder.DropTable(
                name: "ActionPlain");

            migrationBuilder.DropTable(
                name: "NonComplianceRegister");

            migrationBuilder.DropTable(
                name: "TypeNonCompliance");

            migrationBuilder.DropTable(
                name: "OccurrenceClassification");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserAuth");

            migrationBuilder.DropTable(
                name: "UserPermission");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Satisfaction.Data.Migrations
{
    public partial class Ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryPunctuality = table.Column<int>(type: "integer", nullable: false),
                    DeliveryResultTime = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HowSatisfied",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    HowSatisfiedUre = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowSatisfied", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverallImpression",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    FriendsRecommendation = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverallImpression", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reception",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    WaitingTime = table.Column<int>(type: "integer", nullable: false),
                    AttendanceAgility = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reception", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sanitation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalSanitation = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanitation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TecnicalArea",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactioSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    WaitingTime = table.Column<int>(type: "integer", nullable: false),
                    ProfissionalHability = table.Column<int>(type: "integer", nullable: false),
                    ExamOrientation = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicalArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SatisfactionSurveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TecnicalAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    SanitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryResultsId = table.Column<Guid>(type: "uuid", nullable: false),
                    OverallImpressionId = table.Column<Guid>(type: "uuid", nullable: false),
                    HowSatisfiedId = table.Column<Guid>(type: "uuid", nullable: false),
                    OurDifferentialId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhySearchId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonalInformationsId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisfactionSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_DeliveryResults_DeliveryResultsId",
                        column: x => x.DeliveryResultsId,
                        principalTable: "DeliveryResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_HowSatisfied_HowSatisfiedId",
                        column: x => x.HowSatisfiedId,
                        principalTable: "HowSatisfied",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_OverallImpression_OverallImpressionId",
                        column: x => x.OverallImpressionId,
                        principalTable: "OverallImpression",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_PersonalInformations_PersonalInformatio~",
                        column: x => x.PersonalInformationsId,
                        principalTable: "PersonalInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_Reception_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Reception",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_Sanitation_SanitationId",
                        column: x => x.SanitationId,
                        principalTable: "Sanitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatisfactionSurveys_TecnicalArea_TecnicalAreaId",
                        column: x => x.TecnicalAreaId,
                        principalTable: "TecnicalArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OurDifferential",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurDifferential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OurDifferential_SatisfactionSurveys_SatisfactionSurveyId",
                        column: x => x.SatisfactionSurveyId,
                        principalTable: "SatisfactionSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WhySearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SatisfactionSurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearchQuestions = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhySearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhySearch_SatisfactionSurveys_SatisfactionSurveyId",
                        column: x => x.SatisfactionSurveyId,
                        principalTable: "SatisfactionSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OurDifferential_SatisfactionSurveyId",
                table: "OurDifferential",
                column: "SatisfactionSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_DeliveryResultsId",
                table: "SatisfactionSurveys",
                column: "DeliveryResultsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_HowSatisfiedId",
                table: "SatisfactionSurveys",
                column: "HowSatisfiedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_OverallImpressionId",
                table: "SatisfactionSurveys",
                column: "OverallImpressionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_PersonalInformationsId",
                table: "SatisfactionSurveys",
                column: "PersonalInformationsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_ReceptionId",
                table: "SatisfactionSurveys",
                column: "ReceptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_SanitationId",
                table: "SatisfactionSurveys",
                column: "SanitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SatisfactionSurveys_TecnicalAreaId",
                table: "SatisfactionSurveys",
                column: "TecnicalAreaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WhySearch_SatisfactionSurveyId",
                table: "WhySearch",
                column: "SatisfactionSurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurDifferential");

            migrationBuilder.DropTable(
                name: "WhySearch");

            migrationBuilder.DropTable(
                name: "SatisfactionSurveys");

            migrationBuilder.DropTable(
                name: "DeliveryResults");

            migrationBuilder.DropTable(
                name: "HowSatisfied");

            migrationBuilder.DropTable(
                name: "OverallImpression");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "Reception");

            migrationBuilder.DropTable(
                name: "Sanitation");

            migrationBuilder.DropTable(
                name: "TecnicalArea");
        }
    }
}

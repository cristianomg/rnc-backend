using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Occurrences.Data.Migrations
{
    public partial class IsDelted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainQuestion_ActionPlain_ActionPlainId",
                table: "ActionPlainQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainResponse_ActionPlain_ActionPlainId",
                table: "ActionPlainResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainResponse_ActionPlainQuestion_ActionPlainQuestion~",
                table: "ActionPlainResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainResponse_RootCauseAnalysis_RootCauseAnalysisId",
                table: "ActionPlainResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_FiveWhat_RootCauseAnalysis_RootCauseAnalysisId",
                table: "FiveWhat");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_Occurrence_OccurrencesId",
                table: "OccurrenceOccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_OccurrenceRegister_OccurrenceR~",
                table: "OccurrenceOccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_TypeOccurrence_OccurrenceTypeId",
                table: "OccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_RootCauseAnalysis_ActionPlain_ActionPlainId",
                table: "RootCauseAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_RootCauseAnalysis_OccurrenceRegister_OccurrenceRegisterId",
                table: "RootCauseAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_VerificationOfEffectiveness_OccurrenceRegister_OccurrenceRe~",
                table: "VerificationOfEffectiveness");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VerificationOfEffectiveness",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TypeOccurrence",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Setor",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RootCauseAnalysis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OccurrenceRisk",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OccurrenceRegister",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OccurrenceClassification",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Occurrence",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FiveWhat",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActionPlainResponse",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActionPlainQuestion",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActionPlain",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 542, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 58, 2, 545, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainQuestion_ActionPlain_ActionPlainId",
                table: "ActionPlainQuestion",
                column: "ActionPlainId",
                principalTable: "ActionPlain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainResponse_ActionPlain_ActionPlainId",
                table: "ActionPlainResponse",
                column: "ActionPlainId",
                principalTable: "ActionPlain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainResponse_ActionPlainQuestion_ActionPlainQuestion~",
                table: "ActionPlainResponse",
                column: "ActionPlainQuestionId",
                principalTable: "ActionPlainQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainResponse_RootCauseAnalysis_RootCauseAnalysisId",
                table: "ActionPlainResponse",
                column: "RootCauseAnalysisId",
                principalTable: "RootCauseAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FiveWhat_RootCauseAnalysis_RootCauseAnalysisId",
                table: "FiveWhat",
                column: "RootCauseAnalysisId",
                principalTable: "RootCauseAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_Occurrence_OccurrencesId",
                table: "OccurrenceOccurrenceRegister",
                column: "OccurrencesId",
                principalTable: "Occurrence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_OccurrenceRegister_OccurrenceR~",
                table: "OccurrenceOccurrenceRegister",
                column: "OccurrenceRegistersId",
                principalTable: "OccurrenceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_TypeOccurrence_OccurrenceTypeId",
                table: "OccurrenceRegister",
                column: "OccurrenceTypeId",
                principalTable: "TypeOccurrence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RootCauseAnalysis_ActionPlain_ActionPlainId",
                table: "RootCauseAnalysis",
                column: "ActionPlainId",
                principalTable: "ActionPlain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RootCauseAnalysis_OccurrenceRegister_OccurrenceRegisterId",
                table: "RootCauseAnalysis",
                column: "OccurrenceRegisterId",
                principalTable: "OccurrenceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VerificationOfEffectiveness_OccurrenceRegister_OccurrenceRe~",
                table: "VerificationOfEffectiveness",
                column: "OccurrenceRegisterId",
                principalTable: "OccurrenceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainQuestion_ActionPlain_ActionPlainId",
                table: "ActionPlainQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainResponse_ActionPlain_ActionPlainId",
                table: "ActionPlainResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainResponse_ActionPlainQuestion_ActionPlainQuestion~",
                table: "ActionPlainResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlainResponse_RootCauseAnalysis_RootCauseAnalysisId",
                table: "ActionPlainResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_FiveWhat_RootCauseAnalysis_RootCauseAnalysisId",
                table: "FiveWhat");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_Occurrence_OccurrencesId",
                table: "OccurrenceOccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_OccurrenceRegister_OccurrenceR~",
                table: "OccurrenceOccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_OccurrenceRegister_TypeOccurrence_OccurrenceTypeId",
                table: "OccurrenceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_RootCauseAnalysis_ActionPlain_ActionPlainId",
                table: "RootCauseAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_RootCauseAnalysis_OccurrenceRegister_OccurrenceRegisterId",
                table: "RootCauseAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_VerificationOfEffectiveness_OccurrenceRegister_OccurrenceRe~",
                table: "VerificationOfEffectiveness");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VerificationOfEffectiveness");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TypeOccurrence");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Setor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RootCauseAnalysis");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OccurrenceRisk");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OccurrenceRegister");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OccurrenceClassification");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FiveWhat");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActionPlainResponse");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActionPlainQuestion");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActionPlain");

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 526, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "TypeOccurrence",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 15, 33, 44, 532, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainQuestion_ActionPlain_ActionPlainId",
                table: "ActionPlainQuestion",
                column: "ActionPlainId",
                principalTable: "ActionPlain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainResponse_ActionPlain_ActionPlainId",
                table: "ActionPlainResponse",
                column: "ActionPlainId",
                principalTable: "ActionPlain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainResponse_ActionPlainQuestion_ActionPlainQuestion~",
                table: "ActionPlainResponse",
                column: "ActionPlainQuestionId",
                principalTable: "ActionPlainQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlainResponse_RootCauseAnalysis_RootCauseAnalysisId",
                table: "ActionPlainResponse",
                column: "RootCauseAnalysisId",
                principalTable: "RootCauseAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FiveWhat_RootCauseAnalysis_RootCauseAnalysisId",
                table: "FiveWhat",
                column: "RootCauseAnalysisId",
                principalTable: "RootCauseAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_Occurrence_OccurrencesId",
                table: "OccurrenceOccurrenceRegister",
                column: "OccurrencesId",
                principalTable: "Occurrence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceOccurrenceRegister_OccurrenceRegister_OccurrenceR~",
                table: "OccurrenceOccurrenceRegister",
                column: "OccurrenceRegistersId",
                principalTable: "OccurrenceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_Setor_SetorId",
                table: "OccurrenceRegister",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OccurrenceRegister_TypeOccurrence_OccurrenceTypeId",
                table: "OccurrenceRegister",
                column: "OccurrenceTypeId",
                principalTable: "TypeOccurrence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RootCauseAnalysis_ActionPlain_ActionPlainId",
                table: "RootCauseAnalysis",
                column: "ActionPlainId",
                principalTable: "ActionPlain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RootCauseAnalysis_OccurrenceRegister_OccurrenceRegisterId",
                table: "RootCauseAnalysis",
                column: "OccurrenceRegisterId",
                principalTable: "OccurrenceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VerificationOfEffectiveness_OccurrenceRegister_OccurrenceRe~",
                table: "VerificationOfEffectiveness",
                column: "OccurrenceRegisterId",
                principalTable: "OccurrenceRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

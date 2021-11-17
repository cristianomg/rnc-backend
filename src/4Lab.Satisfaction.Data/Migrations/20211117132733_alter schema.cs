using Microsoft.EntityFrameworkCore.Migrations;

namespace _4Lab.Satisfaction.Data.Migrations
{
    public partial class alterschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "WhySearch",
                newName: "WhySearch",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "TecnicalArea",
                newName: "TecnicalArea",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "SatisfactionSurveys",
                newName: "SatisfactionSurveys",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "Sanitation",
                newName: "Sanitation",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "Reception",
                newName: "Reception",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "PersonalInformations",
                newName: "PersonalInformations",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "OverallImpression",
                newName: "OverallImpression",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "OurDifferential",
                newName: "OurDifferential",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "HowSatisfied",
                newName: "HowSatisfied",
                newSchema: "Satisfaction");

            migrationBuilder.RenameTable(
                name: "DeliveryResults",
                newName: "DeliveryResults",
                newSchema: "Satisfaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "WhySearch",
                schema: "Satisfaction",
                newName: "WhySearch");

            migrationBuilder.RenameTable(
                name: "TecnicalArea",
                schema: "Satisfaction",
                newName: "TecnicalArea");

            migrationBuilder.RenameTable(
                name: "SatisfactionSurveys",
                schema: "Satisfaction",
                newName: "SatisfactionSurveys");

            migrationBuilder.RenameTable(
                name: "Sanitation",
                schema: "Satisfaction",
                newName: "Sanitation");

            migrationBuilder.RenameTable(
                name: "Reception",
                schema: "Satisfaction",
                newName: "Reception");

            migrationBuilder.RenameTable(
                name: "PersonalInformations",
                schema: "Satisfaction",
                newName: "PersonalInformations");

            migrationBuilder.RenameTable(
                name: "OverallImpression",
                schema: "Satisfaction",
                newName: "OverallImpression");

            migrationBuilder.RenameTable(
                name: "OurDifferential",
                schema: "Satisfaction",
                newName: "OurDifferential");

            migrationBuilder.RenameTable(
                name: "HowSatisfied",
                schema: "Satisfaction",
                newName: "HowSatisfied");

            migrationBuilder.RenameTable(
                name: "DeliveryResults",
                schema: "Satisfaction",
                newName: "DeliveryResults");
        }
    }
}

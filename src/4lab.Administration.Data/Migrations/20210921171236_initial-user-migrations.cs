using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4lab.Administration.Data.Migrations
{
    public partial class initialusermigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Administration");

            migrationBuilder.CreateTable(
                name: "UserAuth",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 9, 21, 14, 12, 36, 571, DateTimeKind.Local).AddTicks(5763)),
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
                schema: "Administration",
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
                name: "User",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Enrollment = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SetorId = table.Column<int>(type: "integer", nullable: false),
                    UserAuthId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserPermissionId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 9, 21, 14, 12, 36, 579, DateTimeKind.Local).AddTicks(7302)),
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
                        principalSchema: "Administration",
                        principalTable: "UserAuth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserPermission_UserPermissionId",
                        column: x => x.UserPermissionId,
                        principalSchema: "Administration",
                        principalTable: "UserPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Administration",
                table: "UserPermission",
                columns: new[] { "Id", "Active", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 9, 21, 14, 12, 36, 587, DateTimeKind.Local).AddTicks(7584), null, "Employee", null, null },
                    { 2, true, new DateTime(2021, 9, 21, 14, 12, 36, 587, DateTimeKind.Local).AddTicks(8418), null, "Supervisor", null, null },
                    { 3, true, new DateTime(2021, 9, 21, 14, 12, 36, 587, DateTimeKind.Local).AddTicks(8927), null, "QualityBiomedical", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Enrollment",
                schema: "Administration",
                table: "User",
                column: "Enrollment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserAuthId",
                schema: "Administration",
                table: "User",
                column: "UserAuthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserPermissionId",
                schema: "Administration",
                table: "User",
                column: "UserPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuth_Email",
                schema: "Administration",
                table: "UserAuth",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "UserAuth",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "UserPermission",
                schema: "Administration");
        }
    }
}

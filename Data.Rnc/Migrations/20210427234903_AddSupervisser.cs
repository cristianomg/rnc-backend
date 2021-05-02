using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Rnc.Migrations
{
    public partial class AddSupervisser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Setor_SetorId",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 49, 2, 2, DateTimeKind.Local).AddTicks(7087),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 4, 11, 17, 16, 39, 150, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 27, 20, 49, 2, 12, DateTimeKind.Local).AddTicks(5582),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 4, 11, 17, 16, 39, 156, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Setor",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 29, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 26, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 26, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 26, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 26, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 26, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 26, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 26, DateTimeKind.Local).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 27, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 27, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 23, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 23, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 27, 20, 49, 2, 23, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.CreateIndex(
                name: "IX_Setor_SupervisorId",
                table: "Setor",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Setor_User_SupervisorId",
                table: "Setor",
                column: "SupervisorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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
                name: "FK_Setor_User_SupervisorId",
                table: "Setor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Setor_SetorId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Setor_SupervisorId",
                table: "Setor");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Setor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAuth",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 11, 17, 16, 39, 150, DateTimeKind.Local).AddTicks(6154),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 49, 2, 2, DateTimeKind.Local).AddTicks(7087));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 11, 17, 16, 39, 156, DateTimeKind.Local).AddTicks(2089),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 27, 20, 49, 2, 12, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "NonCompliance",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "Setor",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "TypeNonCompliance",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "UserPermission",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Setor_SetorId",
                table: "User",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

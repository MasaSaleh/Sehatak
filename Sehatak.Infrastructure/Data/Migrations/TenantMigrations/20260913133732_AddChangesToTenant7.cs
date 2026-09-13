using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sehatak.Infrastructure.Data.Migrations.TenantMigrations
{
    /// <inheritdoc />
    public partial class AddChangesToTenant7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lab_requests_doctors_DoctorId",
                table: "lab_requests");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "lab_requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RequestedByUserId",
                table: "lab_requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "lab_request_items",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<string>(
                name: "ResultFileUrl",
                table: "lab_request_items",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "ResultValue",
                table: "lab_request_items",
                type: "decimal(10,3)",
                precision: 10,
                scale: 3,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lab_requests_RequestedByUserId",
                table: "lab_requests",
                column: "RequestedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_lab_requests_doctors_DoctorId",
                table: "lab_requests",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lab_requests_users_RequestedByUserId",
                table: "lab_requests",
                column: "RequestedByUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lab_requests_doctors_DoctorId",
                table: "lab_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_lab_requests_users_RequestedByUserId",
                table: "lab_requests");

            migrationBuilder.DropIndex(
                name: "IX_lab_requests_RequestedByUserId",
                table: "lab_requests");

            migrationBuilder.DropColumn(
                name: "RequestedByUserId",
                table: "lab_requests");

            migrationBuilder.DropColumn(
                name: "ResultFileUrl",
                table: "lab_request_items");

            migrationBuilder.DropColumn(
                name: "ResultValue",
                table: "lab_request_items");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "lab_requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "lab_request_items",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_lab_requests_doctors_DoctorId",
                table: "lab_requests",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

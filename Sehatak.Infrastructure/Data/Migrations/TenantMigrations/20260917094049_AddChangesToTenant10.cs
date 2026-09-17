using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sehatak.Infrastructure.Data.Migrations.TenantMigrations
{
    /// <inheritdoc />
    public partial class AddChangesToTenant10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabRequestId",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_LabRequestId",
                table: "payments",
                column: "LabRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_lab_requests_LabRequestId",
                table: "payments",
                column: "LabRequestId",
                principalTable: "lab_requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_lab_requests_LabRequestId",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_LabRequestId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "LabRequestId",
                table: "payments");
        }
    }
}

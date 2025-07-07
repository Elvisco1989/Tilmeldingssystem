using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tilmeldingssystem.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ActivityId",
                table: "Registrations",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_MemberId",
                table: "Registrations",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Activities_ActivityId",
                table: "Registrations",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Members_MemberId",
                table: "Registrations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Activities_ActivityId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Members_MemberId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_ActivityId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_MemberId",
                table: "Registrations");
        }
    }
}

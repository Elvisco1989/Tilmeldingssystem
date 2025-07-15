using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tilmeldingssystem.Migrations
{
    /// <inheritdoc />
    public partial class TicketTicketMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MemberId",
                table: "Tickets",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Members_MemberId",
                table: "Tickets",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Members_MemberId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MemberId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Tickets");
        }
    }
}

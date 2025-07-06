using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tilmeldingssystem.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Registrations",
                newName: "RegistrationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Members",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clubs",
                newName: "ClubId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Activities",
                newName: "ActivityId");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.RenameColumn(
                name: "RegistrationId",
                table: "Registrations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "Clubs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "Activities",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

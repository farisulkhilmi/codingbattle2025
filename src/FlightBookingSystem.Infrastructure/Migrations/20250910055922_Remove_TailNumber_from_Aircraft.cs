using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_TailNumber_from_Aircraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TailNumber",
                table: "Aircrafts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TailNumber",
                table: "Aircrafts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityTransportation.Data.Migrations
{
    public partial class AddingIsStartedToJourney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerNumber",
                table: "Rooms");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PassengerJourneyStations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "Journeys",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PassengerJourneyStations");

            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "Journeys");

            migrationBuilder.AddColumn<int>(
                name: "PassengerNumber",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

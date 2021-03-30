using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityTransportation.Data.Migrations
{
    public partial class FixDriverAndPassenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Drivers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Passengers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

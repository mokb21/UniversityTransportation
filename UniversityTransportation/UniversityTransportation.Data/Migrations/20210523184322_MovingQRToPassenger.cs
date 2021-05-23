using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityTransportation.Data.Migrations
{
    public partial class MovingQRToPassenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "Drivers");

            migrationBuilder.AddColumn<Guid>(
                name: "QRCode",
                table: "Passengers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "Passengers");

            migrationBuilder.AddColumn<Guid>(
                name: "QRCode",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

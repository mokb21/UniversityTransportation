using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityTransportation.Data.Migrations
{
    public partial class AddingDriverAndPassenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QRCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BusBuiltNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfChairs = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DriverId",
                table: "AspNetUsers",
                column: "DriverId",
                unique: true,
                filter: "[DriverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PassengerId",
                table: "AspNetUsers",
                column: "PassengerId",
                unique: true,
                filter: "[PassengerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Drivers_DriverId",
                table: "AspNetUsers",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Passengers_PassengerId",
                table: "AspNetUsers",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Drivers_DriverId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Passengers_PassengerId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DriverId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PassengerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}

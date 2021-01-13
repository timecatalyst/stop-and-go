using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nymbus.Domain.Migrations
{
    public partial class AdditionalVenueProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatingCapacity",
                table: "Venues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Venues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketsUrl",
                table: "Venues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Venues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatingCapacity",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "TicketsUrl",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "Venues");
        }
    }
}

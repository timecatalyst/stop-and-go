using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class AddGeocodeFieldsToSponsorLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "SponsorLocations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "SponsorLocations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddColumn<bool>(
                name: "InvalidAddress",
                table: "SponsorLocations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "SponsorLocations",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvalidAddress",
                table: "SponsorLocations");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "SponsorLocations");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "SponsorLocations",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "SponsorLocations",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}

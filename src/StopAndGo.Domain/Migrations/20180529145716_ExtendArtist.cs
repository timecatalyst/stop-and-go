using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nymbus.Domain.Migrations
{
    public partial class ExtendArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Artists",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchandiseUrl",
                table: "Artists",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Artists",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "MerchandiseUrl",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "Artists");
        }
    }
}

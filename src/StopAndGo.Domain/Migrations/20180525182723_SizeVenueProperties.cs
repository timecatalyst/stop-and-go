using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Nymbus.Domain.Migrations
{
    public partial class SizeVenueProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WebsiteUrl",
                table: "Venues",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketsUrl",
                table: "Venues",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Venues",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WebsiteUrl",
                table: "Venues",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketsUrl",
                table: "Venues",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Venues",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}

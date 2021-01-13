using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class ChangeStartTimeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "EventArtists",
                nullable: true,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "EventArtists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

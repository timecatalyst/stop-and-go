using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class SongAndSetSongProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeatsPerMinute",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "BeatsPerMinute",
                table: "SetSongs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CueStackId",
                table: "SetSongs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeatsPerMinute",
                table: "SetSongs");

            migrationBuilder.DropColumn(
                name: "CueStackId",
                table: "SetSongs");

            migrationBuilder.AddColumn<int>(
                name: "BeatsPerMinute",
                table: "Songs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Songs",
                nullable: false,
                defaultValue: 0);
        }
    }
}

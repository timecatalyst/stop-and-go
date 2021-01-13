using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class ChangeEventStartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtist_Sets_SetId",
                table: "EventArtist");

            migrationBuilder.DropColumn(
                name: "StartDateAndTime",
                table: "Events");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                type: "date",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtist_Sets_SetId",
                table: "EventArtist",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtist_Sets_SetId",
                table: "EventArtist");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Events");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDateAndTime",
                table: "Events",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtist_Sets_SetId",
                table: "EventArtist",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

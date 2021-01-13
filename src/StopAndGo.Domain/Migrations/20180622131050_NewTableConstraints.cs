using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class NewTableConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                table: "EventArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                table: "EventArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                table: "EventArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                table: "EventArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

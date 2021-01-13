using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class PluralizeEventArtists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtist_Artists_ArtistId",
                table: "EventArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_EventArtist_Events_EventId",
                table: "EventArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_EventArtist_Sets_SetId",
                table: "EventArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventArtist",
                table: "EventArtist");

            migrationBuilder.RenameTable(
                name: "EventArtist",
                newName: "EventArtists");

            migrationBuilder.RenameIndex(
                name: "IX_EventArtist_SetId",
                table: "EventArtists",
                newName: "IX_EventArtists_SetId");

            migrationBuilder.RenameIndex(
                name: "IX_EventArtist_EventId",
                table: "EventArtists",
                newName: "IX_EventArtists_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventArtist_ArtistId",
                table: "EventArtists",
                newName: "IX_EventArtists_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventArtists",
                table: "EventArtists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                table: "EventArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Events_EventId",
                table: "EventArtists",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtists_Sets_SetId",
                table: "EventArtists",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Artists_ArtistId",
                table: "EventArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Events_EventId",
                table: "EventArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_EventArtists_Sets_SetId",
                table: "EventArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventArtists",
                table: "EventArtists");

            migrationBuilder.RenameTable(
                name: "EventArtists",
                newName: "EventArtist");

            migrationBuilder.RenameIndex(
                name: "IX_EventArtists_SetId",
                table: "EventArtist",
                newName: "IX_EventArtist_SetId");

            migrationBuilder.RenameIndex(
                name: "IX_EventArtists_EventId",
                table: "EventArtist",
                newName: "IX_EventArtist_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventArtists_ArtistId",
                table: "EventArtist",
                newName: "IX_EventArtist_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventArtist",
                table: "EventArtist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtist_Artists_ArtistId",
                table: "EventArtist",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtist_Events_EventId",
                table: "EventArtist",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventArtist_Sets_SetId",
                table: "EventArtist",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

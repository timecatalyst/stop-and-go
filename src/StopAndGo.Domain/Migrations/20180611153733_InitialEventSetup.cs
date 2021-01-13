using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class InitialEventSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 50, nullable: true),
                    Headliner = table.Column<string>(maxLength: 50, nullable: true),
                    VenueId = table.Column<int>(nullable: false),
                    StartDateAndTime = table.Column<DateTimeOffset>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 1024, nullable: true),
                    ColorPalette = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventArtist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false),
                    SetId = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventArtist_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventArtist_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventArtist_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventArtist_ArtistId",
                table: "EventArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_EventArtist_EventId",
                table: "EventArtist",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventArtist_SetId",
                table: "EventArtist",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventArtist");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}

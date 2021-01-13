using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class SponsorLocationsAndContentPromotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostShowNotificationTitle = table.Column<string>(maxLength: 30, nullable: false),
                    PostShowNotificationBody = table.Column<string>(maxLength: 100, nullable: false),
                    GeofenceNotificationTitle = table.Column<string>(maxLength: 30, nullable: false),
                    GeofenceNotificationBody = table.Column<string>(maxLength: 100, nullable: false),
                    AvailableStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    AvailableEndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPromotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SponsorLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Address = table.Column<string>(maxLength: 1024, nullable: false),
                    Latitude = table.Column<string>(maxLength: 25, nullable: false),
                    Longitude = table.Column<string>(maxLength: 25, nullable: false),
                    GeofenceRadius = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SponsorLocationContentPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponsorLocationId = table.Column<int>(nullable: false),
                    ContentPromotionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorLocationContentPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SponsorLocationContentPromotions_ContentPromotions_ContentPromotionId",
                        column: x => x.ContentPromotionId,
                        principalTable: "ContentPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SponsorLocationContentPromotions_SponsorLocations_SponsorLocationId",
                        column: x => x.SponsorLocationId,
                        principalTable: "SponsorLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SponsorLocationContentPromotions_ContentPromotionId",
                table: "SponsorLocationContentPromotions",
                column: "ContentPromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorLocationContentPromotions_SponsorLocationId",
                table: "SponsorLocationContentPromotions",
                column: "SponsorLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SponsorLocationContentPromotions");

            migrationBuilder.DropTable(
                name: "ContentPromotions");

            migrationBuilder.DropTable(
                name: "SponsorLocations");
        }
    }
}

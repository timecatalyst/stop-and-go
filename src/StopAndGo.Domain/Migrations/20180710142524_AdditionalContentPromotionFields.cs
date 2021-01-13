using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class AdditionalContentPromotionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "ContentPromotions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContentLink",
                table: "ContentPromotions",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContentPromotions",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPromotions_ArtistId",
                table: "ContentPromotions",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentPromotions_Artists_ArtistId",
                table: "ContentPromotions",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentPromotions_Artists_ArtistId",
                table: "ContentPromotions");

            migrationBuilder.DropIndex(
                name: "IX_ContentPromotions_ArtistId",
                table: "ContentPromotions");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ContentPromotions");

            migrationBuilder.DropColumn(
                name: "ContentLink",
                table: "ContentPromotions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContentPromotions");
        }
    }
}

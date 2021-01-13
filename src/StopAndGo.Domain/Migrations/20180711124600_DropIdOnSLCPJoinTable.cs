using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class DropIdOnSLCPJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SponsorLocationContentPromotions",
                table: "SponsorLocationContentPromotions");

            migrationBuilder.DropIndex(
                name: "IX_SponsorLocationContentPromotions_SponsorLocationId",
                table: "SponsorLocationContentPromotions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SponsorLocationContentPromotions");

            migrationBuilder.AlterColumn<string>(
                name: "PostShowNotificationBody",
                table: "ContentPromotions",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "GeofenceNotificationBody",
                table: "ContentPromotions",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SponsorLocationContentPromotions",
                table: "SponsorLocationContentPromotions",
                columns: new[] { "SponsorLocationId", "ContentPromotionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SponsorLocationContentPromotions",
                table: "SponsorLocationContentPromotions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SponsorLocationContentPromotions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PostShowNotificationBody",
                table: "ContentPromotions",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "GeofenceNotificationBody",
                table: "ContentPromotions",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SponsorLocationContentPromotions",
                table: "SponsorLocationContentPromotions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorLocationContentPromotions_SponsorLocationId",
                table: "SponsorLocationContentPromotions",
                column: "SponsorLocationId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class AddUserContentPromotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserContentPromotions",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ContentPromotionId = table.Column<int>(nullable: false),
                    UnlockedCount = table.Column<int>(nullable: false),
                    UnlockedUntil = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContentPromotions", x => new { x.UserId, x.ContentPromotionId });
                    table.ForeignKey(
                        name: "FK_UserContentPromotions_ContentPromotions_ContentPromotionId",
                        column: x => x.ContentPromotionId,
                        principalTable: "ContentPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContentPromotions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserContentPromotions_ContentPromotionId",
                table: "UserContentPromotions",
                column: "ContentPromotionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserContentPromotions");
        }
    }
}

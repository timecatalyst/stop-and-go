using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class RenameContentLinkField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContentLink",
                table: "ContentPromotions",
                newName: "ContentUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContentUrl",
                table: "ContentPromotions",
                newName: "ContentLink");
        }
    }
}

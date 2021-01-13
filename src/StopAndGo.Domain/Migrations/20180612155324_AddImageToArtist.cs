using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class AddImageToArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Artists",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Artists");
        }
    }
}

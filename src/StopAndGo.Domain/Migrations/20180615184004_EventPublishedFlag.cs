using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class EventPublishedFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Events",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Events");
        }
    }
}

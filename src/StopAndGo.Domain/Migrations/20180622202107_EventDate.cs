using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class EventDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Events",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "StartDate");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class FacebookData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeMax",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgeMin",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeMax",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AgeMin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class passwordreset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "PasswordResetTokenExpirationDate",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpirationDate",
                table: "AspNetUsers");
        }
    }
}

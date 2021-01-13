using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nymbus.Domain.Migrations
{
    public partial class ClapToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClapToPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventArtistId = table.Column<int>(nullable: false),
                    SetSongId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 1024, nullable: false),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClapToPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClapToPosts_EventArtists_EventArtistId",
                        column: x => x.EventArtistId,
                        principalTable: "EventArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClapToPosts_SetSongs_SetSongId",
                        column: x => x.SetSongId,
                        principalTable: "SetSongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClapToPostImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClapToPostId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClapToPostImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClapToPostImages_ClapToPosts_ClapToPostId",
                        column: x => x.ClapToPostId,
                        principalTable: "ClapToPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClapToPostImages_ClapToPostId",
                table: "ClapToPostImages",
                column: "ClapToPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ClapToPosts_EventArtistId",
                table: "ClapToPosts",
                column: "EventArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ClapToPosts_SetSongId",
                table: "ClapToPosts",
                column: "SetSongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClapToPostImages");

            migrationBuilder.DropTable(
                name: "ClapToPosts");
        }
    }
}

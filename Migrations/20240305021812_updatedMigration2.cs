using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class updatedMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Songs_SongId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_SongId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "integer", nullable: false),
                    SongsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    SongsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongsId",
                table: "ArtistSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsId",
                table: "GenreSong",
                column: "SongsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Genres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SongId",
                table: "Genres",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Songs_SongId",
                table: "Genres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id");
        }
    }
}

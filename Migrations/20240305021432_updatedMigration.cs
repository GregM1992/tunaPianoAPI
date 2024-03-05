using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class updatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

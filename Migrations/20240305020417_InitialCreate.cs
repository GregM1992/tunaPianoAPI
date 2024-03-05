using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, 28, "Staring ContestFollowing the 1995 dissolution of the quirky art-pop band Heavy Vegetable, guitarist/singer/songwriter Rob Crow and lead singer Eléa Tenuta regrouped in Thingy, which turned into one of the restless and prolific Crow's main creative outlets", "Thingy" },
                    { 2, 5, "Purple Mountains was an American indie rock project formed by musician and poet David Berman. The project debuted in May 2019, over a decade after the dissolution of Berman's previous group Silver Jews. An eponymous album was released in July 2019.", "Purple Mountains" },
                    { 3, 15, "It's a long story", "Ovlov" },
                    { 4, 20, "Tera Melos is an American math rock band from Sacramento, California, formed in 2004. They incorporate many styles of rock, ambient electronics and unconventional song structures.", "Tera Melos" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Math Rock" },
                    { 2, "Americana" },
                    { 3, "Alternative Rock" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Morbid Curiosity", 1, "1:11 minutes", "Enderbachie" },
                    { 2, "Morbid Curiosity", 1, "1:19 minutes", "San Diego Rock Song About People Talking In The Movie Theatre" },
                    { 3, "Purple Mountains", 2, "4:11 minutes", "She's Making Friends, I'm Turning Stranger" },
                    { 4, "Purple Mountains", 2, "6:08 minutes", "Nights That Wont Happen" },
                    { 5, "Buds", 3, "2:50 minutes", "Land Of Steve-O" },
                    { 6, "Buds", 3, " 4:48 minutes", "Feel The Pain" },
                    { 7, "TRU", 3, "2:00 minutes", "Short Morgan" },
                    { 8, "X'ed Out", 4, "3:05 minutes", "Weird Circles" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}

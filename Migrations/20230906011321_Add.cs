using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Songid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Songid);
                    table.ForeignKey(
                        name: "FK_Song_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresGenreId = table.Column<int>(type: "integer", nullable: false),
                    SongsSongid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresGenreId, x.SongsSongid });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genre_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Song_SongsSongid",
                        column: x => x.SongsSongid,
                        principalTable: "Song",
                        principalColumn: "Songid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "Age", "Name", "bio" },
                values: new object[,]
                {
                    { 103, 25, "Dolly Parton", "American singer song writer" },
                    { 104, 74, "Elton John", "British singer-songwriter and pianist" },
                    { 105, 39, "Beyoncé", "American singer, songwriter, and actress" },
                    { 106, 50, "Michael Jackson", "American singer, songwriter, and dancer" },
                    { 107, 33, "Adele", "British singer-songwriter" },
                    { 108, 36, "Bruno Mars", "American singer, songwriter, and record producer" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Description" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "R&B" },
                    { 4, "Hip-Hop" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Songid", "Album", "ArtistId", "Title", "length" },
                values: new object[,]
                {
                    { 3, "Album3", 105, "Song3", "3:55" },
                    { 4, "Album4", 106, "Song4", "4:10" },
                    { 5, "Album5", 107, "Song5", "4:30" },
                    { 6, "Album6", 108, "Song6", "3:40" },
                    { 7, "Album7", 103, "Song7", "4:00" },
                    { 8, "Album8", 104, "Song8", "3:25" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsSongid",
                table: "GenreSong",
                column: "SongsSongid");

            migrationBuilder.CreateIndex(
                name: "IX_Song_ArtistId",
                table: "Song",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}

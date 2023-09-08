using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class updatedgenreclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreSong_Genre_GenresGenreId",
                table: "GenreSong");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "GenreSong",
                newName: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSong_Genre_GenreId",
                table: "GenreSong",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreSong_Genre_GenreId",
                table: "GenreSong");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GenreSong",
                newName: "GenresGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSong_Genre_GenresGenreId",
                table: "GenreSong",
                column: "GenresGenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

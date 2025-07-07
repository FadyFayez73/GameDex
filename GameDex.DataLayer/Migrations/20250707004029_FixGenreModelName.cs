using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDex.DataLayer.Migrations
{
    public partial class FixGenreModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    GenresGenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesGameID, x.GenresGenreID });
                    table.ForeignKey(
                        name: "FK_GameGenre_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenresGenreID",
                        column: x => x.GenresGenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresGenreID",
                table: "GameGenre",
                column: "GenresGenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    GenresGenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => new { x.GamesGameID, x.GenresGenreID });
                    table.ForeignKey(
                        name: "FK_GameGenres_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenresGenreID",
                        column: x => x.GenresGenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenresGenreID",
                table: "GameGenres",
                column: "GenresGenreID");
        }
    }
}

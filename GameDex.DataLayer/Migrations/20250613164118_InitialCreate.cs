using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDex.DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfRelease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PGRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameEngine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderOfFranchise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkForCrack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriticsRating = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    PlayersRating = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    UserRating = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    SteamPrices = table.Column<decimal>(type: "Decimal(7,2)", nullable: false),
                    ActualGameSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameFiles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursToComplete = table.Column<int>(type: "int", nullable: false),
                    PlayerHours = table.Column<int>(type: "int", nullable: false),
                    StoryPlace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "ModManagers",
                columns: table => new
                {
                    ModManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModManagers", x => x.ModManagerID);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformID);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Albums_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "ChapterMissions",
                columns: table => new
                {
                    ChapterMissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterMissions", x => x.ChapterMissionID);
                    table.ForeignKey(
                        name: "FK_ChapterMissions_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Characters_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "CompanyGame",
                columns: table => new
                {
                    CompaniesCompanyID = table.Column<int>(type: "int", nullable: false),
                    GamesGameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGame", x => new { x.CompaniesCompanyID, x.GamesGameID });
                    table.ForeignKey(
                        name: "FK_CompanyGame_Companys_CompaniesCompanyID",
                        column: x => x.CompaniesCompanyID,
                        principalTable: "Companys",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyGame_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    ControlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.ControlID);
                    table.ForeignKey(
                        name: "FK_Controls_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "DLCs",
                columns: table => new
                {
                    DLCID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCs", x => x.DLCID);
                    table.ForeignKey(
                        name: "FK_DLCs_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    MediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.MediaID);
                    table.ForeignKey(
                        name: "FK_Medias_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    PerformanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraphicsQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Low1PercentFPS = table.Column<int>(type: "int", nullable: false),
                    AverageFPS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxFPS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.PerformanceID);
                    table.ForeignKey(
                        name: "FK_Performances_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    RequirementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemOS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Memory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Network = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoundCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.RequirementID);
                    table.ForeignKey(
                        name: "FK_Requirements_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

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

            migrationBuilder.CreateTable(
                name: "GameModManager",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    ModManagersModManagerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModManager", x => new { x.GamesGameID, x.ModManagersModManagerID });
                    table.ForeignKey(
                        name: "FK_GameModManager_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameModManager_ModManagers_ModManagersModManagerID",
                        column: x => x.ModManagersModManagerID,
                        principalTable: "ModManagers",
                        principalColumn: "ModManagerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    PlatformsPlatformID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GamesGameID, x.PlatformsPlatformID });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformsPlatformID",
                        column: x => x.PlatformsPlatformID,
                        principalTable: "Platforms",
                        principalColumn: "PlatformID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscNumber = table.Column<int>(type: "int", nullable: false),
                    TrackNumber = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albums",
                        principalColumn: "AlbumID");
                });

            migrationBuilder.CreateTable(
                name: "ChapterMissionCharacter",
                columns: table => new
                {
                    ChapterMissionsChapterMissionID = table.Column<int>(type: "int", nullable: false),
                    CharactersCharacterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterMissionCharacter", x => new { x.ChapterMissionsChapterMissionID, x.CharactersCharacterID });
                    table.ForeignKey(
                        name: "FK_ChapterMissionCharacter_ChapterMissions_ChapterMissionsChapterMissionID",
                        column: x => x.ChapterMissionsChapterMissionID,
                        principalTable: "ChapterMissions",
                        principalColumn: "ChapterMissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterMissionCharacter_Characters_CharactersCharacterID",
                        column: x => x.CharactersCharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterID", "Description", "GameID", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, "A witcher and the main protagonist of The Witcher series.", null, "", "Geralt of Rivia" },
                    { 2, "The Child of Prophecy, a powerful source of Elder Blood.", null, "", "Ciri" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "ActualGameSize", "CriticsRating", "GameDescription", "GameEngine", "GameFiles", "GamePath", "HoursToComplete", "LinkForCrack", "Name", "OrderOfFranchise", "PGRating", "Patch", "PlayerHours", "PlayersRating", "SteamPrices", "StoryPlace", "UserRating", "YearOfRelease" },
                values: new object[] { 1, "57 GB", 9.6m, "One of the most acclaimed RPGs of all time. Now ready for a new generation...", "REDengine 3", "", "D:\\SteamLibrary\\steamapps\\common\\The Witcher 3\\REDprelauncher.exe", 174, "", "The Witcher 3: Wild Hunt", "3", "18 over", "4.04", 60, 10m, 37.99m, "Temerian (southern) side of the Pontar in Velen", 10m, "May 2015" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformID", "Name" },
                values: new object[,]
                {
                    { 1, "PC" },
                    { 2, "PlayStation 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GameID",
                table: "Albums",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterMissionCharacter_CharactersCharacterID",
                table: "ChapterMissionCharacter",
                column: "CharactersCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterMissions_GameID",
                table: "ChapterMissions",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameID",
                table: "Characters",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGame_GamesGameID",
                table: "CompanyGame",
                column: "GamesGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_GameID",
                table: "Controls",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_DLCs_GameID",
                table: "DLCs",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenresGenreID",
                table: "GameGenres",
                column: "GenresGenreID");

            migrationBuilder.CreateIndex(
                name: "IX_GameModManager_ModManagersModManagerID",
                table: "GameModManager",
                column: "ModManagersModManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformsPlatformID",
                table: "GamePlatform",
                column: "PlatformsPlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_GameID",
                table: "Medias",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_GameID",
                table: "Performances",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_GameID",
                table: "Requirements",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterMissionCharacter");

            migrationBuilder.DropTable(
                name: "CompanyGame");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "DLCs");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "GameModManager");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "ChapterMissions");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "ModManagers");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}

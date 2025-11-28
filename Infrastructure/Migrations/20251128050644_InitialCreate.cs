using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Patch = table.Column<string>(type: "TEXT", nullable: true),
                    GamePath = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfRelease = table.Column<string>(type: "TEXT", nullable: true),
                    PGRating = table.Column<string>(type: "TEXT", nullable: false),
                    GameDescription = table.Column<string>(type: "TEXT", nullable: true),
                    GameEngine = table.Column<string>(type: "TEXT", nullable: false),
                    OrderOfFranchise = table.Column<string>(type: "TEXT", nullable: true),
                    LinkForCrack = table.Column<string>(type: "TEXT", nullable: true),
                    CriticsRating = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    PlayersRating = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    UserRating = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    SteamPrices = table.Column<decimal>(type: "Decimal(7,2)", nullable: false),
                    ActualGameSize = table.Column<string>(type: "TEXT", nullable: false),
                    GameFiles = table.Column<string>(type: "TEXT", nullable: true),
                    HoursToComplete = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerHours = table.Column<int>(type: "INTEGER", nullable: false),
                    StoryPlace = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "ModManagers",
                columns: table => new
                {
                    ModManagerID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModManagers", x => x.ModManagerID);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformID);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<string>(type: "TEXT", nullable: false),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Albums_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterMissions",
                columns: table => new
                {
                    ChapterMissionID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterMissions", x => x.ChapterMissionID);
                    table.ForeignKey(
                        name: "FK_ChapterMissions_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Characters_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyGames",
                columns: table => new
                {
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGames", x => new { x.GameID, x.CompanyID, x.Role });
                    table.ForeignKey(
                        name: "FK_CompanyGames_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyGames_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    ControlID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ControlType = table.Column<string>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.ControlID);
                    table.ForeignKey(
                        name: "FK_Controls_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLCs",
                columns: table => new
                {
                    DLCID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCs", x => x.DLCID);
                    table.ForeignKey(
                        name: "FK_DLCs_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    MediaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaType = table.Column<string>(type: "TEXT", nullable: false),
                    MediaPath = table.Column<string>(type: "TEXT", nullable: false),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.MediaID);
                    table.ForeignKey(
                        name: "FK_Medias_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    PerformanceID = table.Column<Guid>(type: "TEXT", nullable: false),
                    GraphicsQuality = table.Column<string>(type: "TEXT", nullable: false),
                    Low1PercentFPS = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageFPS = table.Column<string>(type: "TEXT", nullable: false),
                    MaxFPS = table.Column<string>(type: "TEXT", nullable: false),
                    TestDate = table.Column<string>(type: "TEXT", nullable: false),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.PerformanceID);
                    table.ForeignKey(
                        name: "FK_Performances_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    RequirementID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RequirementType = table.Column<int>(type: "INTEGER", nullable: false),
                    SystemOS = table.Column<string>(type: "TEXT", nullable: false),
                    Processor = table.Column<string>(type: "TEXT", nullable: false),
                    Memory = table.Column<string>(type: "TEXT", nullable: false),
                    Graphics = table.Column<string>(type: "TEXT", nullable: false),
                    Network = table.Column<string>(type: "TEXT", nullable: false),
                    Storage = table.Column<string>(type: "TEXT", nullable: false),
                    SoundCard = table.Column<string>(type: "TEXT", nullable: false),
                    DirectX = table.Column<string>(type: "TEXT", nullable: false),
                    GameID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.RequirementID);
                    table.ForeignKey(
                        name: "FK_Requirements_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesGameID = table.Column<Guid>(type: "TEXT", nullable: false),
                    GenresGenreID = table.Column<Guid>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "GameModManager",
                columns: table => new
                {
                    GamesGameID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModManagersModManagerID = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    GamesGameID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlatformsPlatformID = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    SongID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DiscNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Detail = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albums",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterMissionCharacter",
                columns: table => new
                {
                    ChapterMissionsChapterMissionID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CharactersCharacterID = table.Column<Guid>(type: "TEXT", nullable: false)
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
                table: "Games",
                columns: new[] { "GameID", "ActualGameSize", "CriticsRating", "GameDescription", "GameEngine", "GameFiles", "GamePath", "HoursToComplete", "LinkForCrack", "Name", "OrderOfFranchise", "PGRating", "Patch", "PlayerHours", "PlayersRating", "SteamPrices", "StoryPlace", "UserRating", "YearOfRelease" },
                values: new object[] { new Guid("052b2a66-a6f6-4865-80bf-7b89175f79db"), "57 GB", 9.6m, "One of the most acclaimed RPGs of all time. Now ready for a new generation...", "REDengine 3", "", "D:\\SteamLibrary\\steamapps\\common\\The Witcher 3\\REDprelauncher.exe", 174, "", "The Witcher 3: Wild Hunt", "3", "18 over", "4.04", 60, 10m, 37.99m, "Temerian (southern) side of the Pontar in Velen", 10m, "May 2015" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformID", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("43b2427b-b32b-4a80-98c2-18b8c6f11934"), "Open-source operating system based on Unix", "Linux" },
                    { new Guid("4f46a6c9-1f94-4a63-9de8-2f85cbe5f05e"), "Microsoft's gaming console platform", "Xbox" },
                    { new Guid("59cfe7d1-6c6e-4d25-95b6-7c9f6b2f9245"), "Apple's operating system for Mac computers", "macOS" },
                    { new Guid("77bba20d-79f2-4a89-9f60-10cc02c0f2cf"), "Nintendo's hybrid gaming console", "Nintendo Switch" },
                    { new Guid("9af20714-09a5-4c83-9f6f-798dc91b1d02"), "Sony's gaming console platform", "PlayStation" },
                    { new Guid("aff935b7-a122-45bf-b343-fb2b84ecfc47"), "Microsoft Windows operating system", "Windows" },
                    { new Guid("b5b8efb3-7f8d-48a3-88b7-6f1a9d85f5c7"), "Apple's mobile operating system", "iOS" },
                    { new Guid("e15e8ef7-8f6b-4e71-9f51-f8658d7f84d9"), "Google's mobile operating system", "Android" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterID", "Description", "GameID", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("24bc0f9d-2749-40ac-bf17-14bcdd8a66eb"), "A witcher and the main protagonist of The Witcher series.", new Guid("052b2a66-a6f6-4865-80bf-7b89175f79db"), "", "Geralt of Rivia" },
                    { new Guid("3ad1890d-573b-44e6-ada2-268dfe65a569"), "The Child of Prophecy, a powerful source of Elder Blood.", new Guid("052b2a66-a6f6-4865-80bf-7b89175f79db"), "", "Ciri" }
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
                name: "IX_CompanyGames_CompanyID",
                table: "CompanyGames",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_GameID",
                table: "Controls",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_DLCs_GameID",
                table: "DLCs",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresGenreID",
                table: "GameGenre",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterMissionCharacter");

            migrationBuilder.DropTable(
                name: "CompanyGames");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "DLCs");

            migrationBuilder.DropTable(
                name: "GameGenre");

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
                name: "Companies");

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

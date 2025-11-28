using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // NOTE: Platforms are already seeded in PlatformTypeConfiguration
            // Only seed additional data like Genres, Companies, Games, etc.

            // Seed Genres
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Name", "Description" },
                values: new object[,]
                {
                    { new Guid("b6e9f67f-ba8d-4191-b778-4d101fc0d164"), "Role-Playing (RPG)", "Focuses on character development, narrative depth, and exploration within immersive worlds." },
                    { new Guid("d558f625-6b6a-4063-bcce-27f9f760c16c"), "Open World", "Offers freedom to explore a large environment without strict mission sequences." },
                    { new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4"), "Action", "Emphasizes real-time combat and fast-paced gameplay often involving reflexes and timing." },
                    { new Guid("01d9862f-34d3-43bd-9f30-3ab343d3a08e"), "Fantasy", "Set in imaginative worlds with magical elements, mythical creatures, and lore-driven settings." },
                    { new Guid("31025975-5234-4607-ac0b-befab1ccd715"), "First-Person Shooter (FPS)", "Gameplay from a first-person viewpoint centered around ranged combat and firearms." },
                    { new Guid("8822f6d8-9efd-4c9e-9d74-2e6aad17c9b0"), "War", "Simulates military scenarios, often set during historical or modern conflicts." },
                    { new Guid("9bba495e-9a51-4ed7-b012-fa14d61db0ea"), "Adventure", "Encourages exploration, story-driven progress, and puzzle-solving over combat intensity." },
                    { new Guid("a4969cf3-28c8-4bb2-b9b8-c59f8ffa71f7"), "Metroidvania", "Combines exploration and platforming with unlockable paths and power-based progression." },
                    { new Guid("bf204804-43af-47ac-8c9c-27086e28895d"), "Platformer", "Gameplay focused on navigating environments using jumps and timing-based movement." },
                    { new Guid("3978bfab-0b37-47fc-935d-7ac3be8d5687"), "Indie", "Created by small development teams, often experimental or artistically unique." },
                    { new Guid("319697b1-3adf-4606-9bf2-d744ee20ba7c"), "Dark Fantasy", "Merges fantasy themes with gothic, eerie, or horror-like settings." },
                    { new Guid("a74257de-4010-4c32-a4f7-1719be29e8f7"), "Souls-like", "Known for challenging gameplay, strategic combat, and minimal guidance or tutorials." },
                    { new Guid("c5833d2f-316f-4f92-af39-d20906139226"), "Survival Horror", "Blends horror with resource management, placing players in tense, dangerous settings." },
                    { new Guid("3c9bfc33-af01-494c-954c-af0f98c32172"), "Story Rich", "Puts strong emphasis on narrative and character-driven storytelling." },
                    { new Guid("dadd0935-0923-4ddd-abaf-4788ba6f95af"), "Western", "Thematic setting in the American Wild West, often involving outlaws and horseback riding." },
                    { new Guid("ee0ea1ea-50b8-4c73-89de-34a6a71cb895"), "Sci-Fi", "Centers around futuristic or space-related settings with advanced technology and alien elements." },
                    { new Guid("783243fe-8182-4001-9de7-863c2fe5ebe6"), "Multiplayer", "Supports cooperative or competitive play with other players in real-time." },
                    { new Guid("479d9d71-b91d-4dfc-8d14-5bc6c4d28aad"), "Military Shooter", "Tactical shooting experience set in realistic military environments." },
                    { new Guid("bfe9872a-c39e-4cb7-bf3e-e3c5ea37d911"), "Third-Person Shooter", "Shooting mechanics from an over-the-shoulder camera angle." },
                    { new Guid("be7e6fc0-fb79-4fc3-8b86-25d2c89c5529"), "Superhero", "Features protagonists with superpowers, saving the world in comic-inspired stories." },
                    { new Guid("6318e2e7-999d-4b1c-83ac-b6cc22b99f7b"), "Teen", "Content suitable for teen audiences, usually balancing action with accessible themes." }
                });

            // Seed Companies
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "Name", "Description" },
                values: new object[,]
                {
                    { new Guid("9F6E1FC8-1BBC-4EBB-BBD7-725E871FBD73"), "CD Projekt Red", "Polish video game developer, established in 2002, known for creating story-driven, award-winning RPGs like The Witcher series and Cyberpunk 2077" },
                    { new Guid("996675D5-EBEA-4E66-9FFB-872D9246B60E"), "Test Company", "Test Company Test Company Test Company Test Company Test Company" },
                    { new Guid("D02F3CBD-5060-4323-81CC-78BA83D6D8B4"), "Test1", "test test test test tset" },
                    { new Guid("48A2CCF6-B71E-40D7-8215-F9207C9F2E02"), "Test2", "test test test test tset" },
                    { new Guid("077AC0F8-DBB8-47F4-ABC6-925C3F977CB7"), "test te", null },
                    { new Guid("186EE05F-2C59-4644-BA42-0DC076F1AB2A"), "Test company", "test test test test tset" },
                    { new Guid("1E987D01-7D2A-4A6E-840A-6FFBBCBF3572"), "Test1", "test test test test tset" }
                });

            // Seed Games
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name", "Patch", "GamePath", "YearOfRelease", "PGRating", "GameDescription", "GameEngine", "OrderOfFranchise", "LinkForCrack", "CriticsRating", "PlayersRating", "UserRating", "SteamPrices", "ActualGameSize", "GameFiles", "HoursToComplete", "PlayerHours", "StoryPlace" },
                values: new object[,]
                {
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), "Red Dead Redemption 2", "v1.31", @"D:\Games\Red Dead Redemption 2\RDR2.exe", "2018", "M (Mature 17+)", "An epic tale of life in America's unforgiving heartland, set in the dying days of the Wild West. Play as Arthur Morgan, an outlaw in the Van der Linde gang.", "RAGE (Rockstar Advanced Game Engine)", "2", "https://cs.rin.ru/forum/viewtopic.php?t=100349", 9.7m, 9.5m, 9.9m, 59.99m, "120 GB", "RDR2.exe, system.xml, audio.dat, packs, update.rpf, ...", 60, 0, "United States – 1899, fictional states including New Hanover, Ambarino, Lemoyne, and West Elizabeth" },
                    { new Guid("D28E8B0A-9567-4C68-8F50-0EA9D36C722F"), "Cyberpunk 2077", "v2.12", @"D:\Games\Cyberpunk 2077\bin\x64\Cyberpunk2077.exe", "2020", "M (Mature 17+)", "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour, and body modification. You play as V, a mercenary outlaw going after a one-of-a-kind implant that is the key to immortality.", "REDengine 4", "1", "https://cs.rin.ru/forum/viewtopic.php?t=104525", 8.6m, 8.8m, 9.0m, 59.99m, "70 GB", "Cyberpunk2077.exe, archive.pak, patch.dat, REDprelauncher.exe, r6 folder, bin folder, ...", 25, 0, "Night City – a fictional city in the Free State of Northern California" },
                    { new Guid("1037AF81-F32A-4252-8322-A7EB04A11EF2"), "Elden Ring", "v1.10", @"D:\Games\Elden Ring\eldenring.exe", "2022", "M (Mature 17+)", "Elden Ring is a fantasy action-RPG adventure set in a vast open world, crafted by FromSoftware and George R. R. Martin. Players explore the Lands Between as the Tarnished, seeking to restore the Elden Ring.", "Souls Engine (Modified internal engine)", "1", "https://cs.rin.ru/forum/viewtopic.php?t=112854", 9.5m, 9.4m, 9.8m, 59.99m, "60 GB", "eldenring.exe, start_protected_game.exe, regulation.bin, content folders...", 50, 0, "The Lands Between – a high fantasy universe created by George R. R. Martin and Hidetaka Miyazaki" },
                    { new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66"), "Resident Evil 4 Remake", "v1.05", @"D:\Games\Resident Evil 4 Remake\re4.exe", "2023", "M (Mature 17+)", "A reimagining of the 2005 classic, Resident Evil 4 follows Leon S. Kennedy on a rescue mission in a mysterious rural European village plagued by a cult and infected villagers.", "RE Engine", "4", "https://cs.rin.ru/forum/viewtopic.php?t=122395", 9.2m, 9.3m, 9.5m, 59.99m, "55 GB", "re4.exe, re_chunk_000.pak, steam_emu.ini, data folders...", 15, 0, "A remote village in rural Spain" },
                    { new Guid("F9A2E6C8-C976-47E1-BBE0-EE9869B22352"), "Hollow Knight", "v1.5.78.11833", @"D:\Games\Hollow Knight\hollow_knight.exe", "2017", "E10+ (Everyone 10+)", "Hollow Knight is a challenging 2D action-adventure set in the ruined kingdom of Hallownest. Explore ancient caverns, battle corrupted creatures, and uncover long-lost secrets.", "Unity", "1", "https://cs.rin.ru/forum/viewtopic.php?t=79625", 9.3m, 9.5m, 10.0m, 14.99m, "9 GB", "hollow_knight.exe, globalgamemanagers.assets, resources.assets, HollowKnight_Data...", 25, 0, "Hallownest – a vast, interconnected underground insect kingdom" },
                    { new Guid("73EA0BE2-6250-43C0-B766-A19829BEE4AE"), "Horizon Zero Dawn", "v1.10.0", @"D:\Games\Horizon Zero Dawn\HorizonZeroDawn.exe", "2017", "T (Teen)", "Horizon Zero Dawn is a visually stunning action RPG set in a post-apocalyptic world ruled by robotic creatures. Play as Aloy, a skilled hunter, as she uncovers her mysterious past and battles machines using tactical combat and stealth.", "Decima", "1", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 8.9m, 9.4m, 9.8m, 49.99m, "100 GB", "HorizonZeroDawn.exe, globalgamemanagers.assets, resources.assets, Horizon_Data...", 60, 0, "Post-apocalyptic United States – across Colorado, Utah, and Wyoming, in a world reclaimed by nature and machines" },
                    { new Guid("30E3AE70-7DAB-446A-9DE5-9DDC7FE4031B"), "Resident Evil Village", "v1.10.3", @"D:\Games\Resident Evil Village\RE_Village.exe", "2021", "M (Mature 17+)", "Resident Evil Village is a first-person survival horror game where you play as Ethan Winters, searching for his kidnapped daughter in a mysterious European village filled with terrifying creatures and twisted secrets.", "RE Engine", "8", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 9.2m, 9.1m, 8.5m, 39.99m, "35 GB", "RE_Village.exe, globalgamemanagers.assets, resources.assets, Village_Data...", 10, 0, "A remote, snowy village in Eastern Europe haunted by Lycans, vampires, and other mutated horrors" },
                    { new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445"), "Marvel's Spider-Man Remastered", "v1.0.0.2", @"D:\Games\Spider-Man Remastered\SpiderMan.exe", "2022", "T (Teen)", "Marvel's Spider-Man Remastered is an action-packed open-world adventure where you play as an experienced Peter Parker. Swing through Marvel's New York, battle iconic villains, and uncover a gripping story that blends superhero action with personal drama.", "Insomniac Engine", "1 (Remastered version of the 2018 original)", "https://cs.rin.ru/forum/viewtopic.php?t=109942", 9.2m, 9.8m, 9.3m, 59.99m, "75 GB", "SpiderMan.exe, globalgamemanagers.assets, resources.assets, SpiderMan_Data...", 20, 0, "Marvel's New York – a vibrant, open-world city filled with iconic landmarks and dynamic neighborhoods" },
                    { new Guid("C39B563E-B5D1-46F3-AD48-C18A51EC2E17"), "Shadow of the Tomb Raider", "v1.0.292.0", @"D:\Games\Shadow of the Tomb Raider\SOTTR.exe", "2018", "M (Mature 17+)", "Shadow of the Tomb Raider is a third-person action-adventure game where Lara Croft must survive a deadly jungle, explore ancient tombs, and stop a Mayan apocalypse she accidentally triggered. The game blends stealth, exploration, and puzzle-solving in richly detailed environments.", "Foundation Engine (modified Crystal Engine)", "12 (3rd in Survivor Trilogy)", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 8.0m, 8.8m, 0.0m, 39.99m, "40 GB", "SOTTR.exe, globalgamemanagers.assets, resources.assets, SOTTR_Data...", 15, 0, "Paititi – a hidden city deep in the Peruvian jungle, rich with Mayan and Incan mythology" },
                    { new Guid("F8850B79-F108-45E6-A18C-D908328512A7"), "The Elder Scrolls V: Skyrim", "v1.9.32.0.8", @"D:\Games\Skyrim\Skyrim.exe", "2011", "M (Mature 17+)", "Skyrim is an epic open-world RPG set in the northern province of Tamriel. As the Dragonborn, you must explore vast landscapes, master powerful shouts, and confront the ancient dragon Alduin to save the world from destruction.", "Creation Engine", "5", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 9.3m, 9.4m, 9.8m, 19.99m, "12 GB", "Skyrim.exe, globalgamemanagers.assets, resources.assets, Skyrim_Data...", 30, 0, "Skyrim – a cold, mountainous region in Tamriel filled with dragons, ancient ruins, and civil war between the Empire and Stormcloaks" },
                    { new Guid("53CBC102-242A-4CBC-97A3-1F1400334628"), "Battlefield V", "v1.10.0", @"D:\Games\Battlefield V\BFV.exe", "2018", "M (Mature 17+)", "Battlefield V is a first-person shooter set during World War II. It features intense multiplayer battles, episodic single-player War Stories, and a battle royale mode called Firestorm. Players engage in large-scale combat across land, air, and sea with a focus on realism, squad tactics, and destructible environments.", "Frostbite 3", "11", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 8.1m, 8.9m, 8.9m, 49.99m, "50 GB", "BFV.exe, globalgamemanagers.assets, resources.assets, BFV_Data...", 10, 0, "Various WWII locations including Norway, North Africa, France, and Germany – each explored through unique War Stories" },
                    { new Guid("FB754D87-9C25-4B15-9AA9-0729A16A1663"), "Rise of the Tomb Raider", "v1.0.292.0", @"D:\Games\Rise of the Tomb Raider\ROTTR.exe", "2015", "M (Mature 17+)", "Rise of the Tomb Raider is a third-person action-adventure game where Lara Croft embarks on a journey to uncover the secret of immortality. Set in the harsh wilderness of Siberia, she explores ancient tombs, solves environmental puzzles, and battles the paramilitary organization Trinity.", "Foundation Engine", "11 (2nd in Survivor Trilogy)", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 8.6m, 9.2m, 0.0m, 29.99m, "25 GB", "ROTTR.exe, globalgamemanagers.assets, resources.assets, ROTTR_Data...", 15, 0, "Siberia – from icy mountains to hidden valleys, including the lost city of Kitezh and Soviet installations" },
                    { new Guid("A89E8B56-B17C-4F9C-99BF-235D7EBF70B2"), "The Last of Us", "v1.9.32.0.8", @"D:\Games\The Last of Us\TLOU.exe", "2013", "M (Mature 17+)", "The Last of Us is a third-person action-adventure game set in a post-apocalyptic United States. You play as Joel, a smuggler tasked with escorting a teenage girl, Ellie, across a dangerous world ravaged by a fungal infection. The game blends stealth, survival, and emotional storytelling in a journey of trust and sacrifice.", "Naughty Dog's proprietary engine", "1", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 9.5m, 9.7m, 9.9m, 59.99m, "50 GB", "TLOU.exe, globalgamemanagers.assets, resources.assets, TLOU_Data...", 15, 0, "Post-apocalyptic United States – from Boston to Salt Lake City, through abandoned towns, forests, and infected zones" },
                    { new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442"), "Call of Duty: Black Ops 6", "v1.0.0", @"D:\Games\Black Ops 6\BO6.exe", "2024", "M (Mature 17+)", "Black Ops 6 is a spy action thriller set in the early 1990s, featuring a mind-bending narrative, intense multiplayer battles, and the return of round-based Zombies. Players go rogue as CIA operatives to uncover a covert paramilitary conspiracy during Operation Desert Storm.", "IW Engine", "7 (Black Ops subseries)", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 8.8m, 9.2m, 0.0m, 69.99m, "309.85 GB", "BO6.exe, globalgamemanagers.assets, resources.assets, BO6_Data...", 12, 0, "Global locations including Iraq, Bulgaria, and Washington D.C. during the Gulf War era, with missions involving espionage, heists, and psychological warfare" },
                    { new Guid("EC0FF6B8-60A0-46F1-817D-A4B0A3B1BA97"), "Battlefield 3", "v1.7.0", @"D:\Games\Battlefield 3\BF3.exe", "2011", "M (Mature 17+)", "Battlefield 3 is a first-person shooter set during a fictional global conflict in 2014. Featuring intense multiplayer battles, a cinematic single-player campaign, and cooperative missions, the game delivers large-scale warfare across land, air, and sea using the powerful Frostbite 2 engine.", "Frostbite 2", "6", "https://cs.rin.ru/forum/viewtopic.php?t=89945", 8.6m, 8.9m, 0.0m, 19.99m, "20 GB", "BF3.exe, globalgamemanagers.assets, resources.assets, BF3_Data...", 8, 0, "Various global locations including Paris, Tehran, New York City, and the Iran-Iraq border during a fictional war involving the U.S., Russia, and a paramilitary group called the PLR" }
                });

            // Seed Medias
            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "MediaID", "MediaType", "MediaPath", "GameID" },
                values: new object[,]
                {
                    { new Guid("16D268D9-93ED-46C6-BECC-64AE44D924DA"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/292030/ad9240e088f953a84aee814034c50a6a92bf4516/header.jpg?t=1749199563", new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1174180/header.jpg?t=1720558643", new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57") },
                    { new Guid("D28E8B0A-9567-4C68-8F50-0EA9D36C722F"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1091500/bc1dbc616ec607e9ea6be88a4698c8b94b895c98/header_alt_assets_8.jpg?t=1752757348", new Guid("D28E8B0A-9567-4C68-8F50-0EA9D36C722F") },
                    { new Guid("1037AF81-F32A-4252-8322-A7EB04A11EF2"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/367520/header.jpg?t=1695270428", new Guid("1037AF81-F32A-4252-8322-A7EB04A11EF2") },
                    { new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2050650/header.jpg?t=1736385712", new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66") },
                    { new Guid("F9A2E6C8-C976-47E1-BBE0-EE9869B22352"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1245620/header.jpg?t=1748630546", new Guid("F9A2E6C8-C976-47E1-BBE0-EE9869B22352") },
                    { new Guid("73EA0BE2-6250-43C0-B766-A19829BEE4AE"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1151640/header.jpg?t=1750105817", new Guid("73EA0BE2-6250-43C0-B766-A19829BEE4AE") },
                    { new Guid("30E3AE70-7DAB-446A-9DE5-9DDC7FE4031B"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1196590/header.jpg?t=1741142800", new Guid("30E3AE70-7DAB-446A-9DE5-9DDC7FE4031B") },
                    { new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1817070/header.jpg?t=1750955096", new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445") },
                    { new Guid("C39B563E-B5D1-46F3-AD48-C18A51EC2E17"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/750920/header.jpg?t=1729014037", new Guid("C39B563E-B5D1-46F3-AD48-C18A51EC2E17") },
                    { new Guid("F8850B79-F108-45E6-A18C-D908328512A7"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1238820/header.jpg?t=1734373919", new Guid("F8850B79-F108-45E6-A18C-D908328512A7") },
                    { new Guid("53CBC102-242A-4CBC-97A3-1F1400334628"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/489830/header.jpg?t=1749757378", new Guid("53CBC102-242A-4CBC-97A3-1F1400334628") },
                    { new Guid("6214061D-4009-4719-9373-F3F626DCC521"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1238810/header.jpg?t=1747167586", new Guid("6214061D-4009-4719-9373-F3F626DCC521") },
                    { new Guid("FB754D87-9C25-4B15-9AA9-0729A16A1663"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/203160/header.jpg?t=1729010886", new Guid("FB754D87-9C25-4B15-9AA9-0729A16A1663") },
                    { new Guid("A89E8B56-B17C-4F9C-99BF-235D7EBF70B2"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1888930/header.jpg?t=1750959031", new Guid("A89E8B56-B17C-4F9C-99BF-235D7EBF70B2") },
                    { new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2933620/header.jpg?t=1748536585", new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442") },
                    { new Guid("EC0FF6B8-60A0-46F1-817D-A4B0A3B1BA97"), "Cover", "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/391220/header.jpg?t=1729011444", new Guid("EC0FF6B8-60A0-46F1-817D-A4B0A3B1BA97") }
                });

            // Seed GameGenre
            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesGameID", "GenresGenreID" },
                values: new object[,]
                {
                    { new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB"), new Guid("b6e9f67f-ba8d-4191-b778-4d101fc0d164") },
                    { new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB"), new Guid("d558f625-6b6a-4063-bcce-27f9f760c16c") },
                    { new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB"), new Guid("01d9862f-34d3-43bd-9f30-3ab343d3a08e") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), new Guid("31025975-5234-4607-ac0b-befab1ccd715") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), new Guid("8822f6d8-9efd-4c9e-9d74-2e6aad17c9b0") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), new Guid("d558f625-6b6a-4063-bcce-27f9f760c16c") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), new Guid("b6e9f67f-ba8d-4191-b778-4d101fc0d164") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), new Guid("9bba495e-9a51-4ed7-b012-fa14d61db0ea") },
                    { new Guid("80EBADF6-6CD5-4831-BDDA-805C3840EC57"), new Guid("dadd0935-0923-4ddd-abaf-4788ba6f95af") },
                    { new Guid("D28E8B0A-9567-4C68-8F50-0EA9D36C722F"), new Guid("b6e9f67f-ba8d-4191-b778-4d101fc0d164") },
                    { new Guid("D28E8B0A-9567-4C68-8F50-0EA9D36C722F"), new Guid("d558f625-6b6a-4063-bcce-27f9f760c16c") },
                    { new Guid("D28E8B0A-9567-4C68-8F50-0EA9D36C722F"), new Guid("01d9862f-34d3-43bd-9f30-3ab343d3a08e") },
                    { new Guid("D28E8B0A-9567-4C68-8F50-0EA9D36C722F"), new Guid("9bba495e-9a51-4ed7-b012-fa14d61db0ea") },
                    { new Guid("1037AF81-F32A-4252-8322-A7EB04A11EF2"), new Guid("a4969cf3-28c8-4bb2-b9b8-c59f8ffa71f7") },
                    { new Guid("1037AF81-F32A-4252-8322-A7EB04A11EF2"), new Guid("bf204804-43af-47ac-8c9c-27086e28895d") },
                    { new Guid("1037AF81-F32A-4252-8322-A7EB04A11EF2"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("1037AF81-F32A-4252-8322-A7EB04A11EF2"), new Guid("3978bfab-0b37-47fc-935d-7ac3be8d5687") },
                    { new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66"), new Guid("b6e9f67f-ba8d-4191-b778-4d101fc0d164") },
                    { new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66"), new Guid("d558f625-6b6a-4063-bcce-27f9f760c16c") },
                    { new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66"), new Guid("319697b1-3adf-4606-9bf2-d744ee20ba7c") },
                    { new Guid("3EBA9F94-84F1-4330-AB44-764E9F7B3C66"), new Guid("a74257de-4010-4c32-a4f7-1719be29e8f7") },
                    { new Guid("F9A2E6C8-C976-47E1-BBE0-EE9869B22352"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("F9A2E6C8-C976-47E1-BBE0-EE9869B22352"), new Guid("bf204804-43af-47ac-8c9c-27086e28895d") },
                    { new Guid("73EA0BE2-6250-43C0-B766-A19829BEE4AE"), new Guid("c5833d2f-316f-4f92-af39-d20906139226") },
                    { new Guid("73EA0BE2-6250-43C0-B766-A19829BEE4AE"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("73EA0BE2-6250-43C0-B766-A19829BEE4AE"), new Guid("31025975-5234-4607-ac0b-befab1ccd715") },
                    { new Guid("30E3AE70-7DAB-446A-9DE5-9DDC7FE4031B"), new Guid("c5833d2f-316f-4f92-af39-d20906139226") },
                    { new Guid("30E3AE70-7DAB-446A-9DE5-9DDC7FE4031B"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("30E3AE70-7DAB-446A-9DE5-9DDC7FE4031B"), new Guid("31025975-5234-4607-ac0b-befab1ccd715") },
                    { new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445"), new Guid("d558f625-6b6a-4063-bcce-27f9f760c16c") },
                    { new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445"), new Guid("3c9bfc33-af01-494c-954c-af0f98c32172") },
                    { new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445"), new Guid("be7e6fc0-fb79-4fc3-8b86-25d2c89c5529") },
                    { new Guid("3C7865A0-6C6E-4AA0-8266-0A060F0C4445"), new Guid("6318e2e7-999d-4b1c-83ac-b6cc22b99f7b") },
                    { new Guid("C39B563E-B5D1-46F3-AD48-C18A51EC2E17"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("C39B563E-B5D1-46F3-AD48-C18A51EC2E17"), new Guid("bf204804-43af-47ac-8c9c-27086e28895d") },
                    { new Guid("F8850B79-F108-45E6-A18C-D908328512A7"), new Guid("31025975-5234-4607-ac0b-befab1ccd715") },
                    { new Guid("F8850B79-F108-45E6-A18C-D908328512A7"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("F8850B79-F108-45E6-A18C-D908328512A7"), new Guid("8822f6d8-9efd-4c9e-9d74-2e6aad17c9b0") },
                    { new Guid("53CBC102-242A-4CBC-97A3-1F1400334628"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("53CBC102-242A-4CBC-97A3-1F1400334628"), new Guid("bf204804-43af-47ac-8c9c-27086e28895d") },
                    { new Guid("6214061D-4009-4719-9373-F3F626DCC521"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("6214061D-4009-4719-9373-F3F626DCC521"), new Guid("d558f625-6b6a-4063-bcce-27f9f760c16c") },
                    { new Guid("6214061D-4009-4719-9373-F3F626DCC521"), new Guid("9bba495e-9a51-4ed7-b012-fa14d61db0ea") },
                    { new Guid("FB754D87-9C25-4B15-9AA9-0729A16A1663"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("FB754D87-9C25-4B15-9AA9-0729A16A1663"), new Guid("bf204804-43af-47ac-8c9c-27086e28895d") },
                    { new Guid("A89E8B56-B17C-4F9C-99BF-235D7EBF70B2"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("A89E8B56-B17C-4F9C-99BF-235D7EBF70B2"), new Guid("3c9bfc33-af01-494c-954c-af0f98c32172") },
                    { new Guid("A89E8B56-B17C-4F9C-99BF-235D7EBF70B2"), new Guid("c5833d2f-316f-4f92-af39-d20906139226") },
                    { new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442"), new Guid("31025975-5234-4607-ac0b-befab1ccd715") },
                    { new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442"), new Guid("783243fe-8182-4001-9de7-863c2fe5ebe6") },
                    { new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442"), new Guid("8822f6d8-9efd-4c9e-9d74-2e6aad17c9b0") },
                    { new Guid("1ACC7475-1EA4-41A5-B7C4-07502620E442"), new Guid("479d9d71-b91d-4dfc-8d14-5bc6c4d28aad") },
                    { new Guid("EC0FF6B8-60A0-46F1-817D-A4B0A3B1BA97"), new Guid("fea211d1-9dfe-4764-babe-563c8ae8ffc4") },
                    { new Guid("EC0FF6B8-60A0-46F1-817D-A4B0A3B1BA97"), new Guid("bf204804-43af-47ac-8c9c-27086e28895d") }
                });

            // Seed CompanyGames
            migrationBuilder.InsertData(
                table: "CompanyGames",
                columns: new[] { "GameID", "CompanyID", "Role" },
                values: new object[,]
                {
                    { new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB"), new Guid("9F6E1FC8-1BBC-4EBB-BBD7-725E871FBD73"), 0 },
                    { new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB"), new Guid("9F6E1FC8-1BBC-4EBB-BBD7-725E871FBD73"), 1 }
                });

            // Seed GamePlatform
            migrationBuilder.InsertData(
                table: "GamePlatform",
                columns: new[] { "GamesGameID", "PlatformsPlatformID" },
                values: new object[,]
                {
                    { new Guid("052B2A66-A6F6-4865-80BF-7B89175F79DB"), new Guid("AFF935B7-A122-45BF-B343-FB2B84ECFC47") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Delete data in reverse order
            // Note: Removed double quotes from table names for SQLite compatibility
            migrationBuilder.Sql("DELETE FROM GamePlatform");
            migrationBuilder.Sql("DELETE FROM CompanyGames");
            migrationBuilder.Sql("DELETE FROM GameGenre");
            migrationBuilder.Sql("DELETE FROM Medias");
            migrationBuilder.Sql("DELETE FROM Games");
            migrationBuilder.Sql("DELETE FROM Companies");
            migrationBuilder.Sql("DELETE FROM Genres");
        }
    }
}

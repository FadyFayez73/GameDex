using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class GameTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Primary Key
            builder.HasKey(g => g.GameID);


            // Property Setup
            builder.Property(g => g.Name).IsRequired();
            builder.Property(g => g.Patch).IsRequired();
            builder.Property(g => g.GamePath).IsRequired();
            builder.Property(g => g.YearOfRelease).IsRequired(false);
            builder.Property(g => g.PGRating).IsRequired();
            builder.Property(g => g.GameDescription).IsRequired();
            builder.Property(g => g.GameEngine).IsRequired();
            builder.Property(g => g.OrderOfFranchise).IsRequired(false);
            builder.Property(g => g.LinkForCrack).IsRequired(false);
            builder.Property(g => g.CriticsRating).IsRequired().HasColumnType("decimal(3,1)");
            builder.Property(g => g.PlayersRating).IsRequired().HasColumnType("decimal(3,1)");
            builder.Property(g => g.UserRating).IsRequired().HasColumnType("decimal(3,1)");
            builder.Property(g => g.SteamPrices).IsRequired().HasColumnType("Decimal(7,2)");
            builder.Property(g => g.ActualGameSize).IsRequired(false);
            builder.Property(g => g.GameFiles).IsRequired(false);
            builder.Property(g => g.HoursToComplete).IsRequired();
            builder.Property(g => g.PlayerHours).IsRequired();
            builder.Property(g => g.StoryPlace).IsRequired(false);


            // One-to-Many Relationships
            builder
                .HasMany(g => g.Albums)
                .WithOne(a => a.Game)
                .HasForeignKey(a => a.GameID);

            builder
                .HasMany(g => g.Controls)
                .WithOne(c => c.Game)
                .HasForeignKey(c => c.GameID);

            builder
                .HasMany(g => g.Requirements)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameID);

            builder
                .HasMany(g => g.Medias)
                .WithOne(m => m.Game)
                .HasForeignKey(m => m.GameID);

            builder
                .HasMany(g => g.ChapterMissions)
                .WithOne(cm => cm.Game)
                .HasForeignKey(cm => cm.GameID);

            builder
                .HasMany(g => g.Characters)
                .WithOne(ch => ch.Game)
                .HasForeignKey(ch => ch.GameID);

            builder
                .HasMany(g => g.Performances)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameID);

            builder
                .HasMany(g => g.DLCs)
                .WithOne(d => d.Game)
                .HasForeignKey(d => d.GameID);


            // Many-to-Many Relationships
            builder
                .HasMany(g => g.Companies)
                .WithMany(c => c.Games);
            builder
                .HasMany(g => g.ModManagers)
                .WithMany(m => m.Games);
            builder
                .HasMany(g => g.Platforms)
                .WithMany(p => p.Games);
            builder
                .HasMany(g => g.Genres)
                .WithMany(gen => gen.Games);


            // Insert Data
            builder
                .HasData(new Game
                {
                    GameID = 1,
                    Name = "The Witcher 3: Wild Hunt",
                    Patch = "4.04",
                    GamePath = @"D:\SteamLibrary\steamapps\common\The Witcher 3\REDprelauncher.exe",
                    YearOfRelease = "May 2015",
                    PGRating = "18 over",
                    GameDescription = "One of the most acclaimed RPGs of all time. Now ready for a new generation...",
                    GameEngine = "REDengine 3",
                    OrderOfFranchise = "3",
                    LinkForCrack = string.Empty,
                    CriticsRating = 9.6m,
                    PlayersRating = 10,
                    UserRating = 10,
                    SteamPrices = 37.99m,
                    ActualGameSize = "57 GB",
                    GameFiles = string.Empty,
                    HoursToComplete = 174,
                    PlayerHours = 60,
                    StoryPlace = "Temerian (southern) side of the Pontar in Velen"
                });
        }
    }
}
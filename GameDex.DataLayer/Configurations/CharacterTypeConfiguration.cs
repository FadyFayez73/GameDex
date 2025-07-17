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
    public class CharacterTypeConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            // Primary Key
            builder
                .HasKey(cha => cha.CharacterID);


            // Property
            builder
                .Property(cha => cha.Name)
                .IsRequired();

            builder
                .Property(cha => cha.ImagePath)
                .IsRequired();

            builder
                .Property(cha => cha.Description)
                .IsRequired(false);


            // Relations One To Many
            builder
                .HasOne(cha => cha.Game)
                .WithMany(g => g.Characters)
                .HasForeignKey(cha => cha.GameID);


            // Relations Many To Many
            builder
                .HasMany(cha => cha.ChapterMissions)
                .WithMany(cm => cm.Characters);


            builder
                .HasData(new Character
                {
                    CharacterID = 1,
                    Name = "Geralt of Rivia",
                    ImagePath = string.Empty,
                    Description = "A witcher and the main protagonist of The Witcher series."
                },
                new Character
                {
                    CharacterID = 2,
                    Name = "Ciri",
                    ImagePath = string.Empty,
                    Description = "The Child of Prophecy, a powerful source of Elder Blood."
                });

        }
    }
}

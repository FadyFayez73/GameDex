using GameDex.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer.Configurations
{
    public class ChapterMissionTypeConfiguration : IEntityTypeConfiguration<ChapterMission>
    {
        public void Configure(EntityTypeBuilder<ChapterMission> builder)
        {
            // Primary Key
            builder
                .HasKey(cm => cm.ChapterMissionID);


            // Property
            builder
                .Property(cm => cm.Type)
                .IsRequired();

            builder
                .Property(cm => cm.Name)
                .IsRequired();

            builder
                .Property(cm => cm.Description)
                .IsRequired(false);


            // Relations One To Many
            builder
                .HasOne(cm => cm.Game)
                .WithMany(g => g.ChapterMissions)
                .HasForeignKey(cm => cm.GameID);

            // Relations Many To Many
            builder
                .HasMany(cha => cha.Characters)
                .WithMany(cm => cm.ChapterMissions);
        }
    }
}

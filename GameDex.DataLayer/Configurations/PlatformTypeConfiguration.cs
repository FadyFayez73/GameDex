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
    public class PlatformTypeConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            // Primary Key
            builder
                .HasKey(plat => plat.PlatformID);


            // Property
            builder
                .Property(plat => plat.Name)
                .IsRequired();


            // Relations
            builder
                .HasMany(plat => plat.Games)
                .WithMany(g => g.Platforms);

            builder
                .HasData(new Platform
                {
                    PlatformID = 1,
                    Name = "PC",
                },
                new Platform
                {
                    PlatformID = 2,
                    Name = "PlayStation 4",
                });

        }
    }
}

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

            var id1 = Guid.Parse("aff935b7-a122-45bf-b343-fb2b84ecfc47");
            var id2 = Guid.Parse("43b2427b-b32b-4a80-98c2-18b8c6f11934");

            builder
                .HasData(
                new Platform
                {
                    PlatformID = id1,
                    Name = "PC",
                },
                new Platform
                {
                    PlatformID = id2,
                    Name = "PlayStation 4",
                });

        }
    }
}

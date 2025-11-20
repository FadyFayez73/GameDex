using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

            builder
                .Property(plat => plat.Description)
                .IsRequired();


            // Relations
            builder
                .HasMany(plat => plat.Games)
                .WithMany(g => g.Platforms);

            var winId = Guid.Parse("aff935b7-a122-45bf-b343-fb2b84ecfc47");
            var linuxId = Guid.Parse("43b2427b-b32b-4a80-98c2-18b8c6f11934");
            var macId = Guid.Parse("59cfe7d1-6c6e-4d25-95b6-7c9f6b2f9245");
            var psId = Guid.Parse("9af20714-09a5-4c83-9f6f-798dc91b1d02");
            var xboxId = Guid.Parse("4f46a6c9-1f94-4a63-9de8-2f85cbe5f05e");
            var switchId = Guid.Parse("77bba20d-79f2-4a89-9f60-10cc02c0f2cf");
            var androidId = Guid.Parse("e15e8ef7-8f6b-4e71-9f51-f8658d7f84d9");
            var iosId = Guid.Parse("b5b8efb3-7f8d-48a3-88b7-6f1a9d85f5c7");

            builder
                .HasData(
                new Platform { PlatformID = winId, Name = "Windows", Description = "Microsoft Windows operating system" },
                new Platform { PlatformID = linuxId, Name = "Linux", Description = "Open-source operating system based on Unix" },
                new Platform { PlatformID = macId, Name = "macOS", Description = "Apple's operating system for Mac computers" },
                new Platform { PlatformID = psId, Name = "PlayStation", Description = "Sony's gaming console platform" },
                new Platform { PlatformID = xboxId, Name = "Xbox", Description = "Microsoft's gaming console platform" },
                new Platform { PlatformID = switchId, Name = "Nintendo Switch", Description = "Nintendo's hybrid gaming console" },
                new Platform { PlatformID = androidId, Name = "Android", Description = "Google's mobile operating system" },
                new Platform { PlatformID = iosId, Name = "iOS", Description = "Apple's mobile operating system" }
                );



        }
    }
}

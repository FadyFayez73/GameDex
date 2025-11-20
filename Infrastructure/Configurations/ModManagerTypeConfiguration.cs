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
    public class ModManagerTypeConfiguration : IEntityTypeConfiguration<ModManager>
    {
        public void Configure(EntityTypeBuilder<ModManager> builder)
        {
            // Primary Key
            builder
                .HasKey(mod => mod.ModManagerID);


            // Property
            builder
                .Property(mod => mod.Path)
                .IsRequired();

            builder
                .Property(mod => mod.Description)
                .IsRequired(false);


            // Relations
            builder
                .HasMany(mod => mod.Games)
                .WithMany(g => g.ModManagers);
        }
    }
}

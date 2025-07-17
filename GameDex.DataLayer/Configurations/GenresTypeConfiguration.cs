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
    public class GenresTypeConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            // Primary Key
            builder
                .HasKey(gen => gen.GenreID);


            // Property
            builder
                .Property(gen => gen.Name)
                .IsRequired();

            builder
                .Property(gen => gen.Description)
                .IsRequired(false);


            // Relations
            builder
                .HasMany(gen => gen.Games)
                .WithMany(g => g.Genres);
        }
    }
}

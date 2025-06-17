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
    internal class AlbumTypeConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            // Primary Key
            builder
                .HasKey(a => a.AlbumID);

            // Property
            builder
                .Property(a => a.Name)
                .IsRequired();

            builder
                .Property(a => a.Producer)
                .IsRequired();

            builder
                .Property(a => a.Language)
                .IsRequired();

            builder
                .Property(a => a.Length)
                .IsRequired();

            builder
                .Property(a => a.Genre)
                .IsRequired();

            builder
                .Property(a => a.ReleaseDate)
                .IsRequired();

            // Relations
            builder
                .HasOne(a => a.Game)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.GameID);

            builder
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(a => a.AlbumID);

        }
    }
}

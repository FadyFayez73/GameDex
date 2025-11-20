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
    internal class SongTypeConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            // Primary Key
            builder
                .HasKey(s => s.SongID);


            // Property
            builder
                .Property(s => s.Name)
                .IsRequired();

            builder
                .Property(s => s.DiscNumber)
                .IsRequired();

            builder
                .Property(s => s.TrackNumber)
                .IsRequired();

            builder
                .Property(s => s.Detail)
                .IsRequired();


            // Relations
            builder
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumID);
        }
    }
}

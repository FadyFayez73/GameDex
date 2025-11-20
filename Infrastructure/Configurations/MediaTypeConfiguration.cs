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
    public class MediaTypeConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            // Primary Key
            builder
                .HasKey(m => m.MediaID);


            // Property
            builder
                .Property(m => m.MediaType)
                .IsRequired();

            builder
                .Property(m => m.MediaPath)
                .IsRequired();


            // Relations
            builder
                .HasOne(m => m.Game)
                .WithMany(g => g.Medias)
                .HasForeignKey(m => m.GameID);
        }
    }
}

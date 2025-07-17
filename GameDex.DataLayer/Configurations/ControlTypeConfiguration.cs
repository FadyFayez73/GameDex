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
    public class ControlTypeConfiguration : IEntityTypeConfiguration<Control>
    {
        public void Configure(EntityTypeBuilder<Control> builder)
        {
            // Primary Key
            builder
                .HasKey(c => c.ControlID);


            // Property
            builder
                .Property(c => c.ControlType)
                .IsRequired();

            builder
                .Property(c => c.Action)
                .IsRequired();

            builder
                .Property(c => c.Key)
                .IsRequired();


            // Relations
            builder
                .HasOne(c => c.Game)
                .WithMany(g => g.Controls)
                .HasForeignKey(c => c.GameID);
        }
    }
}

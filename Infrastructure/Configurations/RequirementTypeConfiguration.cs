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
    public class RequirementTypeConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            // Primary Key
            builder
                .HasKey(req => req.RequirementID);


            // Property
            builder
                .Property(req => req.RequirementType)
                .IsRequired();

            builder
                .Property(req => req.SystemOS)
                .IsRequired();

            builder
                .Property(req => req.Processor)
                .IsRequired();

            builder
                .Property(req => req.Memory)
                .IsRequired();

            builder
                .Property(req => req.Graphics)
                .IsRequired();

            builder
                .Property(req => req.Network)
                .IsRequired();

            builder
                .Property(req => req.Storage)
                .IsRequired();

            builder
                .Property(req => req.SoundCard)
                
                .IsRequired();

            builder
                .Property(req => req.DirectX)
                .IsRequired();


            // Relations
            builder
                .HasOne(req => req.Game)
                .WithMany(g => g.Requirements)
                .HasForeignKey(req => req.GameID);
        }
    }
}

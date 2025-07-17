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
    public class PerformanceTypeConfiguration : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            // Primary Key
            builder
                .HasKey(perf => perf.PerformanceID);


            // Property
            builder
                .Property(perf => perf.GraphicsQuality)
                .IsRequired();

            builder
                .Property(perf => perf.Low1PercentFPS)
                .IsRequired();

            builder
                .Property(perf => perf.AverageFPS)
                .IsRequired();

            builder
                .Property(perf => perf.MaxFPS)
                .IsRequired();

            builder
                .Property(perf => perf.TestDate)
                .IsRequired();


            // Relations
            builder
                .HasOne(perf => perf.Game)
                .WithMany(g => g.Performances)
                .HasForeignKey(perf => perf.GameID);
        }
    }
}

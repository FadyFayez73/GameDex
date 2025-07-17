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
    public class DLCTypeConfiguration : IEntityTypeConfiguration<DLC>
    {
        public void Configure(EntityTypeBuilder<DLC> builder)
        {
            // Primary Key
            builder
                .HasKey(dlc => dlc.DLCID);


            // Property
            builder
                .Property(dlc => dlc.Name)
                .IsRequired();

            builder
                .Property(dlc => dlc.Description)
                .IsRequired(false);


            // Relations
            builder
                .HasOne(dlc => dlc.Game)
                .WithMany(g => g.DLCs)
                .HasForeignKey(dlc => dlc.GameID);
        }
    }
}

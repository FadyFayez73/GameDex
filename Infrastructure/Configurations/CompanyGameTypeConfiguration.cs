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
    public class CompanyGameTypeConfiguration : IEntityTypeConfiguration<CompanyGame>
    {
        public void Configure(EntityTypeBuilder<CompanyGame> builder)
        {
            builder
                .HasKey(cg => new { cg.GameID, cg.CompanyID, cg.Role });

            builder
                .Property(cg => cg.Role)
                .IsRequired();

            builder
                .HasOne(cg => cg.Game)
                .WithMany(cg => cg.CompanyGames)
                .HasForeignKey(cg => cg.GameID);
            
            builder
                .HasOne(cg => cg.Company)
                .WithMany(cg => cg.CompanyGames)
                .HasForeignKey(cg => cg.CompanyID);
        }
    }
}
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
    public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Primary Key
            builder
                .HasKey(c => c.CompanyID);


            // Property
            builder
                .Property(c => c.Name)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .IsRequired(false);


            // Relations
            builder
                .HasMany(c => c.CompanyGames)
                .WithOne(g => g.Company)
                .HasForeignKey(c => c.CompanyID);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Database.Configurations
{
    public class CompaniesConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Employees)
                .WithOne()
                .HasForeignKey(x => x.CompanyId);
        }
    }
}

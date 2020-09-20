using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Database.Configurations
{
    class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

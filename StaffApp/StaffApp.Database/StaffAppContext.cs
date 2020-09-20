using Microsoft.EntityFrameworkCore;
using StaffApp.Database.Configurations;
using StaffApp.Database.Models;

namespace StaffApp.Database
{
    public partial class StaffAppContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public StaffAppContext()
        {

        }

        public StaffAppContext(DbContextOptions<StaffAppContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-I6AM0F1\SQLEXPRESS;Database=StaffApp;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompaniesConfiguration());
            builder.ApplyConfiguration(new EmployeesConfiguration());
        }
    }
}

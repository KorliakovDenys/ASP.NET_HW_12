using ASP_NET_HW_12.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_HW_12.Data {
    public class DataContext : DbContext {
        public DbSet<Corporation>? Corporations { get; set; }

        public DbSet<Company>? Companies { get; set; }

        public DbSet<Country>? Countries { get; set; }

        public DbSet<City>? Cities { get; set; }

        public DbSet<Address>? Addresses { get; set; }

        public DbSet<Employee>? Employees { get; set; }

        public DbSet<Insurance>? Insurances { get; set; }

        public DbSet<EmployeeInsurance>? EmployeeInsurances { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Corporation>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Address>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Insurance>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<EmployeeInsurance>()
                .HasKey(ei => ei.Id);

            base.OnModelCreating(modelBuilder);
        }
    }

}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models;
using UniversityTransportation.Data.Models.Accounts;
using UniversityTransportation.Data.Models.Journey;

namespace UniversityTransportation.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.ConfigurationConstants.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Passenger>()
                .HasOne(b => b.ApplicationUser)
                .WithOne(i => i.Passenger)
                .HasForeignKey<ApplicationUser>(b => b.PassengerId);

            modelBuilder.Entity<Driver>()
                .HasOne(b => b.ApplicationUser)
                .WithOne(i => i.Driver)
                .HasForeignKey<ApplicationUser>(b => b.DriverId);
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
    }
}

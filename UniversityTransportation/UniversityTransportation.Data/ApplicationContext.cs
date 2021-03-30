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
                .HasOne(a => a.ApplicationUser)
                .WithOne(b => b.Passenger)
                .HasForeignKey<ApplicationUser>(a => a.PassengerId);

            modelBuilder.Entity<Driver>()
                .HasOne(a => a.ApplicationUser)
                .WithOne(b => b.Driver)
                .HasForeignKey<ApplicationUser>(a => a.DriverId);

            modelBuilder.Entity<Journey>()
                .HasOne(a => a.Driver)
                .WithMany(b => b.Journeys)
                .HasForeignKey(a => a.DriverId);

            modelBuilder.Entity<JourneyStation>()
                .HasKey(a => new { a.JourneyId, a.StationId });

            modelBuilder.Entity<PassengerJourneyStation>()
               .HasKey(a => new { a.PassengerId, a.JourneyId, a.StationId });
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<JourneyStation> JourneyStations { get; set; }
        public DbSet<PassengerJourneyStation> PassengerJourneyStations { get; set; }

    }
}

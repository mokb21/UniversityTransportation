using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models;
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

        public DbSet<Station> Stations { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
    }
}

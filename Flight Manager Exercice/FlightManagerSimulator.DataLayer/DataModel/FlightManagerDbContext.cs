using FlightManagerSimulator.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagerSimulator.DataLayer
{
    public class FlightManagerDbContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FlightManagerSimilator.db");
        }
    }
}
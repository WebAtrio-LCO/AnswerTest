using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using FlightManagerSimulator.DataLayer.Models;

namespace FlightManagerSimulator.DataLayer.DatabaseGenerator
{
    public static class Program
    {
        private const string DestinationFolder = "Data";
        private const string DbInfoFileName = "DBFileInfo.cs";
        private const string TargetNamespace = "FlightManagerSimulator.DataLayer.Data";

        private static readonly DBFileInfo DbFileInfo = new DBFileInfo();
        private static readonly string DbFilePath = Path.Combine(DestinationFolder, DbFileInfo.FileName);
        private static readonly string DbInfoFilePath = Path.Combine(DestinationFolder, DbInfoFileName);

        private static void Main()
        {
            using (var flightManagerDbContext = new FlightManagerDbContext())
            {
                flightManagerDbContext.Database.Migrate();
                for (int i = 0; i < 10; ++i)
                {
                    flightManagerDbContext.Set<Aircraft>().Add(
                        new Aircraft() { Name = string.Concat("Aircraft ", i), Count = 5, InFlyFuelConsumption = (i * 158.99), InTakeOffFuelConsumption = (58.45 + i), PassengerCapacity = 200, MaxSpeed = "Not Defined" }
                        );
                }

                Random random = new Random();
                for (int i = 0; i < 100; ++i)
                {
                    flightManagerDbContext.Set<Airport>().Add(
                        new Airport() { Name = string.Concat("Airport", i), Latitude = random.NextDouble(), Longitude = random.NextDouble() }
                        );
                }

                flightManagerDbContext.SaveChanges();
            }
        }
    }
}

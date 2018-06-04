using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManagerSimulator.DataLayer.Models
{
    [NotMapped]
    /// <see cref="IGeneratedReport"/>
    public class GeneratedReport : IGeneratedReport
    {
        /// <see cref="IGeneratedReport.FlightCount"/>
        public int FlightCount { get; set; }

        /// <see cref="IGeneratedReport.TotalFuelNeeded"/>
        public double TotalFuelNeeded { get; set; }

        /// <see cref="IGeneratedReport.TotalPlannedDistance"/>
        public double TotalTraveledDistance { get; set; }

        /// <see cref="IGeneratedReport.AverageDistance"/>
        public double AverageDistance { get; set; }

        /// <see cref="IGeneratedReport.MinimalDistance"/>
        public double MinimalDistance { get; set; }

        /// <see cref="IGeneratedReport.MaximalDistance"/>
        public double MaximalDistance { get; set; }

        /// <see cref="IGeneratedReport.AircraftTraffic"/>
        public Dictionary<string, int> AircraftTraffic { get; set; }

        /// <see cref="IGeneratedReport.AircraftTaveledDistance"/>
        public Dictionary<string, double> AircraftTaveledDistance { get; set; }
    }
}

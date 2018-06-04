using System.Collections.Generic;

namespace FlightManagerSimulator.DataLayer.Models
{
    /// <summary>
    /// Represents Data which are calculated for report
    /// </summary>
    public interface IGeneratedReport
    {
        /// <summary>
        /// Number of Flights in the database
        /// </summary>
        int FlightCount { get; set; }

        /// <summary>
        /// Total fuel needed for the all flights
        /// </summary>
        double TotalFuelNeeded { get; set; }

        /// <summary>
        /// Total distance for the all flights
        /// </summary>
        double TotalTraveledDistance { get; set; }

        /// <summary>
        /// average disance
        /// </summary>
        double AverageDistance { get; set; }

        /// <summary>
        /// Distance of the shortest flight
        /// </summary>
        double MinimalDistance { get; set; }

        /// <summary>
        /// Distance of the longest flight
        /// </summary>
        double MaximalDistance { get; set; }

        /// <summary>
        /// Count of flight by airport (includin arrival and departure)
        /// </summary>
        Dictionary<string, int> AircraftTraffic { get; set; }

        /// <summary>
        /// Traveled distance for an aircraft
        /// </summary>
        Dictionary<string, double> AircraftTaveledDistance { get; set; }
    }
}

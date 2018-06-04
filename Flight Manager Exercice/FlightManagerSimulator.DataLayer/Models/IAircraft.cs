namespace FlightManagerSimulator.DataLayer.Models
{
    /// <summary>
    /// Represents a company's aircraft 
    /// </summary>
    public interface IAircraft : IBaseEntity
    {
        /// <summary>
        /// Name of the aircraft
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Aircraft's speed during fly phase
        /// </summary>
        string MaxSpeed { get; set; }

        /// <summary>
        /// Aircraft's fuel consumption during the fly phase
        /// </summary>
        double InFlyFuelConsumption { get; set; }

        /// <summary>
        /// Aircraft's fuel consumption during the fly phase
        /// </summary>
        double InTakeOffFuelConsumption { get; set; }

        /// <summary>
        /// Number of passenger that can be carry on
        /// </summary>
        int PassengerCapacity { get; set; }

        /// <summary>
        /// Count of the aircraft possessed by the company
        /// </summary>
        int Count { get; set; }
    }
}

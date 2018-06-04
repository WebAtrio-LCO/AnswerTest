namespace FlightManagerSimulator.DataLayer.Models
{
    /// <summary>
    /// Represent an airport
    /// </summary>
    public interface IAirport : IBaseEntity
    {
        /// <summary>
        /// name of the airport
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// latitude
        /// </summary>
        double Latitude { get; set; }

        /// <summary>
        /// longitude
        /// </summary>
        double Longitude { get; set; }
    }
}

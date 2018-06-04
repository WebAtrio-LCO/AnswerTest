namespace FlightManagerSimulator.DataLayer.Models
{
    /// <summary>
    /// Represents a flight
    /// </summary>
    public interface IFlight : IBaseEntity
    {
        /// <summary>
        /// Functionnal identifier used to find the fly
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        /// Airport from which the fly start
        /// </summary>
        IAirport DepartureAirport { get;}

        /// <summary>
        /// Airport to which the fly start
        /// </summary>
        IAirport DestinationAirport { get;}

        /// <summary>
        /// Aircraft used for the flight
        /// </summary>
        IAircraft Aircraft { get;}

        /// <summary>
        /// Days when flight is planned
        /// </summary>
        int Days { get; set; }

        #region calculated properties
        double Distance { get; set; }

        double FuelNeeded { get; set; }

        #endregion
    }
}

namespace FlightManagerSimulator.DataLayer.Models
{
    /// <see cref="IFlight"/>
    public class Flight : IFlight
    {
        /// <summary>
        /// Identifier of the flight iin the database
        /// </summary>
        public int Id { get; set; }

        /// <see cref="IFlight.Identifier"/>
        public string Identifier { get; set; }

        /// <summary>
        /// Departur airport
        /// </summary>
        public Airport DepartureAirport { get; set; }

        /// <summary>
        /// <see cref="IFlight"/>
        /// To generate table through code first, EF Core must know how to implement interface
        /// </summary>
        IAirport IFlight.DepartureAirport
        {
            get { return DepartureAirport; }
        }

        /// <summary>
        /// Destination Airport
        /// Note : With Independant DomainModel => protected internal set
        /// </summary>
        public Airport DestinationAirport { get; set; }

        /// <summary>
        /// <see cref="IFlight.DestinationAirport"/>
        /// To generate table through code first, EF Core must know how to implement interface
        /// </summary>
        IAirport IFlight.DestinationAirport
        {
            get { return DestinationAirport; }
        }

        /// <summary>
        /// Aircraft used for the flight
        /// </summary>
        public Aircraft Aircraft { get; set; }

        /// <summary>
        /// <see cref="IFlight.Aircraft."/>
        /// To generate table through code first, EF Core must know how to implement interface
        /// </summary>
        IAircraft IFlight.Aircraft
        {
            ///Define 
            get { return Aircraft; }
        }

        /// <see cref="IFlight.Days"/>
        public int Days { get; set; }

        /// <see cref="IFlight.Distance"/>
        public double Distance { get; set; }

        /// <see cref="IFlight.FuelNeeded"/>
        public double FuelNeeded { get; set; }
    }
}

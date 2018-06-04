using System.Runtime.Serialization;

namespace FlightManagerSimulator.Angular.API.Models
{
    /// <summary>
    /// Model representing the serahc criteria for Flight
    /// </summary>
    [DataContract]
    public class FlightModel
    {
        /// <summary>
        /// id of the Flight
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Functionnal identifier used to find the fly
        /// </summary>
        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Airport from which the fly start
        /// </summary>
        [DataMember(Name = "departureairport")]
        public int DepartureAirportId { get; set; }

        /// <summary>
        /// Airport to which the fly start
        /// </summary>
        [DataMember(Name = "destinationairport")]
        public int DestinationAirportId { get; set; }

        /// <summary>
        /// Aircraft used for the flight
        /// </summary>
        [DataMember(Name = "aircraft")]
        public int AircraftId { get; set; }

        /// <summary>
        /// Days when flight is planned
        /// </summary>
        [DataMember(Name = "day")]
        public int Days { get; set; }

    }
}

namespace FlightManagerSimulator.DataLayer.Models
{
    /// <see cref="IAirport"/>
    public class Airport : IAirport
    {
        /// <see cref="IBaseEntity"/>
        public int Id { get; set; }

        /// <see cref="IAirport"/>
        public string Name { get; set; }

        /// <see cref="IAirport"/>
        public double Latitude { get; set; }

        /// <see cref="IAirport"/>
        public double Longitude { get; set; }
    }
}

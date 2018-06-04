namespace FlightManagerSimulator.DataLayer.Models
{
    /// <see cref="IAircraft"/>
    public class Aircraft : IAircraft
    {
        /// <summary>
        /// Identifier of the aircraft in the database
        /// </summary>
        public int Id { get; set; }

        /// <see cref="IAircraft.Name"/>
        public string Name { get; set; }

        /// <see cref="IAircraft.MaxSpeed"/>
        public string MaxSpeed { get; set; }

        /// <see cref="IAircraft.InFlyFuelConsumption"/>
        public double InFlyFuelConsumption { get; set; }

        /// <see cref="IAircraft.InTakeOffFuelConsumption"/>
        public double InTakeOffFuelConsumption { get; set; }

        /// <see cref="IAircraft.PassengerCapacity"/>
        public int PassengerCapacity { get; set; }

        /// <see cref="IAircraft.Count."/>
        public int Count { get; set; }
    }
}

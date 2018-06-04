using FlightManagerSimulator.DataLayer.Models;

namespace FlightManagerSimulator.Angular.API.Models.Extensions
{
    public static class IFlightExtension
    {
        /// <summary>
        /// Converts IFlight entity to FlightModel
        /// </summary>
        public static FlightModel ToModel(this IFlight flight)
        {
            FlightModel flightModel = new FlightModel();

            flightModel.Id = flight.Id;
            flightModel.Identifier = flight.Identifier;
            flightModel.DepartureAirportId = flight.DepartureAirport.Id;
            flightModel.DestinationAirportId = flight.DestinationAirport.Id;
            flightModel.AircraftId = flight.Aircraft.Id;
            flightModel.Days = flight.Days;

            return flightModel;
        }

        /// <summary>
        /// Converts Flight entity to FlightModel
        /// </summary>
        public static Flight ToEntity(this FlightModel flightModel)
        {
            Flight flight = new Flight();
            if (flightModel == null)
                return flight;

            flight.Id = flightModel.Id;
            flight.Identifier = flightModel.Identifier;

            if (flightModel.DepartureAirportId > 0)
            {
                flight.DepartureAirport = new Airport();
                flight.DestinationAirport.Id = flightModel.DepartureAirportId;
            }
            if (flightModel.DestinationAirportId > 0)
            {
                flight.DestinationAirport = new Airport();
                flight.DestinationAirport.Id = flightModel.DestinationAirportId;
            }
            if (flightModel.AircraftId > 0)
            {
                flight.Aircraft = new Aircraft();
                flight.Aircraft.Id = flightModel.AircraftId;
            }
            flight.Days = flightModel.Days;

            return flight;
        }

    }
}

using FlightManagerSimulator.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FlightManagerSimulator.Angular.API.Controllers
{
    /// <summary>
    /// Controller managing all request concerning 
    /// </summary>
    [Route("api/[controller]")]
    public class AirportsController : BaseController
    {
        /// <summary>
        /// Get all airport from database
        /// </summary>
        [HttpGet("all")]
        public ActionResult GetAllAirportsAsync()
        {
            //Make sur to dispose all ressources event if 
            using (AirportService airportService = new AirportService(_flightManagerDbContext))
            {
                //Call to the database
                var airports = airportService.GetAllAirports();
                
                //Configure the serialization to send the json in CamelCase
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                //Json serialization
                string json = JsonConvert.SerializeObject(airports, settings);

                //Return http request as OK with serialized aiport list
                return Ok(json);
            }
        }
    }
}

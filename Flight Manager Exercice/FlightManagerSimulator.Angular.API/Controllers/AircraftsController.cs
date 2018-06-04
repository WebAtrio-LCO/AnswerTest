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
    public class AircraftsController : BaseController
    {
        /// <summary>
        /// Get all airport from database
        /// </summary>
        [HttpGet("all")]
        public ActionResult GetAllAircraftsAsync(int day)
        {
            //Make sur to dispose all ressources event if 
            using (AircraftService aircraftService = new AircraftService(_flightManagerDbContext))
            {
                //Call to the database
                var aircrafts = aircraftService.GetAllAvailableAircrafts(day);

                //Configure the serialization to send the json in CamelCase
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                //Json serialization
                string json = JsonConvert.SerializeObject(aircrafts, settings);

                //Return http request as OK with serialized aiport list
                return Ok(json);
            }
        }
    }
}

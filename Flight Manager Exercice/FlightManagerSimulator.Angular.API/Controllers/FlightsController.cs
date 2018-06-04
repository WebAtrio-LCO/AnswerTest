using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FlightManagerSimulator.Angular.API.Models;
using FlightManagerSimulator.DataLayer.Models;
using FlightManagerSimulator.Angular.API.Models.Extensions;
using FlightManagerSimulator.BusinessLayer;

namespace FlightManagerSimulator.Angular.API.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : BaseController
    {
        [HttpGet("{skip}/{take}")]
        /// <summary>
        /// Get all operators
        /// </summary>
        public ActionResult GetFlights(int skip, int take)
        {
            using (FlightService flightService = new FlightService(_flightManagerDbContext))
            {
                var result = flightService.GetFlights(null, skip, take);
                var model = result.Select(f => f.ToModel());
                return new OkObjectResult(model);
            }
        }

        /// <summary>
        /// Get all operators
        /// </summary>
        [HttpPost("{skip}/{take}")]
        public ActionResult SearchFlights(int skip, int take, [FromBody]FlightModel flightModel)
        {
            Flight flight = flightModel.ToEntity();
            using (FlightService flightService = new FlightService(_flightManagerDbContext))
            {
                var result = flightService.GetFlights(flight, skip, take);
                var model = result.Select(f => f.ToModel());
                return new OkObjectResult(model);
            }
        }

        [HttpPost]
        public ActionResult InsertFlight([FromBody]FlightModel flightModel)
        {
            Flight flight = flightModel.ToEntity();
            using (FlightService flightService = new FlightService(_flightManagerDbContext))
            {
                var result = flightService.InsertFlight(flight);

                return new OkObjectResult(result ? ResultStatus.Success : ResultStatus.Failure);
            }
        }

        [HttpPut]
        public ActionResult UpdateFlight([FromBody]FlightModel flightModel)
        {
            Flight flight = flightModel.ToEntity();
            using (FlightService flightService = new FlightService(_flightManagerDbContext))
            {
                var result = flightService.UpdateFlight(flight);

                return new OkObjectResult(result ? ResultStatus.Success : ResultStatus.Failure);
            }
        }


        [HttpDelete]
        public ResultStatus DeleteFligt(int flightId)
        {
            return ResultStatus.NotExecuted;
        }
    }
}

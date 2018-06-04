using FlightManagerSimulator.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace FlightManagerSimulator.Angular.API.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : BaseController
    {
        /// <summary>
        /// Async Action : Generate report for all flight Data
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetGeneratedReportAsync()
        {
            using (var reportService = new ReportService(_flightManagerDbContext))
            {
                //Call Report Generation and wait until it's finished
                var report = await reportService.GenerateReport();

                //Configure the serialization to send the json in CamelCase
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                //Json serialization
                string json = JsonConvert.SerializeObject(report, settings);

                //Return http request as OK with serialized aiport list
                return Ok(json);
            }
        }
    }
}

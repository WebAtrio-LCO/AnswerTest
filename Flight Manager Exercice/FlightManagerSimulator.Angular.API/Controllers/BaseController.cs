using FlightManagerSimulator.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagerSimulator.Angular.API.Controllers
{
    /// <summary>
    /// The <see cref="BaseController"/> is the base class of the all WebAPI controllers.
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Database context
        /// Note : The DbContext won't be dispose until all UnitOfWork defined in services will be disposed 
        /// </summary>
        protected readonly FlightManagerDbContext _flightManagerDbContext;

        public BaseController()
        {
            //Initialize the DbContext for one HTTP Request. It will be dispose ate the end of the request when UnitOfWork will be disposed
            _flightManagerDbContext = new FlightManagerDbContext();

        }
    }
}

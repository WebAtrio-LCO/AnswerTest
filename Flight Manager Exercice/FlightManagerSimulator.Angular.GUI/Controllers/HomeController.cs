using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagerSimulator.Controllers
{
    /// <summary>
    /// Home controller
    /// Only use to initiate the home page before Angular manage the application routing
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Error
        /// </summary>
        public IActionResult Error()
        {
            return View();
        }
    }
}

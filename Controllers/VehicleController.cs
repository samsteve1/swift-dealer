using Microsoft.AspNetCore.Mvc;
using vega.Models;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        [HttpPost]
        public IActionResult CreateVehicle([FromBody]Vehicle vehicle)
        {
            return Ok(vehicle);
        }
    }
}
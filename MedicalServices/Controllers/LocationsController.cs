using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpPost(Router.LocationRouting.AddOrUpdateLocation)]
        public async Task<IActionResult> AddOrUpdateLocation([FromBody] LocationDTO request)
        {
            var location = await _locationService.AddOrUpdateLocation(request);
            if (location == "Location updated successfully")
                return Ok($"Location updated successfully\n{request}");
            return BadRequest("error when add or update location");
        }

        [HttpGet(Router.LocationRouting.NearbyDoctors)]
        public IActionResult GetNearbyDoctors(double lat, double lng, double distanceInKm = 5)
        {
            var nearbyDoctors = _locationService.GetNearbyDoctors(lat, lng, distanceInKm);
            if (nearbyDoctors == null)
                return BadRequest("not found doctor in this area");
            return Ok(nearbyDoctors);
        }

    }

}
using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorServices _drServices;
        #region Constructor
        public DoctorsController(IDoctorServices drServices)
        {
            _drServices = drServices;
        }
        #endregion
        #region End point
        [SwaggerOperation(Description = "If no rating available rating return 0 !!")]
        [HttpGet(Router.DoctorsRouting.GetList)]
        public async Task<IActionResult> GetAllDoctors([FromQuery] Filter filter)
        {
            try
            {
                var doctors = await _drServices.GetAllDoctorsAsync(filter);
                if (doctors == null || !doctors.Any())
                    return NotFound("No doctors found in the database");
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed: " + ex.Message);
            }

        }
        [HttpGet("GetDoctorDetails/{doctorId}")]
        public async Task<IActionResult> GetDoctorDetails(int doctorId)
        {
            var doctor = await _drServices.GetDoctorDetailsAsync(doctorId);
            if (doctor == null)
                return NotFound("Doctor not found.");

            return Ok(doctor);
        }
        [HttpPost(Router.DoctorsRouting.AddFavoriteDR)]
        public async Task<IActionResult> AddFavoriteDR([FromBody] FavoriteDrDTO dto)
        {
            var success = await _drServices.AddToFavoriteAsync(dto);
            if (!success)
                return BadRequest("Doctor is already in favorites.");

            return Ok("Doctor added to favorites.");
        }
        [HttpDelete(Router.DoctorsRouting.RemoveFavoriteDR)]
        public async Task<IActionResult> RemoveFavoriteDR([FromBody] FavoriteDrDTO dto)
        {
            var success = await _drServices.RemoveFromFavoriteAsync(dto);
            return Ok(success);
        }
        [HttpPost(Router.DoctorsRouting.AddDoctor)]
        public async Task<IActionResult> AddDoctor([FromForm] CreateDoctoDTO dto)
        {
            {
                try
                {
                    var doctors = await _drServices.CreateDoctorAsync(dto);
                    if (doctors == null || !doctors.Any())
                        return NotFound("Failed to create doctor");
                    return Ok(doctors);
                }
                catch (Exception ex)
                {
                    return BadRequest("Failed: " + ex.Message);
                }

            }
        }
        [HttpDelete("RemoveDoctor/{doctorId}")]
        public async Task<IActionResult> RemoveDoctor(int doctorId)
        {
            var success = await _drServices.RemoveDoctorAsync(doctorId);
            if (success)
            {
                return Ok("Doctor removed successfully");
            }
            else
            {
                return NotFound("Doctor not found");
            }
        }
        #endregion
    }
}

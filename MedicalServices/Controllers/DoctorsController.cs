using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
       
        #endregion
    }
}

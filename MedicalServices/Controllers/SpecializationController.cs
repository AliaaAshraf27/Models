using MedicalServices.AppMetaData;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _service;
        #region Constructor
        public SpecializationController(ISpecializationService service)
        {
            _service = service;
        }
        #endregion
        #region End point
        [HttpGet(Router.SpecializationRouting.GetSpecializations)]
        public async Task<IActionResult> GetAllSpecializations ()
        {
            try
            {
                var specializations = await _service.GetAllSpecializationsAsync();
                if (specializations == null || !specializations.Any())
                    return NotFound("Not found any Specialization");
                return Ok(specializations);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed: " + ex.Message);
            }
        }

        [HttpGet(Router.SpecializationRouting.GetDoctorsBySpecializationID)]
        public async Task<IActionResult> GetAllDoctors(int specializationId)
        {
            try
            {
                var doctors = await _service.GetDoctorsBySpecializationIDAsync(specializationId);
                if (doctors == null || !doctors.Any())
                    return NotFound("Not found any doctor");
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

using MedicalServices.DTO;
using Microsoft.AspNetCore.Mvc;
using MedicalServices.Services;
using MedicalServices.AppMetaData;

namespace MedicalServices.Controllers
{
    public class AppointmentController : ControllerBase // Inherit from ControllerBase for API controllers  
    {
        private readonly IAppointmentService _appointmentService; // Declare the dependency  

        public AppointmentController(IAppointmentService appointmentService) // Inject the dependency via constructor  
        {
            _appointmentService = appointmentService;
        }

        [HttpPost(Router.AppointmentRouting.AddAppointment)]
        public async Task<IActionResult> AddAppointment([FromBody] AddAppointmentDTO dto)
        {
            var result = await _appointmentService.AddAppointmentAsync(dto);

            if (result == "Doctor not found." || result == "This appointment already exists.")
                return BadRequest(result);

            return Ok(result);
        }
    }
}

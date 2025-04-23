using MedicalServices.DTO;
using Microsoft.AspNetCore.Mvc;
using MedicalServices.Services;
using MedicalServices.AppMetaData;

namespace MedicalServices.Controllers
{
    public class AppointmentController : ControllerBase   
    {
        private readonly IAppointmentService _appointmentService;  

        public AppointmentController(IAppointmentService appointmentService) 
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
        [HttpDelete(Router.AppointmentRouting.RemoveAppointment)]
        public async Task<IActionResult> RemoveAppointment(int appointmentId)
        {
            var result = await _appointmentService.RemoveAppointmentAsync(appointmentId);
            if (result == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

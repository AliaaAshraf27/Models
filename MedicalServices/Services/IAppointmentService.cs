using MedicalServices.DTO;

namespace MedicalServices.Services
{
    public interface IAppointmentService
    {
        Task<string> AddAppointmentAsync(AddAppointmentDTO dto);
        Task<bool> RemoveAppointmentAsync(int appointmentId);
    }
}

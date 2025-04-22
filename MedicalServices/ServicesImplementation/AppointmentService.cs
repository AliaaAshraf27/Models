using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.ServicesImplementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _dbContext;

        public AppointmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddAppointmentAsync(AddAppointmentDTO dto)
        {
            // Check if the doctor exists  
            var doctorExists = await _dbContext.Doctors.AnyAsync(d => d.Id == dto.DoctorId);
            if (!doctorExists)
                return "Doctor not found.";

            // Check if the same appointment already exists  
            var exists = await _dbContext.AvailableAppointments
                .AnyAsync(a => a.DoctorId == dto.DoctorId && a.Day == dto.Day && a.TimeStart == dto.TimeStart && a.TimeEnd == dto.TimeEnd);

            if (exists)
                return "This appointment already exists.";

            // Add new appointment  
            var appointment = new AvailableAppointments
            {
                DoctorId = dto.DoctorId,
                Day = dto.Day,
                TimeStart = dto.TimeStart,
                TimeEnd = dto.TimeEnd,
                Name = dto.Name,
                IsAvailable = true
            };

            _dbContext.AvailableAppointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            return "Appointment added successfully.";
        }
        public async Task<bool> RemoveAppointmentAsync(int appointmentId)
        {
            var appointment = await _dbContext.AvailableAppointments
                    .FirstOrDefaultAsync(a => a.Id == appointmentId);

            if (appointment == null)
                return false;
            _dbContext.AvailableAppointments.Remove(appointment);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}


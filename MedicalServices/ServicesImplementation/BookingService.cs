using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Enums;
using MedicalServices.Hubs;
using MedicalServices.Models;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace MedicalServices.ServicesImplementation
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<NotificationHub> _hubContext;
        public BookingService(ApplicationDbContext dbContext , IHubContext<NotificationHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
        }
        public async Task<List<AvailableSlotDTO>> GetAvailableSlotsAsync(int doctorId)
        {
            var availableSlots = await _dbContext.AvailableAppointments
                .Where(a => a.DoctorId == doctorId && a.IsAvailable)
                .Select(a => new AvailableSlotDTO
                {
                    Time = a.Time,
                    AppointmentId = a.Id
                })
                .ToListAsync();

            return availableSlots;
        }
        public async Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto)
        {
            var appointment = await _dbContext.AvailableAppointments
                .FirstOrDefaultAsync(a => a.Id == bookingDto.AppointmentId && a.IsAvailable);

            if (appointment == null)
            {
                return null;
            }

            var booking = new Booking
            {
                AppointmentId = appointment.Id,
                Status = BookingStatus.New,
                Date = appointment.Time,
                PatientId = bookingDto.PatientId,
                DoctorId = appointment.DoctorId,
                ProblemDescription = bookingDto.ProblemDescription
            };
            appointment.IsAvailable = false;
            await _dbContext.Bookings.AddAsync(booking);

            // send notification to the doctor about the booking 
            var patient = await _dbContext.Patients.Where(x=>x.Id == booking.PatientId).FirstOrDefaultAsync();
            Notification notification = new()
            {
                Date = DateTime.Now,
                Message = $"{patient.User.Name} has made an appointment for {booking.Date}",
                ReceiverId = appointment.DoctorId,
                SenderId = bookingDto.PatientId,
                ReceiverType = "Doctor",
                SenderType = "Patient"
            };
            await _dbContext.Notifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.Users(notification.ReceiverId.ToString()).SendAsync("ReceiveNotification", notification.Message);

            return booking;
        }
        public async Task<bool> CancelBookingAsync(int id)
        {
            //cansel booking
            var booking = await _dbContext.Bookings.FindAsync(id);
            if (booking == null) return false;
            var patient = await _dbContext.Patients.Where(x => x.Id == booking.PatientId).FirstOrDefaultAsync();
            _dbContext.Bookings.Remove(booking);
           await _dbContext.SaveChangesAsync();
            // send notification to the doctor about cancellation of booking 
            if (patient != null)
            {
                Notification notification = new()
                {
                    Date = DateTime.Now,
                    Message = $"{patient.User.Name} has canceled the appointment scheduled for {booking.Date}",
                    ReceiverId = booking.DoctorId,
                    SenderId = booking.PatientId,
                    ReceiverType = "Doctor",
                    SenderType = "Patient"
                };
                await _dbContext.Notifications.AddAsync(notification);
                await _dbContext.SaveChangesAsync();
                await _hubContext.Clients.Users(notification.ReceiverId.ToString()).SendAsync("ReceiveNotification", notification.Message);
            }

            return true;
        }
        public async Task<List<GetBookingDTO>> GetBookingAsync(FilterBookingDTO dto)
        {
            var bookings = await _dbContext.Bookings.Where(b => b.PatientId == dto.PatientId && b.Status == dto.Status).ToListAsync();
           
            if (bookings == null) return [];
            return bookings.Select(b => new GetBookingDTO()
            {
                DoctorName = b.Doctor.User.Name,
                SpecializationName = b.Doctor.Specialization.Name,
                Photo = b.Doctor.User.Photo != null ? $"data:image/png;base64,{Convert.ToBase64String(b.Doctor.User.Photo)}" : null
            }).ToList();

          
        }
       
    }
}


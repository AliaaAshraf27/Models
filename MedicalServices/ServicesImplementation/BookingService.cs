﻿using Antlr.Runtime.Tree;
using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Enums;
using MedicalServices.Hubs;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NHibernate.Engine;
using Stripe;

namespace MedicalServices.ServicesImplementation
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<NotificationHub> _hubContext;
        public BookingService(ApplicationDbContext dbContext, IHubContext<NotificationHub> hubContext)
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
                    Day = a.Day,
                    TimeStart = a.TimeStart,
                    Name = a.Name,
                    TimeEnd = a.TimeEnd,
                    AppointmentId = a.Id,
                    Price = a.Price
                })
                .ToListAsync();

            return availableSlots;
        }
        public async Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto)
        {
            var appointment = await _dbContext.AvailableAppointments
                 .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Day == bookingDto.day && a.TimeStart == bookingDto.time && a.IsAvailable);

            if (appointment == null)
                return null;

            var doctor = await _dbContext.Doctors.AsNoTracking().FirstOrDefaultAsync(d => d.Id == bookingDto.doctorId);
            if (doctor == null) return null;
            var booking = new Booking
            {
                AppointmentId = appointment.Id,
                Status = BookingStatus.New,
                Day = appointment.Day,
                Time = appointment.TimeStart,
                PatientId = bookingDto.PatientId,
                DoctorId = appointment.DoctorId,
                ProblemDescription = bookingDto.ProblemDescription,
                Age = bookingDto.Age,
                Gender = bookingDto.gender,
                ForHimSelf = bookingDto.ForHimSelf,

            };
            if (!bookingDto.ForHimSelf)
                booking.patientName = bookingDto.patientName;
            else
            {
                var patientName = await _dbContext.Patients.FindAsync(bookingDto.PatientId);

                booking.patientName = patientName.patientName;
            }
            appointment.IsAvailable = false;
            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();

            // send notification to the doctor about the booking 
            var patient = await _dbContext.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == bookingDto.PatientId);
            Notification notification = new()
            {
                Date = DateTime.Now,
                Message = $"{patient.patientName} has made an appointment for {booking.Day} time {booking.Time}",
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

        public async Task<string> UpdateBookingAsync(int bookingId, UpdateBookingDTO updateDTO)
        {
            var booking = await _dbContext.Bookings.FindAsync(bookingId);
            if (booking == null) return "Booking not found";
            if (booking.Status == BookingStatus.Cancel)
                return "Booking is already canceled";
            else
            {
                if (booking.ChangeCount > 2)
                {
                    booking.Status = BookingStatus.Cancel;
                    await _dbContext.SaveChangesAsync();
                    return "Booking canceled due to exceeding allowed changes";
                }
                booking.Day = updateDTO.Day;
                booking.Time = updateDTO.Time;
                booking.ChangeCount++;

                await _dbContext.SaveChangesAsync();
                return "Booking updated successfully";
            }
        }
        public async Task<bool> CancelBookingAsync(int id)
        {
            //cansel booking
            var booking = await _dbContext.Bookings.FindAsync(id);
            if (booking == null) return false;
            var patient = await _dbContext.Patients.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == booking.PatientId);
            booking.Status = BookingStatus.Cancel ;
            await _dbContext.SaveChangesAsync();
            // send notification to the doctor about cancellation of booking 
            if (patient != null)
            {
                Notification notification = new()
                {
                    Date = DateTime.Now,
                    Message = $"{patient.User.Name} has canceled the appointment scheduled for {booking.Day} Time {booking.Time}",
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

        public async Task<List<GetBookingDTO>> GetBookingByPatientIdAsync(int patientId)
        {
            var bookings = await _dbContext.Bookings.Where(b => b.PatientId == patientId && b.Status == BookingStatus.Completed)
                .Include(b => b.Doctor).ThenInclude(d => d.User).Include(b => b.Doctor).ThenInclude(d => d.Specialization)
                .ToListAsync();

            if (bookings == null) return [];

            return bookings.Select(b => new GetBookingDTO()
            {
                DoctorName = b.Doctor.User.Name,
                SpecializationName = b.Doctor.Specialization.Name,
                Photo = b.Doctor.User.Photo != null ? $"data:image/png;base64,{Convert.ToBase64String(b.Doctor.User.Photo)}" : null,
                Day = b.Day,
                Time = b.Time.ToString("HH:mm"),
                Address = b.Doctor.Address,
                DoctorId = b.DoctorId,
                BookingId = b.Id
            }).ToList();
        }
        public async Task<List<DoctorBookingDTO>> GetCompletedBookingsByDoctorAsync(int doctorId)
        {
            var bookings = await _dbContext.Bookings
                .Where(b => b.DoctorId == doctorId && b.Status == BookingStatus.Completed)
                .Include(b => b.Patient)
                .ThenInclude(p => p.User)
                .ToListAsync();

            return bookings.Select(b => new DoctorBookingDTO
            {
                BookingId = b.Id,
                PatientId = b.Patient.Id,
                PatientName = b.Patient.User.Name,
                PatientPhoto = b.Patient.User.Photo != null
                    ? $"data:image/png;base64,{Convert.ToBase64String(b.Patient.User.Photo)}"
                    : null,
                Age = (int)b.Age
            }).ToList();
        }
        public async Task<BookingDetailsDTO> GetBookingDetailsAsync(int bookingId)
        {
            var booking = await _dbContext.Bookings
                .Include(b => b.Doctor)
                    .ThenInclude(d => d.User)
                .Include(b => b.Patient)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking == null)
                return null;

            return new BookingDetailsDTO
            {
                PatientId = booking.PatientId,
                PatientName = booking.Patient.User.Name,
                PatientPhoto = booking.Patient.User.Photo != null
                    ? $"data:image/png;base64,{Convert.ToBase64String(booking.Patient.User.Photo)}"
                    : null,
                Age = (int)booking.Age,
                Day = booking.Day,
                Time = booking.Time,
                Phone = booking.Patient.User.PhoneNumber,
                Gender = booking.Gender,
                ProblemDescription = booking.ProblemDescription
            };
        }

        public async Task<List<AllBookingDTO>> GetAllBookingsAsync()
        {
            var bookings = await _dbContext.Bookings
                .Include(b => b.Doctor).ThenInclude(d => d.User)
                .Include(b => b.Doctor).ThenInclude(d => d.Specialization)
                .Include(b => b.Patient)
                .ToListAsync();

            return bookings.Select(b => new AllBookingDTO()
            {
                DoctorName = b.Doctor.User.Name,
                //SpecializationName = b.Doctor.Specialization.Name,
                //Photo = b.Doctor.User.Photo != null ? $"data:image/png;base64,{Convert.ToBase64String(b.Doctor.User.Photo)}" : null,
                Day = b.Day,
                Time = b.Time.ToString("HH:mm"),
                //Address = b.Doctor.Address,
                //DoctorId = b.DoctorId,
                //BookingId = b.Id,
                patientName = b.Patient.patientName,
                Status = b.Status.ToString()

            }).ToList();
        }

        public async Task<List<CanceledBookingDto>> GetCanceledBookingsAsync(int patientId)
        {
            var bookings = await _dbContext.Bookings
                .Where(b => b.PatientId == patientId && b.Status == BookingStatus.Cancel)
                .Include(b => b.Doctor)
                .ThenInclude(p => p.User)
                .ToListAsync();
            if (bookings == null) return [];
            return bookings.Select(b => new CanceledBookingDto
            {
                DoctorName = b.Doctor?.User?.Name,
                DoctorImage = b.Doctor?.User?.Photo != null
        ? $"data:image/png;base64,{Convert.ToBase64String(b.Doctor.User.Photo)}"
        : null,
                SpecializationName = b.Doctor?.Specialization?.Name,
                BookingDate = b.Day
            }).ToList();

        }
    }
}



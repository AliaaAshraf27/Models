using MedicalServices.Models;

namespace MedicalServices.Services
{
    using MedicalServices.DTO;
    using MedicalServices.Models;

    public interface IBookingService
    {
        Task<List<AvailableSlotDTO>> GetAvailableSlotsAsync(int doctorId);
        Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto);
        Task<string> UpdateBookingAsync(int bookingId ,UpdateBookingDTO updateDTO);
        Task<bool> CancelBookingAsync(int id);
        Task<List<CanceledBookingDto>> GetCanceledBookingsAsync(int patientId);
        Task<List<GetBookingDTO>> GetBookingByPatientIdAsync(int patientId);
        Task<List<DoctorBookingDTO>> GetCompletedBookingsByDoctorAsync(int doctorId);
        Task<BookingDetailsDTO> GetBookingDetailsAsync(int bookingId);
        Task<List<AllBookingDTO>> GetAllBookingsAsync();

    }


}

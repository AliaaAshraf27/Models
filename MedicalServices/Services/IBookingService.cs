namespace MedicalServices.Services
{
    using MedicalServices.DTO;
    using MedicalServices.Models;

    public interface IBookingService
    {
        Task<List<AvailableSlotDTO>> GetAvailableSlotsAsync(int doctorId);
        Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto);
        Task<string> UpdateBookingAsync(int bookingId ,UpdateBookingDTO updateDTO);
        //Task<bool> CancelBookingAsync(int id);
        Task<List<GetBookingDTO>> GetBookingAsync(int patientId);

    }


}

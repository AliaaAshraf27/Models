namespace MedicalServices.Services
{
    using MedicalServices.DTO;
    using MedicalServices.Models;

    public interface IBookingService
    {
        Task<List<AvailableSlotDTO>> GetAvailableSlotsAsync(int doctorId);
        Task<Booking?> BookAppointmentAsync(CreateBookingDTO bookingDto);

    }


}

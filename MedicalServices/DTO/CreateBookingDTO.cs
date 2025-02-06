using MedicalServices.Enums;

namespace MedicalServices.DTO
{
    public class CreateBookingDTO
    {
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public string ProblemDescription { get; set; }
    }

    public class GetBookingDTO
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string SpecializationName { get; set; }
        public string? Photo { get; set; }
    }
    public class FilterBookingDTO
    {
        public int PatientId { get; set; }
        public BookingStatus Status { get; set; }
    }

}

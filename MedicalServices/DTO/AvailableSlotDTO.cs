namespace MedicalServices.DTO
{
    public class AvailableSlotDTO
    {
        public DateOnly Day { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public int AppointmentId { get; set; }
    }
}

namespace MedicalServices.DTO
{
    public class AvailableSlotDTO
    {
        public DateOnly Day { get; set; }
        public string Time { get; set; }
        public int AppointmentId { get; set; }
    }
}

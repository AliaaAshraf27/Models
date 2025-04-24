namespace MedicalServices.DTO
{
    public class AvailableSlotDTO
    {
        public DateOnly Day { get; set; }
        public string Name { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public int AppointmentId { get; set; }
        public float Price { get; set; }
    }
}

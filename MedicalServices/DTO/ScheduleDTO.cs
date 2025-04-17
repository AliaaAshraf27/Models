namespace MedicalServices.DTO
{
    public class ScheduleDTO
    {
        public DateOnly? Date { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public float? Price { get; set; }
    }
}

namespace MedicalServices.Models
{
    public class AvailableAppointments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Day { get; set; } 
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public bool IsAvailable { get; set; }
        public float Price { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

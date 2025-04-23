namespace MedicalServices.DTO
{
    public class AddAppointmentDTO
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public float Price { get; set; }
    }

}

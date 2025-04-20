namespace MedicalServices.DTO
{
    public class AddAppointmentDTO
    {
        public int DoctorId { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
    }

}

namespace MedicalServices.DTO
{
    public class ReviewDTO
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
    public class GetReviewsDTO
    {
        public string Comment { get; set; }
        public string SenderName { get; set; }

    }
}

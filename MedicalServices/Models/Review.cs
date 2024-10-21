using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalServices.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Rating { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}

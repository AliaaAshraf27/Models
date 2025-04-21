using System.ComponentModel.DataAnnotations;

namespace MedicalServices.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        public byte[]? Image { get; set; }

        public virtual List<Doctor> Doctors { get; set; }
    }
}

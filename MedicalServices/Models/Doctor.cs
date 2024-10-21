using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalServices.Models
{
    public class Doctor
    {
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Address { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual User User { get; set; }
        public List<DoctorSchedule> Schedules { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Booking> Bookings { get; set; }
    }

}

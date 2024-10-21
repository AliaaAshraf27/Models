using MedicalServices.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalServices.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public BookingStatus Status { get; set; } //Enum
        public DateOnly Date { get; set; }
        public DateTime Time { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
    }
}

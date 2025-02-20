using MedicalServices.Enums;

namespace MedicalServices.DTO
{
    public class UpdateBookingDTO
    {
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }

    }
}

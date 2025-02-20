using MedicalServices.Enums;

namespace MedicalServices.DTO
{
    public class UpdateBookingDTO
    {
        public DateOnly Day { get; set; }
        public string Time { get; set; }

    }
}

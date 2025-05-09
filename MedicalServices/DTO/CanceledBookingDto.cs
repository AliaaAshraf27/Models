﻿namespace MedicalServices.DTO
{
    public class CanceledBookingDto
    {
        public string DoctorName { get; set; }
        public string DoctorImage { get; set; }
        public string SpecializationName { get; set; }
        public DateOnly BookingDate { get; set; }
    }
}

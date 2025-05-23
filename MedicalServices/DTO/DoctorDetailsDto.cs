﻿namespace MedicalServices.DTO
{
    public class DoctorDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public string Experience { get; set; }
        public byte[]? ProfileImage { get; set; }
        public string Focus { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public List<AvailableSlotDTO> AvailableSlots { get; set; }
        
    }
    public class AvailableAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }
    }
}

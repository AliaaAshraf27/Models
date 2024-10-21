﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalServices.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public float Price { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}

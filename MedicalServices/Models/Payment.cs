﻿using MedicalServices.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalServices.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public double Amount { get; set; }
        public PaymentStatus Status { get; set; } //Enum
        public virtual Booking Booking { get; set; }
    }
}

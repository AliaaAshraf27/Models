﻿namespace MedicalServices.DTO
{
    public class RegisterDTO
    {
        public required string Name { get; set; }
        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
        public string Phone { get; set; }

    }
}
﻿using MedicalServices.DTO;

namespace MedicalServices.Services
{
    public interface IDoctorServices
    {
        public Task<List<DoctorDTO>> GetAllDoctorsAsync(Filter filter);
        Task<DoctorDetailsDto> GetDoctorDetailsAsync(int doctorId);

    }
}

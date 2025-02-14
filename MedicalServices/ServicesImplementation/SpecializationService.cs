using AutoMapper;
using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.ServicesImplementation
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ApplicationDbContext _dbContext;
        public SpecializationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      public async Task<List<Specialization>> GetAllSpecializationsAsync()
        {
            var specializations = await _dbContext.Specializations.ToListAsync();
            return specializations;
        }

        public async Task<List<DrDTO>> GetDoctorsBySpecializationIDAsync(int specializationId)
        {
            var doctors = await _dbContext.Doctors.Where(d => d.Specialization.Id == specializationId)
                 .Select(d => new DrDTO
                 {
                     Id = d.Id,
                     DoctorName = d.User.Name,
                     Address = d.Address,
                     Photo = d.User.Photo != null ?  $"data:image/png;base64,{Convert.ToBase64String(d.User.Photo)} ": null 
                 }).ToListAsync();
            return doctors;

        }

    }
}

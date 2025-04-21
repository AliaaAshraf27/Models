using AutoMapper;
using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace MedicalServices.ServicesImplementation
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ApplicationDbContext _dbContext;
        public SpecializationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      public async Task<List<GetAllSpecializaion>> GetAllSpecializationsAsync()
        {
            var specializations = await _dbContext.Specializations
                .Select(s => new GetAllSpecializaion
                {
                    Id = s.Id,
                    Name = s.Name,
                    Image = s.Image.ToString() 
                }).ToListAsync();
            if (specializations == null) return [];
            return specializations;
           
        }

        public async Task<List<DrDTO>> GetDoctorsBySpecializationIDAsync(int specializationId)
        {
            var doctors = await _dbContext.Doctors.Where(d => d.Specialization.Id == specializationId)
                .Include(s => s.Schedules)
                 .Select(d => new DrDTO
                 {
                     Id = d.Id,
                     DoctorName = d.User.Name,
                     Address = d.Address,
                     Photo = d.User.Photo != null ?  $"data:image/png;base64,{Convert.ToBase64String(d.User.Photo)} ": null ,
                     Rating = d.Reviews.Any() ? (int)Math.Round(d.Reviews.Average(r => r.Rating)) : 0,
                     Price = d.Schedules.Min(p => (float?)p.Price) ?? 0
                 }).ToListAsync();
            return doctors;

        }
        public async Task<bool> AddSpecializationAsync(string name)
        {
            var specialization = new Specialization{ Name = name };

            _dbContext.Specializations.Add(specialization);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveSpecializationAsync(int specializationId)
        {
            var specialization = await _dbContext.Specializations.FindAsync(specializationId);
            if (specialization == null)
                return false;

            bool hasDoctors = await _dbContext.Doctors.AnyAsync(d => d.SpecializationId == specializationId);
            if (hasDoctors)
            {
                throw new InvalidOperationException("You cannot remove the specialization because it is associated with existing doctors.");
            }

            _dbContext.Specializations.Remove(specialization);
            return await _dbContext.SaveChangesAsync() > 0;
        }


    }
}

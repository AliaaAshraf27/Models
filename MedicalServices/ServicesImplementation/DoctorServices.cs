using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Enums;
using MedicalServices.Models;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32.SafeHandles;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalServices.ServicesImplementation
{
    public class DoctorServices : IDoctorServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public DoctorServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DoctorDTO>> GetAllDoctorsAsync(Filter filter)
        {
            // Start with IQueryable<Doctor>
            var doctors = _dbContext.Doctors.AsQueryable();

            // Filter by Gender
            if (filter.Gender != null)
            {
                doctors = doctors.Where(x => x.Gender == filter.Gender.Value);
            }
            // Filter by Favorite
            else if (filter.PatientId != null)
            {
                var favoriteDoctorIds = _dbContext.PatientFavoriteDoctors
                    .Where(x => x.PatientId == filter.PatientId)
                    .Select(x => x.DoctorId);
            }
            // Filter by Rating
            else if (filter.Rate != null)
            {
                doctors = doctors.Where(d => d.Reviews.Any(r => r.Rating >= 5));
            }
            // Sorting by Name (A-Z or Z-A)
            doctors = filter.OrderType == "DESC"
                ? doctors.OrderByDescending(o => o.User.Name)
                : doctors.OrderBy(o => o.User.Name);

            var doctorDTO = await doctors.Select(d => new DoctorDTO
            {
                Id = d.Id,
                DoctorName = d.User.Name,
                SpecializationName = d.Specialization.Name,
                Photo = d.User.Photo
                
            }).ToListAsync();

            return doctorDTO;
        }

       

    }
}

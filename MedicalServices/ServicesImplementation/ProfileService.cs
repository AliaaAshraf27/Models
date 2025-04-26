using AutoMapper;
using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using static NHibernate.Engine.Query.CallableParser;

namespace MedicalServices.ServicesImplementation
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _dbContext;
        public ProfileService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserProfileDTO> GetProfileAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null) return null;
            return new UserProfileDTO
            {
                Name = user.Name,
               PhotoData = user.Photo != null ? $"data:image/png;base64,{Convert.ToBase64String(user.Photo)}": null

            };
        }
        public async Task<UserAdminProfileDTO> GetAdminProfileAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null) return null;
            return new UserAdminProfileDTO
            {
                Name = user.Name,
                PhotoData = user.Photo != null ? $"data:image/png;base64,{Convert.ToBase64String(user.Photo)}" : null,
                Email = user.Email,
                Password = user.Password

            };

        }
        public async Task<bool> UpdateProfileAsync(UpdateUserProfileDTO updatedProfile, int id)
        {
            var user = await _dbContext.Users.Include(u => u.Patient)
                  .Include(u => u.Doctor)
                  .FirstOrDefaultAsync(u => u.Id == id); 
            if (user == null) return false;
            if (updatedProfile.Photo != null)
            {
                using var dataStream = new MemoryStream();
                await updatedProfile.Photo.CopyToAsync(dataStream);
                user.Photo = dataStream.ToArray();
            }
            user.Name = updatedProfile.Name != null? updatedProfile.Name : user.Name;
            user.Email = updatedProfile.Email != null ? updatedProfile.Email : user.Email;
            user.PhoneNumber = updatedProfile.Phone != null ? updatedProfile.Phone : user.PhoneNumber;
            user.Patient.Age = updatedProfile.Age ?? user.Patient.Age;
            await _dbContext.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateDrProfileAsync(UpdateDrProfileDTO updatedProfile, int drId)
        {
            var doctor = await _dbContext.Doctors
                  .Include(d => d.User)
                  .Include(d => d.Specialization)
                  .FirstOrDefaultAsync(d => d.Id == drId);
            if (doctor == null) return false;
            if (updatedProfile.Photo != null)
            {
                using var dataStream = new MemoryStream();
                await updatedProfile.Photo.CopyToAsync(dataStream);
                doctor.User.Photo = dataStream.ToArray();
            }
            if (updatedProfile != null)
            {
                doctor.User.Name = updatedProfile.Name != null ? updatedProfile.Name : doctor.User.Name;
                doctor.User.Email = updatedProfile.Email != null ? updatedProfile.Email : doctor.User.Email;
                doctor.User.PhoneNumber = updatedProfile.Phone != null ? updatedProfile.Phone : doctor.User.PhoneNumber;
                doctor.Address = updatedProfile.Address ?? doctor.Address;
                doctor.Experience = updatedProfile.Experience ?? doctor.Experience;
                doctor.Focus = updatedProfile.Focus ?? doctor.Experience;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAdminProfileAsync(UpdateAdminProfileDTO updatedProfile, int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return false;
            if (updatedProfile.Photo != null)
            {
                using var dataStream = new MemoryStream();
                await updatedProfile.Photo.CopyToAsync(dataStream);
                user.Photo = dataStream.ToArray();
            }
            user.Name = updatedProfile.Name != null ? updatedProfile.Name : user.Name;
            user.Email = updatedProfile.Email != null ? updatedProfile.Email : user.Email;
            user.Password = updatedProfile.Password != null ? updatedProfile.Password : user.Password;
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> ChangePasswordAsync(int id, ChangePasswordDTO passDTO)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return false;
            if (user.Password != passDTO.CurrentPassword || user.Password == passDTO.NewPassword || passDTO.NewPassword != passDTO.ConfirmNewPassword)
                return false;   
            user.Password = passDTO.NewPassword;
            _dbContext.SaveChanges();
            return true;

        }
    }
}

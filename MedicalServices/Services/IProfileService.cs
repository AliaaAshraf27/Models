using MedicalServices.DTO;
using MedicalServices.Models.Identity;

namespace MedicalServices.Services
{
    public interface IProfileService
    {
      
            Task<UserProfileDTO> GetProfileAsync(int id);
            Task<bool> UpdateProfileAsync(UpdateUserProfileDTO updatedProfile, int id);
            Task<bool> UpdateDrProfileAsync(UpdateDrProfileDTO updatedProfile, int drid);
            Task<bool> ChangePasswordAsync(int id , ChangePasswordDTO passDTO);
            Task<bool> UpdateAdminProfileAsync(UpdateAdminProfileDTO updatedProfile, int id);
            Task<UserAdminProfileDTO> GetAdminProfileAsync(int id);
    }
}

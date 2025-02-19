using MedicalServices.DTO;
using MedicalServices.Models.Identity;

namespace MedicalServices.Services
{
    public interface IProfileService
    {
      
            Task<UserProfileDTO> GetProfileAsync(int id);
            Task<bool> UpdateProfileAsync(UpdateUserProfileDTO updatedProfile, int id);
            Task<bool> ChangePasswordAsync(int id , ChangePasswordDTO passDTO);
    }
}

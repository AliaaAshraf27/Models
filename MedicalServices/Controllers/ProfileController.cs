using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
       private readonly IProfileService _profileService;
        #region Constractor
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        #endregion

        #region End Point

        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;

        [HttpGet(Router.ProfileRouting.GetUser)]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await _profileService.GetProfileAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet(Router.ProfileRouting.GetAdmin)]
        public async Task<IActionResult> GetAdminProfile(int id)
        {
            var user = await _profileService.GetAdminProfileAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut(Router.ProfileRouting.UpdateUser)]
        public async Task<IActionResult> UpdateUserProfile([FromForm]UpdateUserProfileDTO updatedProfile , int id)
        {
            var user = await _profileService.UpdateProfileAsync(updatedProfile ,id);
            if (user == false) return NotFound();
            if (updatedProfile.Photo != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(updatedProfile.Photo.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (updatedProfile.Photo.Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB!");
            }
            return Ok(user);
        }
        [HttpPut(Router.ProfileRouting.UpdateDr)]
        public async Task<IActionResult> UpdateDrProfile([FromForm] UpdateDrProfileDTO updatedProfile, int id)
        {
            var doctor = await _profileService.UpdateDrProfileAsync(updatedProfile, id);
            if (doctor == false) return NotFound();
            if (updatedProfile.Photo != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(updatedProfile.Photo.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (updatedProfile.Photo.Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB!");
            }
            return Ok(doctor);
        }
        [HttpPut(Router.ProfileRouting.UpdateAdmin)]
        public async Task<IActionResult> UpdateAdminProfile([FromForm] UpdateAdminProfileDTO updatedProfile, int id)
        {
            var user = await _profileService.UpdateAdminProfileAsync(updatedProfile, id);
            if (user == false) return NotFound();
            if (updatedProfile.Photo != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(updatedProfile.Photo.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (updatedProfile.Photo.Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB!");
            }
            return Ok(user);
        }
        [HttpPut("change")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordDTO dto ,int id)
        {
            var result = await _profileService.ChangePasswordAsync(id, dto);
            if(!result) return BadRequest("Password change failed");
            return Ok("Password changed successfully");
        }

        #endregion
    }
}


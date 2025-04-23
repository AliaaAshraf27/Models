using MedicalServices.Models;
using Stripe;

namespace MedicalServices.DTO
{
    public class UserProfileDTO
    {
        public string Name { get; set; }
        public string? PhotoData { get; set; }
    }
    public class UpdateUserProfileDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public IFormFile? Photo { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
    }
    public class ChangePasswordDTO
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}

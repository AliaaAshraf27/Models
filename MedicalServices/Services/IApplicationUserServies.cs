using MedicalServices.Models.Identity;

namespace MedicalServices.Services
{
    public interface IApplicationUserServies
    {
        public Task<string> AddUserAsync(User user, string password);

    }
}

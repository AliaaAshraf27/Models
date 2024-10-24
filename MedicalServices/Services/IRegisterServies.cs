using MedicalServices.Models.Identity;

namespace MedicalServices.Services
{
    public interface IRegisterServies
    {
        public Task<string> AddUserAsync(User user, string password);

    }
}

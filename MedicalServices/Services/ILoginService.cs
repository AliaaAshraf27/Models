using MedicalServices.Models.Identity;

namespace MedicalServices.Services
{
    public interface ILoginService
    {
        public Task<string> LogUserAsync(string email, string password);
    }
}

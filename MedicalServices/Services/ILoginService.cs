namespace MedicalServices.Services
{
    public interface ILoginService
    {
        public Task<int?> GetId(string Email);
        public Task<string> LogUserAsync(string email, string password);
        Task StoreTokenAsync(string email, string token);
    }
}

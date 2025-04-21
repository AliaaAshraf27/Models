namespace MedicalServices.Services
{
    public interface IDeleteAccountService
    {
        Task<bool> DeleteAccountAsync(int Id);
    }
}

using MedicalServices.DbContext;
using MedicalServices.Services;

namespace MedicalServices.ServicesImplementation
{
    public class DeleteAccountService : IDeleteAccountService
    {
        private readonly ApplicationDbContext _dbcontext;

        public DeleteAccountService(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            // Find the account in the database
            var user = await _dbcontext.Users.FindAsync(accountId);
            if (user == null) return false;

            // Remove the user from the database
            _dbcontext.Users.Remove(user);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}

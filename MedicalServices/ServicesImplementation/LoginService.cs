using MedicalServices.DbContext;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Identity;


namespace MedicalServices.ServicesImplementation
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public LoginService(ApplicationDbContext dbContext,
                                      UserManager<User> userManager)
        {

            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<string> LogUserAsync(string email, string password)
        {
            using var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // Find User Email
                var emailUser = await _userManager.FindByEmailAsync(email);

                // Email is or not exist
                if (emailUser == null) return "EmailIsNotExist";

                // Check Password
                var checkPassword = await _userManager.CheckPasswordAsync(emailUser, password);
                if (!checkPassword) return "PasswordIsNotCorrect";

                // Commit transaction if everything is successful
                await transact.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                // Rollback transaction in case of any exception
                await transact.RollbackAsync();
                return "Failed: " + ex.Message;
            }
        }

        public async Task StoreTokenAsync(string email, string token)
        {
            var emailUser = await _userManager.FindByEmailAsync(email);
            if (emailUser != null)
            {
                await _userManager.SetAuthenticationTokenAsync(emailUser, "JWT", "AccessToken", token);
            }
        }


    }
}

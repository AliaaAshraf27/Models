using MedicalServices.DbContext;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


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

        public async Task<int?> GetId(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(n => n.Email == email);
            if (user == null)
                return null;
            return user.Id;
        }

        public async Task<string> LogUserAsync(string email, string password)
        {
            using var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // Find User Email
                //var emailUser = await _userManager.FindByEmailAsync(email);
                var emailUser = await _dbContext.Users.FirstOrDefaultAsync(n => n.Email == email);

                // Email is or not exist
                if (emailUser == null) return "EmailIsNotExist";

                // Check Password
                var checkPassword = emailUser.Password == password;
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
            // Find the user by email directly in the Users table
            var emailUser = await _dbContext.Users.FirstOrDefaultAsync(n => n.Email == email);

            if (emailUser != null)
            {
                // Check if a token already exists for the user
                var existingToken = await _dbContext.UserTokens
                    .FirstOrDefaultAsync(t => t.UserId == emailUser.Id && t.LoginProvider == "JWT" && t.Name == "AccessToken");

                if (existingToken != null)
                {
                    // Update the existing token
                    existingToken.Value = token;
                }
                else
                {
                    // Create a new entry for AspNetUserTokens table
                    var userToken = new IdentityUserToken<int>
                    {
                        UserId = emailUser.Id,        // The user's ID
                        LoginProvider = "JWT",       // Define your login provider (e.g., "JWT")
                        Name = "AccessToken",        // Define the token name (e.g., "AccessToken")
                        Value = token                // The token value
                    };

                    // Insert the new token
                    _dbContext.UserTokens.Add(userToken);
                }

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> getUserByEmail(string email)
        {
            try
            {
                using var transact = await _dbContext.Database.BeginTransactionAsync();
                var user = await _dbContext.Users.FirstOrDefaultAsync(n => n.Email == email);
                //var emailUser = await _userManager.FindByEmailAsync(email);

                if (user == null)
                    throw new Exception("User not found");
                return user;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}

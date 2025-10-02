using DNDApi.Api.v1.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace DNDApi.Api.v1.Services
{
    public class BCryptPasswordHasher : IPasswordHasher<UserEntity>
    {
        public string HashPassword(UserEntity user, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(UserEntity user, string hashedPassword, string providedPassword)
        {
            bool isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
            return isValid ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}
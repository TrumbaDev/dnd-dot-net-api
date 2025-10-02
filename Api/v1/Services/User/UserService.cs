using DNDApi.Api.v1.Contracts.User;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; 

namespace DNDApi.Api.v1.Services.User
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;
        // private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            // _passwordHasher = passwordHasher;
        }

        public async Task<UserEntity> GetByUserNameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == username);
        }
    }
}
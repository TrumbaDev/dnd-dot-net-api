using DNDApi.Api.v1.Contracts.User;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Exceptions;
using DNDApi.Api.v1.Models.Entities;

namespace DNDApi.Api.v1.Reposiroty.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public UserEntity GetUserByName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Login == username) ?? throw new NotFoundException("User not found");
        }
    }
}
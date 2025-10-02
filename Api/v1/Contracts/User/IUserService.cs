using DNDApi.Api.v1.Models.Entities;

namespace DNDApi.Api.v1.Contracts.User
{
    public interface IUserService
    {
        Task<UserEntity> GetByUserNameAsync(string username);
    }
}
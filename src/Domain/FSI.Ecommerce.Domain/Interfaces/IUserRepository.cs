using FSI.Ecommerce.Domain.Entities;

namespace FSI.Ecommerce.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        Task<UserEntity?> GetByUsernameAsync(string username);
        Task<UserEntity?> GetByPasswordAsync(string password);
        Task<AuthenticationEntity> AuthenticationAsync(AuthenticationEntity authenticationEntity);
    }
}

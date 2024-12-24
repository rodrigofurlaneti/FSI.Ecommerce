using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FSI.Ecommerce.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<UserEntity?> GetByUsernameAsync(string username)
        {
            return await _context.Ecommerce_Users.FirstOrDefaultAsync(user => user.Username == username);
        }

        public async Task<UserEntity?> GetByPasswordAsync(string password)
        {
            return await _context.Ecommerce_Users.FirstOrDefaultAsync(user => user.Password == password);
        }

        public async Task<AuthenticationEntity?> AuthenticationAsync(AuthenticationEntity authenticationEntity)
        {
            var getByUsername = await GetByUsernameAsync(authenticationEntity.Username);

            if (getByUsername != null)
            {
                var getByPassword = await GetByPasswordAsync(authenticationEntity.Password);

                if (getByPassword != null)
                {
                    if (authenticationEntity.Username.Equals(getByUsername.Username) && authenticationEntity.Password.Equals(getByPassword.Password))
                    {
                        authenticationEntity.IsAuthentication = true;
                        authenticationEntity.Expiration = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        authenticationEntity.IsAuthentication = false;
                        authenticationEntity.Expiration = DateTime.Now;
                    }
                }
            }

            return authenticationEntity;
        }
    }
}

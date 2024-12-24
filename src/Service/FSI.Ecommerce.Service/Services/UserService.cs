using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;

namespace FSI.Ecommerce.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                DateInsert = user.DateInsert,
                DateUpdate = user.DateUpdate,
                Status = user.Status
            });
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var userEntity = await _repository.GetByIdAsync(id);
            if (userEntity == null)
                return null;

            return SetUserDto(userEntity);
        }

        public async Task<UserDto?> GetByUsernameAsync(string username)
        {
            var userEntity = await _repository.GetByUsernameAsync(username);
            if (userEntity == null)
                return null;

            return SetUserDto(userEntity);
        }

        public async Task<UserDto?> GetByPasswordAsync(string username)
        {
            var userEntity = await _repository.GetByUsernameAsync(username);
            if (userEntity == null)
                return null;

            return SetUserDto(userEntity);
        }

        public async Task AddAsync(UserDto userDto)
        {
            var userEntity = SetUserEntity_Insert(userDto);
            await _repository.AddAsync(userEntity);
        }


        public async Task UpdateAsync(int id, UserDto userDto)
        {
            var userEntity = await _repository.GetByIdAsync(id);
            if (userEntity == null)
                throw new ArgumentException($"User with ID {id} not found");

            var updatedEntity = SetUserEntity_Update(userEntity, userDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        public async Task<AuthenticationResponseDto?> AuthenticationAsync(AuthenticationRequestDto authenticationRequestDto)
        {
            //UserEntity entity = new UserEntity();

            AuthenticationResponseDto authenticationResponseDto = new AuthenticationResponseDto();

            AuthenticationEntity authenticationEntity = new AuthenticationEntity()
            {
                Username = authenticationRequestDto.Username,
                Password = authenticationRequestDto.Password
            };

            var entity = await _repository.AuthenticationAsync(authenticationEntity);

            if (entity != null)
            {
                if (entity.IsAuthentication)
                {
                    authenticationResponseDto.Token = Guid.NewGuid();
                    authenticationResponseDto.IsAuthentication = entity.IsAuthentication;
                    authenticationResponseDto.Expiration = entity.Expiration;
                    authenticationResponseDto.Message = "Authentication completed successfully";
                }
                else
                {
                    authenticationResponseDto.Token = Guid.Empty;
                    authenticationResponseDto.IsAuthentication = entity.IsAuthentication;
                    authenticationResponseDto.Expiration = entity.Expiration;
                    authenticationResponseDto.Message = "Username or password are invalid";
                }

            }

            return authenticationResponseDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeia de UserEntity para UserDto
        private UserDto SetUserDto(UserEntity userEntity)
        {
            return new UserDto
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Password = userEntity.Password,
                DateInsert = userEntity.DateInsert,
                DateUpdate = userEntity.DateUpdate,
                Status = userEntity.Status
            };
        }

        // Mapeia de UserDto para UserEntity
        private UserEntity SetUserEntity(UserDto userDto)
        {
            return new UserEntity
            {
                Id = userDto.Id,
                Username = userDto.Username,
                Password = userDto.Password,
                DateInsert = userDto.DateInsert,
                DateUpdate = userDto.DateUpdate,
                Status = userDto.Status
            };
        }

        // Cria uma nova entidade para inserção
        private UserEntity SetUserEntity_Insert(UserDto userDto)
        {
            return new UserEntity
            {
                Username = userDto.Username,
                Password = userDto.Password,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now,
                Status = userDto.Status
            };
        }

        // Atualiza uma entidade existente com novos dados
        private UserEntity SetUserEntity_Update(UserEntity existingEntity, UserDto userDto)
        {
            existingEntity.Username = userDto.Username;
            existingEntity.Password = userDto.Password;
            existingEntity.DateUpdate = DateTime.Now;
            existingEntity.Status = userDto.Status;
            return existingEntity;
        }
    }
}

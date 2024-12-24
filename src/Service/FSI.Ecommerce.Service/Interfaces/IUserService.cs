using FSI.Ecommerce.Service.Dtos;

namespace FSI.Ecommerce.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> GetByUsernameAsync(string username);
        Task AddAsync(UserDto userDto);
        Task UpdateAsync(int id, UserDto userDto);
        Task DeleteAsync(int id);
        Task<AuthenticationResponseDto?> AuthenticationAsync(AuthenticationRequestDto userDto);

    }
}

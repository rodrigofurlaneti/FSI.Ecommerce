using FSI.Ecommerce.Service.Dtos;

namespace FSI.Ecommerce.Service.Interfaces
{
    public interface IProfileService
    {
        Task<IEnumerable<ProfileDto>> GetAllAsync();
        Task<ProfileDto?> GetByIdAsync(int id);
        Task AddAsync(ProfileDto profileDto);
        Task UpdateAsync(int id, ProfileDto profileDto);
        Task DeleteAsync(int id);
    }
}

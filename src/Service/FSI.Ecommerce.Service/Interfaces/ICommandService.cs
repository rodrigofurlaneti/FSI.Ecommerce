using FSI.Ecommerce.Service.Dtos;

namespace FSI.Ecommerce.Service.Interfaces
{
    public interface ICommandService
    {
        Task<IEnumerable<CommandDto>> GetAllAsync();
        Task<CommandDto?> GetByIdAsync(int id);
        Task AddAsync(CommandDto commandDto);
        Task UpdateAsync(int id, CommandDto commandDto);
        Task DeleteAsync(int id);
    }
}

using FSI.Ecommerce.Service.Dtos;

namespace FSI.Ecommerce.Service.Interfaces
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        Task<PropertyDto?> GetByIdAsync(int id);
        Task AddAsync(PropertyDto propertyDto);
        Task UpdateAsync(int id, PropertyDto propertyDto);
        Task DeleteAsync(int id);
    }
}

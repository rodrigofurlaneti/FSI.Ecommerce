using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;

namespace FSI.Ecommerce.Service.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(PropertyDto propertyDto)
        {
            var propertyEntity = SetPropertyEntity_Insert(propertyDto);
            await _repository.AddAsync(propertyEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var properties = await _repository.GetAllAsync();
            return properties.Select(profile => new PropertyDto
            {
                Id = profile.Id,
                Name = profile.Name,
                Picture = profile.Picture,
                DateInsert = profile.DateInsert,
                DateUpdate = profile.DateUpdate,
                Status = profile.Status
            });
        }

        public async Task<PropertyDto?> GetByIdAsync(int id)
        {
            var propertyEntity = await _repository.GetByIdAsync(id);
            if (propertyEntity == null)
                return null;

            return SetPropertyDto(propertyEntity);
        }

        public async Task UpdateAsync(int id, PropertyDto propertyDto)
        {
            var propertyEntity = await _repository.GetByIdAsync(id);
            if (propertyEntity == null)
                throw new ArgumentException($"Property with ID {id} not found");

            var updatedEntity = SetPropertyEntity_Update(propertyEntity, propertyDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        // Mapeia de PropertyEntity para PropertyDto
        private PropertyDto SetPropertyDto(PropertyEntity propertyEntity)
        {
            return new PropertyDto
            {
                Id = propertyEntity.Id,
                Name = propertyEntity.Name,
                Enterprise = propertyEntity.Enterprise,
                Picture = propertyEntity.Picture,
                Location = propertyEntity.Location,
                Description = propertyEntity.Description,
                Details = propertyEntity.Details,
                Deadline = propertyEntity.Deadline,
                NumberOfShares = propertyEntity.NumberOfShares,
                SharesAvailable = propertyEntity.SharesAvailable,
                SharesNotAvailable = propertyEntity.SharesNotAvailable,
                ValueByShares = propertyEntity.ValueByShares,
                ExpectedValue = propertyEntity.ExpectedValue,
                Profitability = propertyEntity.Profitability,
                ProjectedProfitability = propertyEntity.ProjectedProfitability,
                Minimum = propertyEntity.Minimum,
                Maximum = propertyEntity.Maximum,
                WorksStarted = propertyEntity.WorksStarted,
                PercentageOfWorks = propertyEntity.PercentageOfWorks,
                DateInsert = propertyEntity.DateInsert,
                DateUpdate = propertyEntity.DateUpdate,
                Status = propertyEntity.Status
            };
        }

        // Mapeia de PropertyDto para PropertyEntity
        private PropertyEntity SetPropertyEntity(PropertyDto propertyDto)
        {
            return new PropertyEntity
            {
                Id = propertyDto.Id,
                Name = propertyDto.Name,
                Enterprise = propertyDto.Enterprise,
                Picture = propertyDto.Picture,
                Location = propertyDto.Location,
                Description = propertyDto.Description,
                Details = propertyDto.Details,
                Deadline = propertyDto.Deadline,
                NumberOfShares = propertyDto.NumberOfShares,
                SharesAvailable = propertyDto.SharesAvailable,
                SharesNotAvailable = propertyDto.SharesNotAvailable,
                ValueByShares = propertyDto.ValueByShares,
                ExpectedValue = propertyDto.ExpectedValue,
                Profitability = propertyDto.Profitability,
                ProjectedProfitability = propertyDto.ProjectedProfitability,
                Minimum = propertyDto.Minimum,
                Maximum = propertyDto.Maximum,
                WorksStarted = propertyDto.WorksStarted,
                PercentageOfWorks = propertyDto.PercentageOfWorks,
                DateInsert = propertyDto.DateInsert,
                DateUpdate = propertyDto.DateUpdate,
                Status = propertyDto.Status
            };
        }

        // Cria uma nova entidade para inserção
        private PropertyEntity SetPropertyEntity_Insert(PropertyDto propertyDto)
        {
            return new PropertyEntity
            {
                Id = propertyDto.Id,
                Name = propertyDto.Name,
                Enterprise = propertyDto.Enterprise,
                Picture = propertyDto.Picture,
                Location = propertyDto.Location,
                Description = propertyDto.Description,
                Details = propertyDto.Details,
                Deadline = propertyDto.Deadline,
                NumberOfShares = propertyDto.NumberOfShares,
                SharesAvailable = propertyDto.SharesAvailable,
                SharesNotAvailable = propertyDto.SharesNotAvailable,
                ValueByShares = propertyDto.ValueByShares,
                ExpectedValue = propertyDto.ExpectedValue,
                Profitability = propertyDto.Profitability,
                ProjectedProfitability = propertyDto.ProjectedProfitability,
                Minimum = propertyDto.Minimum,
                Maximum = propertyDto.Maximum,
                WorksStarted = propertyDto.WorksStarted,
                PercentageOfWorks = propertyDto.PercentageOfWorks,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now,
                Status = propertyDto.Status
            };
        }

        // Atualiza uma entidade existente com novos dados
        private PropertyEntity SetPropertyEntity_Update(PropertyEntity existingEntity, PropertyDto propertyDto)
        {
            existingEntity.Id = propertyDto.Id;
            existingEntity.Name = propertyDto.Name;
            existingEntity.Enterprise = propertyDto.Enterprise;
            existingEntity.Picture = propertyDto.Picture;
            existingEntity.Location = propertyDto.Location;
            existingEntity.Description = propertyDto.Description;
            existingEntity.Details = propertyDto.Details;
            existingEntity.Deadline = propertyDto.Deadline;
            existingEntity.NumberOfShares = propertyDto.NumberOfShares;
            existingEntity.SharesAvailable = propertyDto.SharesAvailable;
            existingEntity.SharesNotAvailable = propertyDto.SharesNotAvailable;
            existingEntity.ValueByShares = propertyDto.ValueByShares;
            existingEntity.ExpectedValue = propertyDto.ExpectedValue;
            existingEntity.Profitability = propertyDto.Profitability;
            existingEntity.ProjectedProfitability = propertyDto.ProjectedProfitability;
            existingEntity.Minimum = propertyDto.Minimum;
            existingEntity.Maximum = propertyDto.Maximum;
            existingEntity.WorksStarted = propertyDto.WorksStarted;
            existingEntity.PercentageOfWorks = propertyDto.PercentageOfWorks;
            existingEntity.DateInsert = propertyDto.DateInsert;
            existingEntity.DateUpdate = DateTime.Now;
            existingEntity.Status = propertyDto.Status;
            return existingEntity;
        }
    }
}

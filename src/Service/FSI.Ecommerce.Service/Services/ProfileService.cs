using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;

namespace FSI.Ecommerce.Service.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;

        public ProfileService(IProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProfileDto>> GetAllAsync()
        {
            var profiles = await _repository.GetAllAsync();
            return profiles.Select(profile => new ProfileDto
            {
                Id = profile.Id,
                Name = profile.Name,
                Picture = profile.Picture,
                DateInsert = profile.DateInsert,
                DateUpdate = profile.DateUpdate,
                Status = profile.Status
            });
        }

        public async Task<ProfileDto?> GetByIdAsync(int id)
        {
            var profileEntity = await _repository.GetByIdAsync(id);
            if (profileEntity == null)
                return null;

            return SetProfileDto(profileEntity);
        }

        public async Task AddAsync(ProfileDto ProfileDto)
        {
            var ProfileEntity = SetProfileEntity_Insert(ProfileDto);
            await _repository.AddAsync(ProfileEntity);
        }


        public async Task UpdateAsync(int id, ProfileDto ProfileDto)
        {
            var ProfileEntity = await _repository.GetByIdAsync(id);
            if (ProfileEntity == null)
                throw new ArgumentException($"Profile with ID {id} not found");

            var updatedEntity = SetProfileEntity_Update(ProfileEntity, ProfileDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeia de ProfileEntity para ProfileDto
        private ProfileDto SetProfileDto(ProfileEntity profileEntity)
        {
            return new ProfileDto
            {
                Id = profileEntity.Id,
                Name = profileEntity.Name,
                Picture = profileEntity.Picture,
                DateInsert = profileEntity.DateInsert,
                DateUpdate = profileEntity.DateUpdate,
                Status = profileEntity.Status
            };
        }

        // Mapeia de ProfileDto para ProfileEntity
        private ProfileEntity SetProfileEntity(ProfileDto profileDto)
        {
            return new ProfileEntity
            {
                Id = profileDto.Id,
                Name = profileDto.Name,
                Picture = profileDto.Picture,
                DateInsert = profileDto.DateInsert,
                DateUpdate = profileDto.DateUpdate,
                Status = profileDto.Status
            };
        }

        // Cria uma nova entidade para inserção
        private ProfileEntity SetProfileEntity_Insert(ProfileDto profileDto)
        {
            return new ProfileEntity
            {
                Name = profileDto.Name,
                Picture = profileDto.Picture,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now,
                Status = profileDto.Status
            };
        }

        // Atualiza uma entidade existente com novos dados
        private ProfileEntity SetProfileEntity_Update(ProfileEntity existingEntity, ProfileDto profileDto)
        {
            existingEntity.Name = profileDto.Name;
            existingEntity.Picture = profileDto.Picture;
            existingEntity.DateInsert = profileDto.DateInsert;
            existingEntity.DateUpdate = DateTime.Now;
            existingEntity.Status = profileDto.Status;
            return existingEntity;
        }

    }
}

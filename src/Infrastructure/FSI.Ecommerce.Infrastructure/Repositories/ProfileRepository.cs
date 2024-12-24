using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FSI.Ecommerce.Infrastructure.Repositories
{
    public class ProfileRepository : RepositoryBase<ProfileEntity>, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}

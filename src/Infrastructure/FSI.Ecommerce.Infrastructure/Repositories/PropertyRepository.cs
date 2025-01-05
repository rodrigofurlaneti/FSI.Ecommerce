using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Infrastructure.Data;

namespace FSI.Ecommerce.Infrastructure.Repositories
{
    public class PropertyRepository : RepositoryBase<PropertyEntity>, IPropertyRepository
    {
        public PropertyRepository(AppDbContext context) : base(context)
        {
        }
    }
}

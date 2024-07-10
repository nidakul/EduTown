using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolTypeClassRepository : EfRepositoryBase<SchoolTypeClass, int, BaseDbContext>, ISchoolTypeClassRepository
{
    public SchoolTypeClassRepository(BaseDbContext context) : base(context)
    {
    }
}
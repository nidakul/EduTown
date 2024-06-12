using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolTypeRepository : EfRepositoryBase<SchoolType, int, BaseDbContext>, ISchoolTypeRepository
{
    public SchoolTypeRepository(BaseDbContext context) : base(context)
    {
    }
}
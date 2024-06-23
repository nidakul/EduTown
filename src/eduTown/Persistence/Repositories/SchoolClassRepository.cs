using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolClassRepository : EfRepositoryBase<SchoolClass, int, BaseDbContext>, ISchoolClassRepository
{
    public SchoolClassRepository(BaseDbContext context) : base(context)
    {
    }
}
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolClassBranchRepository : EfRepositoryBase<SchoolClassBranch, int, BaseDbContext>, ISchoolClassBranchRepository
{
    public SchoolClassBranchRepository(BaseDbContext context) : base(context)
    {
    }
}
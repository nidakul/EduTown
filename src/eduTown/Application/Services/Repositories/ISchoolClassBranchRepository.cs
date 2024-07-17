using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISchoolClassBranchRepository : IAsyncRepository<SchoolClassBranch, int>, IRepository<SchoolClassBranch, int>
{
}
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBranchRepository : IAsyncRepository<Branch, int>, IRepository<Branch, int>
{
}
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISchoolTypeRepository : IAsyncRepository<SchoolType, int>, IRepository<SchoolType, int>
{
}
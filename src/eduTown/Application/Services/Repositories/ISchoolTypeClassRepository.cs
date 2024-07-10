using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISchoolTypeClassRepository : IAsyncRepository<SchoolTypeClass, int>, IRepository<SchoolTypeClass, int>
{
}
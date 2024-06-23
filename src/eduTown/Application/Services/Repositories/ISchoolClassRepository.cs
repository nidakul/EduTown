using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISchoolClassRepository : IAsyncRepository<SchoolClass, int>, IRepository<SchoolClass, int>
{
}
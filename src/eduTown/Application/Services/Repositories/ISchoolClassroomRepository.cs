using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISchoolClassroomRepository : IAsyncRepository<SchoolClassroom, int>, IRepository<SchoolClassroom, int>
{
}
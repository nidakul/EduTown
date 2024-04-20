using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassroomRepository : IAsyncRepository<Classroom, int>, IRepository<Classroom, int>
{
}
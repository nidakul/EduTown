using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonClassroomRepository : IAsyncRepository<LessonClassroom, int>, IRepository<LessonClassroom, int>
{
}
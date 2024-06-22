using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISchoolLessonRepository : IAsyncRepository<SchoolLesson, int>, IRepository<SchoolLesson, int>
{
}
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISchoolClassLessonRepository : IAsyncRepository<SchoolClassLesson, int>, IRepository<SchoolClassLesson, int>
{
}
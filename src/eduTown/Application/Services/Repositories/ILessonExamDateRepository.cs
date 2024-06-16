using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonExamDateRepository : IAsyncRepository<LessonExamDate, int>, IRepository<LessonExamDate, int>
{
}
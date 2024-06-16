using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserLessonRepository : IAsyncRepository<UserLesson, int>, IRepository<UserLesson, int>
{
}
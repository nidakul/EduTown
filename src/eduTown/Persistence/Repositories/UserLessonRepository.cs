using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserLessonRepository : EfRepositoryBase<UserLesson, int, BaseDbContext>, IUserLessonRepository
{
    public UserLessonRepository(BaseDbContext context) : base(context)
    {
    }
}
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonExamDateRepository : EfRepositoryBase<LessonExamDate, int, BaseDbContext>, ILessonExamDateRepository
{
    public LessonExamDateRepository(BaseDbContext context) : base(context)
    {
    }
}
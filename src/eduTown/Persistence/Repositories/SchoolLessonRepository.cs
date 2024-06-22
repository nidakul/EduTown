using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolLessonRepository : EfRepositoryBase<SchoolLesson, int, BaseDbContext>, ISchoolLessonRepository
{
    public SchoolLessonRepository(BaseDbContext context) : base(context)
    {
    }
}
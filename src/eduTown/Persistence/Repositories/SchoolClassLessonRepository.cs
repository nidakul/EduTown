using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolClassLessonRepository : EfRepositoryBase<SchoolClassLesson, int, BaseDbContext>, ISchoolClassLessonRepository
{
    public SchoolClassLessonRepository(BaseDbContext context) : base(context)
    {
    }
}
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolLessonClassRepository : EfRepositoryBase<SchoolLessonClass, int, BaseDbContext>, ISchoolLessonClassRepository
{
    public SchoolLessonClassRepository(BaseDbContext context) : base(context)
    {
    }
}
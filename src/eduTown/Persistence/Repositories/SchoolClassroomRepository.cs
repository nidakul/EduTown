using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SchoolClassroomRepository : EfRepositoryBase<SchoolClassroom, int, BaseDbContext>, ISchoolClassroomRepository
{
    public SchoolClassroomRepository(BaseDbContext context) : base(context)
    {
    }
}
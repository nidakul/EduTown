using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentExamDateRepository : EfRepositoryBase<StudentExamDate, int, BaseDbContext>, IStudentExamDateRepository
{
    public StudentExamDateRepository(BaseDbContext context) : base(context)
    {
    }
}
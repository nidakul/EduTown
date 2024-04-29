using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentGradeRepository : EfRepositoryBase<StudentGrade, int, BaseDbContext>, IStudentGradeRepository
{
    public StudentGradeRepository(BaseDbContext context) : base(context)
    {
    }
}
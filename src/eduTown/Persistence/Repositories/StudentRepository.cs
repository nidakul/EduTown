using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentRepository : EfRepositoryBase<Student, Guid, BaseDbContext>, IStudentRepository
{
    public StudentRepository(BaseDbContext context) : base(context)
    {
    }
}
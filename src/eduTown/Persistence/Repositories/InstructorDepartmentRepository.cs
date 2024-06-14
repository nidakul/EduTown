using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InstructorDepartmentRepository : EfRepositoryBase<InstructorDepartment, int, BaseDbContext>, IInstructorDepartmentRepository
{
    public InstructorDepartmentRepository(BaseDbContext context) : base(context)
    {
    }
}
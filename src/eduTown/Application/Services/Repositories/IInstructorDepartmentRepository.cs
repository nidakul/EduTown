using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInstructorDepartmentRepository : IAsyncRepository<InstructorDepartment, int>, IRepository<InstructorDepartment, int>
{
}
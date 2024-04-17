using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentRepository : IAsyncRepository<Student, Guid>, IRepository<Student, Guid>
{
}
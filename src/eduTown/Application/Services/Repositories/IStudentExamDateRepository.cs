using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentExamDateRepository : IAsyncRepository<StudentExamDate, int>, IRepository<StudentExamDate, int>
{
}
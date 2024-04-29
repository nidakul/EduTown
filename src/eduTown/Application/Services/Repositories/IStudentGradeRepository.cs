using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentGradeRepository : IAsyncRepository<StudentGrade, int>, IRepository<StudentGrade, int>
{
}
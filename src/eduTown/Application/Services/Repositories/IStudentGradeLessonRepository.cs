using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentGradeLessonRepository : IAsyncRepository<StudentGradeLesson, int>, IRepository<StudentGradeLesson, int>
{
}
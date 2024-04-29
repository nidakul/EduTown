using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentGradeLessons;

public interface IStudentGradeLessonService
{
    Task<StudentGradeLesson?> GetAsync(
        Expression<Func<StudentGradeLesson, bool>> predicate,
        Func<IQueryable<StudentGradeLesson>, IIncludableQueryable<StudentGradeLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentGradeLesson>?> GetListAsync(
        Expression<Func<StudentGradeLesson, bool>>? predicate = null,
        Func<IQueryable<StudentGradeLesson>, IOrderedQueryable<StudentGradeLesson>>? orderBy = null,
        Func<IQueryable<StudentGradeLesson>, IIncludableQueryable<StudentGradeLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentGradeLesson> AddAsync(StudentGradeLesson studentGradeLesson);
    Task<StudentGradeLesson> UpdateAsync(StudentGradeLesson studentGradeLesson);
    Task<StudentGradeLesson> DeleteAsync(StudentGradeLesson studentGradeLesson, bool permanent = false);
}

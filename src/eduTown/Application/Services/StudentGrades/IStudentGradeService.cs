using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentGrades;

public interface IStudentGradeService
{
    Task<StudentGrade?> GetAsync(
        Expression<Func<StudentGrade, bool>> predicate,
        Func<IQueryable<StudentGrade>, IIncludableQueryable<StudentGrade, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentGrade>?> GetListAsync(
        Expression<Func<StudentGrade, bool>>? predicate = null,
        Func<IQueryable<StudentGrade>, IOrderedQueryable<StudentGrade>>? orderBy = null,
        Func<IQueryable<StudentGrade>, IIncludableQueryable<StudentGrade, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentGrade> AddAsync(StudentGrade studentGrade);
    Task<StudentGrade> UpdateAsync(StudentGrade studentGrade);
    Task<StudentGrade> DeleteAsync(StudentGrade studentGrade, bool permanent = false);
}
